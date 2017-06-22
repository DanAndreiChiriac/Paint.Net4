namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public sealed class LazyResultList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        private IList<LazyResult<T>> source;
        private ReadOnlyCollection<LazyResult<T>> sourceRO;

        public LazyResultList(IList<LazyResult<T>> source)
        {
            Validate.IsNotNull<IList<LazyResult<T>>>(source, "source");
            this.source = source;
            this.sourceRO = new ReadOnlyCollection<LazyResult<T>>(this.source);
        }

        public IEnumerator<T> GetEnumerator() => 
            this.source.Select<LazyResult<T>, T>(lr => lr.Value).GetEnumerator();

        void ICollection<T>.Add(T item)
        {
            throw new NotSupportedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            for (int i = 0; i < this.source.Count; i++)
            {
                if (this.source[i].IsValue && this.source[i].Value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < this.source.Count; i++)
            {
                array[i + arrayIndex] = this.source[i].Value;
            }
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        int IList<T>.IndexOf(T item)
        {
            for (int i = 0; i < this.source.Count; i++)
            {
                if (this.source[i].IsValue && this.source[i].Value.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public int Count =>
            this.source.Count;

        public bool IsReadOnly =>
            true;

        public T this[int index]
        {
            get => 
                this.source[index].Value;
            set
            {
                throw new NotSupportedException();
            }
        }

        public ReadOnlyCollection<LazyResult<T>> Source =>
            this.sourceRO;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly LazyResultList<T>.<>c <>9;
            public static Func<LazyResult<T>, T> <>9__20_0;

            static <>c()
            {
                LazyResultList<T>.<>c.<>9 = new LazyResultList<T>.<>c();
            }

            internal T <GetEnumerator>b__20_0(LazyResult<T> lr) => 
                lr.Value;
        }
    }
}

