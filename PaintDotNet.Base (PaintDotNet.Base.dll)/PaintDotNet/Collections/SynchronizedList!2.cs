namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public class SynchronizedList<T, TList> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T> where TList: IList<T>
    {
        private TList source;
        private object sync;

        public SynchronizedList(TList source, object sync)
        {
            Validate.Begin().IsNotNullIfRefType<TList>(ref source, "source").IsNotNull<object>(sync, "sync").Check();
            this.source = source;
            this.sync = new object();
        }

        public void Add(T item)
        {
            object sync = this.sync;
            lock (sync)
            {
                this.source.Add(item);
            }
        }

        public void Clear()
        {
            object sync = this.sync;
            lock (sync)
            {
                this.source.Clear();
            }
        }

        public bool Contains(T item)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.source.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            object sync = this.sync;
            lock (sync)
            {
                this.source.CopyTo(array, arrayIndex);
            }
        }

        public SynchronizedEnumerator<T> GetEnumerator()
        {
            List<T> source = this.source as List<T>;
            if (source != null)
            {
                return new SynchronizedEnumerator<T, List<T>.Enumerator>(this.sync, source.GetEnumerator());
            }
            SegmentedList<T> list2 = this.source as SegmentedList<T>;
            if (list2 != null)
            {
                return new SynchronizedEnumerator<T, SegmentedList<T>.Enumerator>(this.sync, list2.GetEnumerator());
            }
            SparseList<T> list3 = this.source as SparseList<T>;
            if (list3 != null)
            {
                return new SynchronizedEnumerator<T, SparseList<T>.Enumerator>(this.sync, list3.GetEnumerator());
            }
            return new SynchronizedEnumerator<T, IEnumerator<T>>(this.sync, this.source.GetEnumerator());
        }

        public int IndexOf(T item)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.source.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            object sync = this.sync;
            lock (sync)
            {
                this.source.Insert(index, item);
            }
        }

        public bool Remove(T item)
        {
            object sync = this.sync;
            lock (sync)
            {
                return this.source.Remove(item);
            }
        }

        public void RemoveAt(int index)
        {
            object sync = this.sync;
            lock (sync)
            {
                this.source.RemoveAt(index);
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public int Count
        {
            get
            {
                object sync = this.sync;
                lock (sync)
                {
                    return this.source.Count;
                }
            }
        }

        public bool IsReadOnly
        {
            get
            {
                object sync = this.sync;
                lock (sync)
                {
                    return this.source.IsReadOnly;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                object sync = this.sync;
                lock (sync)
                {
                    return this.source[index];
                }
            }
            set
            {
                object sync = this.sync;
                lock (sync)
                {
                    this.source[index] = value;
                }
            }
        }

        public object Sync =>
            this.sync;
    }
}

