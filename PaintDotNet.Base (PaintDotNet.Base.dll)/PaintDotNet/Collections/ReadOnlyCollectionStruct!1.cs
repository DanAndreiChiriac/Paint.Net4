namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ReadOnlyCollectionStruct<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        private ReadOnlyCollection<T> source;
        public ReadOnlyCollection<T> Source =>
            this.source;
        public ReadOnlyCollectionStruct(ReadOnlyCollection<T> source)
        {
            Validate.IsNotNull<ReadOnlyCollection<T>>(source, "source");
            this.source = source;
        }

        public int IndexOf(T item) => 
            this.source.IndexOf(item);

        void IList<T>.Insert(int index, T item)
        {
            throw new ReadOnlyException();
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new ReadOnlyException();
        }

        public T this[int index]
        {
            get => 
                this.source[index];
            set
            {
                throw new ReadOnlyException();
            }
        }
        void ICollection<T>.Add(T item)
        {
            throw new ReadOnlyException();
        }

        void ICollection<T>.Clear()
        {
            throw new ReadOnlyException();
        }

        public bool Contains(T item) => 
            this.source.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.source.CopyTo(array, arrayIndex);
        }

        public int Count =>
            this.source.Count;
        public bool IsReadOnly =>
            true;
        bool ICollection<T>.Remove(T item)
        {
            throw new ReadOnlyException();
        }

        public IEnumerator<T> GetEnumerator() => 
            this.source.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.source.GetEnumerator();
    }
}

