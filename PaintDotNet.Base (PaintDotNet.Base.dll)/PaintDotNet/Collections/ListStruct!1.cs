namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ListStruct<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, IToArray<T>
    {
        private List<T> source;
        public ListStruct(List<T> source)
        {
            this.source = source;
        }

        public List<T> Source =>
            this.source;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) => 
            this.source.IndexOf(item);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Insert(int index, T item)
        {
            this.source.Insert(index, item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index)
        {
            this.source.RemoveAt(index);
        }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.source[index];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.source[index] = value;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            this.source.Add(item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            this.source.Clear();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) => 
            this.source.Contains(item);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.source.CopyTo(array, arrayIndex);
        }

        public int Count =>
            this.source.Count;
        public bool IsReadOnly =>
            this.source.IsReadOnly;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Remove(T item) => 
            this.source.Remove(item);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T[] ToArray() => 
            this.source.ToArrayEx<T>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public List<T>.Enumerator GetEnumerator() => 
            this.source.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();
    }
}

