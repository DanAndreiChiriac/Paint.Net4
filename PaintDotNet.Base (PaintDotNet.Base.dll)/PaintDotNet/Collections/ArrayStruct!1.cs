namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ArrayStruct<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        private T[] array;
        public ArrayStruct(T[] array)
        {
            Validate.IsNotNull<T[]>(array, "array");
            this.array = array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) => 
            Array.IndexOf<T>(this.array, item);

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.array[index];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.array[index] = value;
            }
        }
        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item) => 
            (this.IndexOf(item) != -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.array.CopyTo(array, arrayIndex);
        }

        public int Count =>
            this.array.Length;
        public bool IsReadOnly =>
            false;
        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>(this.array);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();
        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private T[] array;
            private int index;
            public Enumerator(T[] array)
            {
                this.array = array;
                this.index = -1;
            }

            public T Current =>
                this.array[this.index];
            public void Dispose()
            {
                this.array = null;
                this.index = -1;
            }

            object IEnumerator.Current =>
                this.Current;
            public bool MoveNext()
            {
                if (this.index == this.array.Length)
                {
                    return false;
                }
                this.index++;
                if (this.index == this.array.Length)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }
    }
}

