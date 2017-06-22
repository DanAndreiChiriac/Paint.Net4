namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    public sealed class ConcurrentDequeSet<T>
    {
        private DequeSet<T> dequeSet;

        public ConcurrentDequeSet()
        {
            this.dequeSet = new DequeSet<T>();
        }

        public bool Any() => 
            (this.Count > 0);

        public bool Contains(T item)
        {
            object sync = this.Sync;
            lock (sync)
            {
                return this.dequeSet.Contains(item);
            }
        }

        public bool TryDequeue(out T item)
        {
            object sync = this.Sync;
            lock (sync)
            {
                if (!this.dequeSet.Any())
                {
                    item = default(T);
                    return false;
                }
                item = this.dequeSet.Dequeue();
                return true;
            }
        }

        public bool TryEnqueue(T item) => 
            this.TryEnqueue(item, QueueSide.Back);

        public bool TryEnqueue(T item, QueueSide queueSide)
        {
            if ((queueSide != QueueSide.Back) && (queueSide != QueueSide.Front))
            {
                ExceptionUtil.ThrowInvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
            }
            object sync = this.Sync;
            lock (sync)
            {
                return this.dequeSet.TryEnqueue(item, queueSide);
            }
        }

        public bool TryRemove(T item)
        {
            object sync = this.Sync;
            lock (sync)
            {
                return this.dequeSet.Remove(item);
            }
        }

        public int Count
        {
            get
            {
                object sync = this.Sync;
                lock (sync)
                {
                    return this.dequeSet.Count;
                }
            }
        }

        public object Sync =>
            this.dequeSet;
    }
}

