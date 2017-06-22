namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public sealed class FuncList<T, TCountProvider, TValueProvider> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where TCountProvider: IFunc<int> where TValueProvider: IFunc<int, T>
    {
        private TCountProvider countProvider;
        private static readonly EqualityComparer<T> equalityComparer;
        private TValueProvider valueProvider;

        static FuncList()
        {
            FuncList<T, TCountProvider, TValueProvider>.equalityComparer = EqualityComparer<T>.Default;
        }

        public FuncList(TCountProvider countProvider, TValueProvider valueProvider)
        {
            this.countProvider = countProvider;
            this.valueProvider = valueProvider;
        }

        public void Add(T item)
        {
            throw new ReadOnlyException();
        }

        private bool CheckIndex(int index) => 
            ((index >= 0) && (index < this.Count));

        public void Clear()
        {
            throw new ReadOnlyException();
        }

        public bool Contains(T item) => 
            (this.IndexOf(item) != -1);

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < (arrayIndex + this.Count); i++)
            {
                array[i] = this[i - arrayIndex];
            }
        }

        public Enumerator<T, TCountProvider, TValueProvider> GetEnumerator() => 
            new Enumerator<T, TCountProvider, TValueProvider>((FuncList<T, TCountProvider, TValueProvider>) this);

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (FuncList<T, TCountProvider, TValueProvider>.equalityComparer.Equals(this[i], item))
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
            this.countProvider.Invoke();

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
            private FuncList<T, TCountProvider, TValueProvider> list;
            private int index;
            private T current;
            internal Enumerator(FuncList<T, TCountProvider, TValueProvider> list)
            {
                Validate.IsNotNull<FuncList<T, TCountProvider, TValueProvider>>(list, "list");
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
                    if (this.index < this.list.Count)
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

