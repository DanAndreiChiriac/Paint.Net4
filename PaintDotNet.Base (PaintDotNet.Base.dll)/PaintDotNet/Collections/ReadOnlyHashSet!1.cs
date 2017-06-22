namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed class ReadOnlyHashSet<T> : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        private readonly HashSet<T> source;

        public ReadOnlyHashSet(ReadOnlyHashSet<T> source)
        {
            Validate.IsNotNull<ReadOnlyHashSet<T>>(source, "source");
            this.source = source.source;
        }

        public ReadOnlyHashSet(HashSet<T> source)
        {
            Validate.IsNotNull<HashSet<T>>(source, "source");
            this.source = source;
        }

        public bool Contains(T item) => 
            this.source.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.source.CopyTo(array, arrayIndex);
        }

        public HashSet<T>.Enumerator GetEnumerator() => 
            this.source.GetEnumerator();

        public bool IsProperSubsetOf(IEnumerable<T> other) => 
            this.source.IsProperSubsetOf(other);

        public bool IsProperSupersetOf(IEnumerable<T> other) => 
            this.source.IsProperSupersetOf(other);

        public bool IsSubsetOf(IEnumerable<T> other) => 
            this.source.IsSubsetOf(other);

        public bool IsSupersetOf(IEnumerable<T> other) => 
            this.source.IsSupersetOf(other);

        public bool Overlaps(IEnumerable<T> other) => 
            this.source.Overlaps(other);

        public bool SetEquals(IEnumerable<T> other) => 
            this.source.SetEquals(other);

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

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.source.GetEnumerator();

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
    }
}

