namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal sealed class UnsafeReadOnlyListAdapter<T, TAccessor> : IUnsafeElementList<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, IToArray<T> where T: struct where TAccessor: IUnsafeElementAccessor<T>
    {
        private TAccessor accessor;
        private int count;
        private unsafe void* pList;
        private int sizeOfT;

        public unsafe UnsafeReadOnlyListAdapter(void* pList, int count, TAccessor accessor)
        {
            Validate.Begin().IsNotNull(pList, "pList").IsNotNegative(count, "count").IsNotNullIfRefType<TAccessor>(ref accessor, "accessor").Check();
            this.pList = pList;
            this.count = count;
            this.accessor = accessor;
            this.sizeOfT = accessor.SizeOfElement;
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

        public unsafe void CopyTo(T[] array, int arrayIndex)
        {
            this.accessor.CopyElements(array, arrayIndex, this.pList, this.count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe void* GetAddressAt(int index) => 
            (this.pList + (index * this.sizeOfT));

        public Enumerator<T, TAccessor> GetEnumerator() => 
            new Enumerator<T, TAccessor>((UnsafeReadOnlyListAdapter<T, TAccessor>) this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetUnchecked(int index) => 
            this.accessor.ReadElement(this.GetAddressAt(index));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item) => 
            this.IndexOf<T>(item);

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public unsafe T[] ToArray()
        {
            if (this.count == 0)
            {
                return Array.Empty<T>();
            }
            T[] dst = new T[this.count];
            this.accessor.CopyElements(dst, 0, this.pList, this.count);
            return dst;
        }

        public TAccessor Accessor =>
            this.accessor;

        public void* Buffer =>
            this.pList;

        public int Count =>
            this.count;

        public bool IsReadOnly =>
            true;

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if ((index < 0) || (index >= this.count))
                {
                    ExceptionUtil.ThrowArgumentOutOfRangeException();
                }
                return this.GetUnchecked(index);
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        IUnsafeElementAccessor<T> IUnsafeElementList<T>.Accessor =>
            this.accessor;

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private UnsafeReadOnlyListAdapter<T, TAccessor> source;
            private int index;
            public T Current =>
                this.source[this.index];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(UnsafeReadOnlyListAdapter<T, TAccessor> source)
            {
                this.source = Validate.IsNotNull<UnsafeReadOnlyListAdapter<T, TAccessor>>(source, "source");
                this.index = -1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose()
            {
                this.source = null;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                if ((this.index + 1) >= this.source.count)
                {
                    return false;
                }
                this.index++;
                return true;
            }

            void IEnumerator.Reset()
            {
                throw new NotImplementedException();
            }

            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}

