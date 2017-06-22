namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public sealed class FuncList<T, TValueProvider> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where TValueProvider: IFunc<int, T>
    {
        private int count;
        private static readonly EqualityComparer<T> equalityComparer;
        private TValueProvider valueProvider;

        static FuncList()
        {
            FuncList<T, TValueProvider>.equalityComparer = EqualityComparer<T>.Default;
        }

        public FuncList(int count, TValueProvider valueProvider)
        {
            Validate.Begin().IsNotNegative(count, "count").Check();
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

        public Enumerator<T, TValueProvider> GetEnumerator() => 
            new Enumerator<T, TValueProvider>((FuncList<T, TValueProvider>) this);

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (FuncList<T, TValueProvider>.equalityComparer.Equals(this[i], item))
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
                return this.valueProvider.Invoke(index);
            }
            set
            {
                throw new ReadOnlyException();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private FuncList<T, TValueProvider> list;
            private int index;
            private T current;
            internal Enumerator(FuncList<T, TValueProvider> list)
            {
                Validate.IsNotNull<FuncList<T, TValueProvider>>(list, "list");
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

