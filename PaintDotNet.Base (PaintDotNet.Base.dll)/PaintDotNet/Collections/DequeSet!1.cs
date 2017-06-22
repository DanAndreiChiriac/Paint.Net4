namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;

    public sealed class DequeSet<T> : IEnumerable<T>, IEnumerable, ICollection<T>, IReadOnlyCollection<T>, ICollection
    {
        private LinkedArray<T> deque;
        private Dictionary<T, int> itemToDequeIndex;
        private const int maxFreeNodeCount = 8;
        private object sync;

        public DequeSet()
        {
            this.deque = new LinkedArray<T>();
            this.itemToDequeIndex = new Dictionary<T, int>();
        }

        public DequeSet(IEnumerable<T> items) : this()
        {
            this.EnqueueRange(items);
        }

        public void Add(T item)
        {
            this.TryEnqueue(item);
        }

        public bool Any() => 
            (this.deque.Count > 0);

        public void Clear()
        {
            this.deque.Clear();
            this.itemToDequeIndex.Clear();
        }

        public bool Contains(T item) => 
            this.itemToDequeIndex.ContainsKey(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            int num = 0;
            foreach (T local in this)
            {
                array[arrayIndex + num] = local;
                num++;
            }
        }

        public T Dequeue()
        {
            if (!this.deque.Any())
            {
                ExceptionUtil.ThrowInvalidOperationException("Deque is empty");
                return default(T);
            }
            LinkedArrayNode<T> first = this.deque.First;
            T key = first.Value;
            this.deque.RemoveAt(first.Index);
            this.itemToDequeIndex.Remove(key);
            return key;
        }

        public void EnqueueRange(IEnumerable<T> items)
        {
            this.EnqueueRange(items, QueueSide.Back);
        }

        public void EnqueueRange(IEnumerable<T> items, QueueSide queueSide)
        {
            foreach (T local in items)
            {
                this.TryEnqueue(local, queueSide);
            }
        }

        public IEnumerator<T> GetEnumerator() => 
            this.deque.GetEnumerator();

        public bool Remove(T item)
        {
            int num;
            if (this.itemToDequeIndex.TryGetValue(item, out num))
            {
                this.itemToDequeIndex.Remove(item);
                this.deque.RemoveAt(num);
                return true;
            }
            return false;
        }

        void ICollection.CopyTo(Array array, int index)
        {
            int num = 0;
            foreach (T local in this)
            {
                array.SetValue(local, (int) (index + num));
                num++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public bool TryDequeue(out T item)
        {
            if (!this.deque.Any())
            {
                item = default(T);
                return false;
            }
            item = this.Dequeue();
            return true;
        }

        public bool TryEnqueue(T item) => 
            this.TryEnqueue(item, QueueSide.Back);

        public bool TryEnqueue(T item, QueueSide queueSide)
        {
            int num;
            if (this.itemToDequeIndex.ContainsKey(item))
            {
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
                num = this.deque.AddLast(item);
                goto Label_0043;
            }
            num = this.deque.AddFirst(item);
        Label_0043:
            this.itemToDequeIndex.Add(item, num);
            return true;
        }

        public int Count =>
            this.deque.Count;

        public bool IsReadOnly =>
            false;

        bool ICollection.IsSynchronized =>
            false;

        object ICollection.SyncRoot
        {
            get
            {
                if (this.sync == null)
                {
                    Interlocked.CompareExchange(ref this.sync, new object(), null);
                }
                return this.sync;
            }
        }
    }
}

