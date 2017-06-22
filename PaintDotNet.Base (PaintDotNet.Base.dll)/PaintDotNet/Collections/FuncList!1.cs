namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public sealed class FuncList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IToArray<T>
    {
        private int count;
        private static readonly EqualityComparer<T> equalityComparer;
        private Func<int, T> valueProvider;

        static FuncList()
        {
            FuncList<T>.equalityComparer = EqualityComparer<T>.Default;
        }

        public FuncList(int count, Func<int, T> valueProvider)
        {
            Validate.Begin().IsNotNegative(count, "count").IsNotNull<Func<int, T>>(valueProvider, "valueProvider").Check();
            this.count = count;
            this.valueProvider = valueProvider;
        }

        public void Add(T item)
        {
            throw new ReadOnlyException();
        }

        private bool CheckIndex(int index) => 
            ((index >= 0) && (index < this.count));

        public void Clear()
        {
            throw new ReadOnlyException();
        }

        public bool Contains(T item) => 
            (this.IndexOf(item) != -1);

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < (arrayIndex + this.count); i++)
            {
                array[i] = this[i - arrayIndex];
            }
        }

        public Enumerator<T> GetEnumerator() => 
            new Enumerator<T>((FuncList<T>) this);

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (FuncList<T>.equalityComparer.Equals(this[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new ReadOnlyException();
        }

        public bool Remove(T item)
        {
            throw new ReadOnlyException();
        }

        public void RemoveAt(int index)
        {
            throw new ReadOnlyException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public T[] ToArray()
        {
            int count = this.Count;
            if (count == 0)
            {
                return Array.Empty<T>();
            }
            T[] localArray = new T[count];
            for (int i = 0; i < count; i++)
            {
                localArray[i] = this.valueProvider(i);
            }
            return localArray;
        }

        private void VerifyIndex(int index)
        {
            if (!this.CheckIndex(index))
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int Count =>
            this.count;

        public bool IsReadOnly =>
            true;

        public T this[int index]
        {
            get
            {
                this.VerifyIndex(index);
                return this.valueProvider(index);
            }
            set
            {
                throw new ReadOnlyException();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private FuncList<T> list;
            private int index;
            private T current;
            internal Enumerator(FuncList<T> list)
            {
                Validate.IsNotNull<FuncList<T>>(list, "list");
                this.list = list;
                this.index = -1;
                this.current = default(T);
            }

            public T Current =>
                this.current;
            public void Dispose()
            {
                this.list = null;
                this.current = default(T);
            }

            object IEnumerator.Current =>
                this.Current;
            public bool MoveNext()
            {
                if (this.index != this.list.Count)
                {
                    if (this.list.Count == 0)
                    {
                        return false;
                    }
                    this.index++;
                    if (this.index < this.list.count)
                    {
                        this.current = this.list[this.index];
                        return true;
                    }
                    this.current = default(T);
                }
                return false;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }
        }
    }
}

