namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class ReadOnlyIndexedList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, ISet<T>
    {
        private IList<T> source;
        private HashSet<T> values;

        public ReadOnlyIndexedList(IList<T> source) : this(source, EqualityComparer<T>.Default)
        {
        }

        public ReadOnlyIndexedList(IList<T> source, IEqualityComparer<T> equalityComparer)
        {
            Validate.IsNotNull<IList<T>>(source, "source");
            this.source = source;
            this.values = new HashSet<T>(source, equalityComparer);
        }

        public bool Contains(T item) => 
            this.values.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.source.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => 
            this.source.GetEnumerator();

        public int IndexOf(T item) => 
            this.source.IndexOf(item);

        public bool IsProperSubsetOf(IEnumerable<T> other) => 
            this.values.IsProperSubsetOf(other);

        public bool IsProperSupersetOf(IEnumerable<T> other) => 
            this.values.IsProperSupersetOf(other);

        public bool IsSubsetOf(IEnumerable<T> other) => 
            this.values.IsSubsetOf(other);

        public bool IsSupersetOf(IEnumerable<T> other) => 
            this.values.IsSupersetOf(other);

        public bool Overlaps(IEnumerable<T> other) => 
            this.values.Overlaps(other);

        public bool SetEquals(IEnumerable<T> other) => 
            this.values.SetEquals(other);

        void ICollection<T>.Add(T item)
        {
            throw new ReadOnlyException();
        }

        void ICollection<T>.Clear()
        {
            throw new ReadOnlyException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new ReadOnlyException();
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new ReadOnlyException();
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new ReadOnlyException();
        }

        bool ISet<T>.Add(T item)
        {
            throw new ReadOnlyException();
        }

        void ISet<T>.ExceptWith(IEnumerable<T> other)
        {
            throw new ReadOnlyException();
        }

        void ISet<T>.IntersectWith(IEnumerable<T> other)
        {
            throw new ReadOnlyException();
        }

        void ISet<T>.SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new ReadOnlyException();
        }

        void ISet<T>.UnionWith(IEnumerable<T> other)
        {
            throw new ReadOnlyException();
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.source.GetEnumerator();

        public int Count =>
            this.source.Count;

        public bool IsReadOnly =>
            true;

        public T this[int index]
        {
            get => 
                this.source[index];
            set
            {
                throw new ReadOnlyException();
            }
        }
    }
}

