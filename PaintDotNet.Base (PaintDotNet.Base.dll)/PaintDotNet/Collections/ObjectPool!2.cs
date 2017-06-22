namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public sealed class ObjectPool<TKey, TValue> : IDisposable, IIsDisposed
    {
        private Action<TKey, TValue> disposeValueCallback;
        private Dictionary<TKey, SparseQueue<TValue>> pools;
        private object sync;
        private Func<TKey, TValue> valueFactory;

        public ObjectPool(Func<TKey, TValue> valueFactory) : this(valueFactory, null)
        {
        }

        public ObjectPool(Func<TKey, TValue> valueFactory, Action<TKey, TValue> disposeValueCallback)
        {
            this.sync = new object();
            Validate.IsNotNull<Func<TKey, TValue>>(valueFactory, "valueFactory");
            this.pools = new Dictionary<TKey, SparseQueue<TValue>>();
            this.valueFactory = valueFactory;
            this.disposeValueCallback = (disposeValueCallback == null) ? delegate (TKey k, TValue v) {
            } : disposeValueCallback;
        }

        public void Clear()
        {
            Dictionary<TKey, SparseQueue<TValue>> pools;
            object sync = this.sync;
            lock (sync)
            {
                pools = this.pools;
                this.pools = new Dictionary<TKey, SparseQueue<TValue>>();
            }
            ObjectPool<TKey, TValue>.Clear(pools, this.disposeValueCallback);
        }

        private static void Clear(Dictionary<TKey, SparseQueue<TValue>> pools, Action<TKey, TValue> disposeValueCallback)
        {
            foreach (KeyValuePair<TKey, SparseQueue<TValue>> pair in pools)
            {
                SparseQueue<TValue> queue = pair.Value;
                foreach (TValue local in queue)
                {
                    disposeValueCallback(pair.Key, local);
                }
                queue.Clear();
                queue.TrimExcess();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                Dictionary<TKey, SparseQueue<TValue>> pools;
                object sync = this.sync;
                lock (sync)
                {
                    pools = this.pools;
                    this.pools = null;
                }
                if (pools != null)
                {
                    ObjectPool<TKey, TValue>.Clear(pools, this.disposeValueCallback);
                }
            }
        }

        public ObjectPoolTicket<TValue> Get(TKey key)
        {
            object sync = this.sync;
            lock (sync)
            {
                SparseQueue<TValue> queue;
                if (!this.pools.TryGetValue(key, out queue))
                {
                    queue = new SparseQueue<TValue>();
                    this.pools.Add(key, queue);
                }
                if (queue.Any<TValue>())
                {
                    return new Ticket<TKey, TValue>((ObjectPool<TKey, TValue>) this, key, queue.Dequeue());
                }
            }
            return new Ticket<TKey, TValue>((ObjectPool<TKey, TValue>) this, key, this.valueFactory(key));
        }

        private void Return(TKey key, TValue value)
        {
            object sync = this.sync;
            lock (sync)
            {
                if (this.IsDisposed)
                {
                    this.disposeValueCallback(key, value);
                }
                else
                {
                    SparseQueue<TValue> queue;
                    if (!this.pools.TryGetValue(key, out queue))
                    {
                        queue = new SparseQueue<TValue>();
                        this.pools.Add(key, queue);
                    }
                    queue.Enqueue(value);
                }
            }
        }

        public void TrimExcess()
        {
            SegmentedList<KeyValuePair<TKey, SparseQueue<TValue>>> list = null;
            object sync = this.sync;
            lock (sync)
            {
                foreach (KeyValuePair<TKey, SparseQueue<TValue>> pair in this.pools)
                {
                    SparseQueue<TValue> collection = pair.Value;
                    if (collection.Any<TValue>())
                    {
                        collection.TrimExcess();
                    }
                    else
                    {
                        if (list == null)
                        {
                            list = new SegmentedList<KeyValuePair<TKey, SparseQueue<TValue>>>();
                        }
                        list.Add(pair);
                    }
                }
                if (list != null)
                {
                    foreach (KeyValuePair<TKey, SparseQueue<TValue>> pair2 in list)
                    {
                        this.pools.Remove(pair2.Key);
                    }
                }
            }
            foreach (KeyValuePair<TKey, SparseQueue<TValue>> pair3 in list)
            {
                pair3.Value.TrimExcess();
            }
        }

        public bool IsDisposed
        {
            get
            {
                object sync = this.sync;
                lock (sync)
                {
                    return (this.pools == null);
                }
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ObjectPool<TKey, TValue>.<>c <>9;
            public static Action<TKey, TValue> <>9__7_0;

            static <>c()
            {
                ObjectPool<TKey, TValue>.<>c.<>9 = new ObjectPool<TKey, TValue>.<>c();
            }

            internal void <.ctor>b__7_0(TKey k, TValue v)
            {
            }
        }

        private sealed class Ticket : ObjectPoolTicket<TValue>
        {
            private TKey key;
            private ObjectPool<TKey, TValue> owner;

            internal Ticket(ObjectPool<TKey, TValue> owner, TKey key, TValue value) : base(value)
            {
                this.owner = owner;
                this.key = key;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing && (this.owner != null))
                {
                    this.owner.Return(this.key, base.Value);
                }
                this.owner = null;
                this.key = default(TKey);
            }

            public TKey Key =>
                this.key;
        }
    }
}

