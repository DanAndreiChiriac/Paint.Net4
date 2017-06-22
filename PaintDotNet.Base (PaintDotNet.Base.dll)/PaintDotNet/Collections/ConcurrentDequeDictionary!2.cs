namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public sealed class ConcurrentDequeDictionary<TKey, TValue>
    {
        private LinkedArray<KeyValuePair<TKey, TValue>> deque;
        private Dictionary<TKey, int> keyToDequeIndexMap;
        private object sync;
        private IEqualityComparer<TValue> valueComparer;

        public ConcurrentDequeDictionary()
        {
            this.sync = new object();
            this.deque = new LinkedArray<KeyValuePair<TKey, TValue>>();
            this.keyToDequeIndexMap = new Dictionary<TKey, int>();
            this.valueComparer = EqualityComparer<TValue>.Default;
        }

        public bool Any()
        {
            object sync = this.sync;
            lock (sync)
            {
                return (this.deque.Count > 0);
            }
        }

        public bool ContainsKey(TKey key)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.keyToDequeIndexMap.ContainsKey(key);
            }
        }

        public TValue EnqueueOrUpdate(TKey key, TValue enqueueValue, Func<TKey, TValue, TValue> updateValueFactory) => 
            this.EnqueueOrUpdate(key, enqueueValue, updateValueFactory, QueueSide.Back);

        public TValue EnqueueOrUpdate(TKey key, TValue enqueueValue, Func<TKey, TValue, TValue> updateValueFactory, QueueSide queueSide)
        {
            TValue local;
            TValue local2;
            Validate.IsNotNull<Func<TKey, TValue, TValue>>(updateValueFactory, "updateValueFactory");
            do
            {
                if (this.TryGetValue(key, out local) && this.TryEnqueue(key, enqueueValue))
                {
                    return enqueueValue;
                }
                local2 = updateValueFactory(key, local);
            }
            while (!this.TryUpdate(key, local2, local));
            return local2;
        }

        public TValue GetOrEnqueue(TKey key, TValue value) => 
            this.GetOrEnqueue(key, value, QueueSide.Back);

        public TValue GetOrEnqueue(TKey key, Func<TKey, TValue> valueFactory) => 
            this.GetOrEnqueue(key, valueFactory, QueueSide.Back);

        public TValue GetOrEnqueue(TKey key, TValue value, QueueSide queueSide)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.GetOrEnqueueWhileLocked(key, value, queueSide);
            }
        }

        public TValue GetOrEnqueue(TKey key, Func<TKey, TValue> valueFactory, QueueSide queueSide)
        {
            TValue local;
            Validate.IsNotNull<Func<TKey, TValue>>(valueFactory, "valueFactory");
            if (this.TryGetValue(key, out local))
            {
                return local;
            }
            TValue local2 = valueFactory(key);
            return this.GetOrEnqueue(key, local2, queueSide);
        }

        private TValue GetOrEnqueueWhileLocked(TKey key, TValue value, QueueSide queueSide)
        {
            int num;
            if (this.keyToDequeIndexMap.TryGetValue(key, out num))
            {
                return this.deque.GetValue(num).Value;
            }
            if (!this.TryEnqueueWhileLocked(key, value, queueSide))
            {
                ExceptionUtil.ThrowInternalErrorException();
            }
            return value;
        }

        public bool TryDequeue(out KeyValuePair<TKey, TValue> item) => 
            this.TryDequeue(out item, QueueSide.Front);

        public bool TryDequeue(out KeyValuePair<TKey, TValue> item, QueueSide queueSide)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.TryDequeueWhileLocked(out item, queueSide);
            }
        }

        private bool TryDequeueWhileLocked(out KeyValuePair<TKey, TValue> item, QueueSide queueSide)
        {
            LinkedArrayNode<KeyValuePair<TKey, TValue>> first;
            if (!this.deque.Any())
            {
                item = new KeyValuePair<TKey, TValue>();
                return false;
            }
            if (queueSide != QueueSide.Back)
            {
                if (queueSide != QueueSide.Front)
                {
                    throw ExceptionUtil.InvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
                }
            }
            else
            {
                first = this.deque.Last;
                goto Label_0047;
            }
            first = this.deque.First;
        Label_0047:
            item = first.Value;
            this.deque.RemoveAt(first.Index);
            this.keyToDequeIndexMap.Remove(item.Key);
            return true;
        }

        public bool TryEnqueue(TKey key, TValue value) => 
            this.TryEnqueue(key, value, QueueSide.Back);

        public bool TryEnqueue(TKey key, TValue value, QueueSide queueSide)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.TryEnqueueWhileLocked(key, value, queueSide);
            }
        }

        private bool TryEnqueueWhileLocked(TKey key, TValue value, QueueSide queueSide)
        {
            int num;
            if (this.keyToDequeIndexMap.ContainsKey(key))
            {
                return false;
            }
            KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
            if (queueSide != QueueSide.Back)
            {
                if (queueSide != QueueSide.Front)
                {
                    throw new InternalErrorException();
                }
            }
            else
            {
                num = this.deque.AddLast(pair);
                goto Label_0046;
            }
            num = this.deque.AddFirst(pair);
        Label_0046:
            this.keyToDequeIndexMap.Add(key, num);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.TryGetValueWhileLocked(key, out value);
            }
        }

        private bool TryGetValueWhileLocked(TKey key, out TValue value)
        {
            int num;
            if (this.keyToDequeIndexMap.TryGetValue(key, out num))
            {
                value = this.deque.GetValue(num).Value;
                return true;
            }
            value = default(TValue);
            return false;
        }

        public bool TryRemove(TKey key, out TValue value)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.TryRemoveWhileLocked(key, out value);
            }
        }

        private bool TryRemoveWhileLocked(TKey key, out TValue value)
        {
            int num;
            if (this.keyToDequeIndexMap.TryGetValue(key, out num))
            {
                this.keyToDequeIndexMap.Remove(key);
                value = this.deque.GetValue(num).Value;
                this.deque.RemoveAt(num);
                return true;
            }
            value = default(TValue);
            return false;
        }

        public bool TryUpdate(TKey key, TValue newValue)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.TryUpdateWhileLocked(key, newValue);
            }
        }

        public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.TryUpdateWhileLocked(key, newValue, comparisonValue);
            }
        }

        private bool TryUpdateWhileLocked(TKey key, TValue newValue)
        {
            int num;
            if (!this.keyToDequeIndexMap.TryGetValue(key, out num))
            {
                return false;
            }
            TValue local1 = this.deque.GetValue(num).Value;
            this.deque.SetValue(num, new KeyValuePair<TKey, TValue>(key, newValue));
            return true;
        }

        private bool TryUpdateWhileLocked(TKey key, TValue newValue, TValue comparisonValue)
        {
            int num;
            if (!this.keyToDequeIndexMap.TryGetValue(key, out num))
            {
                return false;
            }
            TValue x = this.deque.GetValue(num).Value;
            if (!this.valueComparer.Equals(x, comparisonValue))
            {
                return false;
            }
            this.deque.SetValue(num, new KeyValuePair<TKey, TValue>(key, newValue));
            return true;
        }

        public int Count
        {
            get
            {
                object sync = this.sync;
                lock (sync)
                {
                    return this.deque.Count;
                }
            }
        }
    }
}

