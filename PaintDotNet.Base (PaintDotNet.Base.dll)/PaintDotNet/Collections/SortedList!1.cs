namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class SortedList<T> : IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, ICollection<T>, ITrimExcess, IToArray<T>
    {
        private readonly IComparer<T> comparer;
        private readonly List<T> list;

        public SortedList() : this(null)
        {
        }

        public SortedList(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            this.list = new List<T>();
        }

        public int Add(T value)
        {
            int index = ListUtil.BinarySearch<T, ListStruct<T>, IComparer<T>>(new ListStruct<T>(this.list), value, this.comparer);
            if (index < 0)
            {
                this.list.Insert(~index, value);
                return ~index;
            }
            this.list.Insert(index, value);
            return index;
        }

        public bool Any() => 
            (this.list.Count > 0);

        public int AnyIndexOf(T value)
        {
            int num = ListUtil.BinarySearch<T, ListStruct<T>, IComparer<T>>(new ListStruct<T>(this.list), value, this.comparer);
            if (num < 0)
            {
                return -1;
            }
            return num;
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(T item) => 
            (this.AnyIndexOf(item) != -1);

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public T First() => 
            this.list[0];

        public int FirstIndexOf(T value)
        {
            int num = this.AnyIndexOf(value);
            if (num == -1)
            {
                return -1;
            }
            num--;
            while ((num >= 0) && (this.comparer.Compare(value, this.list[num]) == 0))
            {
                num--;
            }
            return (num + 1);
        }

        public IEnumerator<T> GetEnumerator() => 
            this.list.GetEnumerator();

        public T Last() => 
            this.list[this.list.Count - 1];

        public T Max() => 
            this.list[this.list.Count - 1];

        public T Min() => 
            this.list[0];

        public bool RemoveAny(T value)
        {
            int index = this.AnyIndexOf(value);
            if (index == -1)
            {
                return false;
            }
            this.list.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        public bool RemoveFirst(T value)
        {
            int index = this.FirstIndexOf(value);
            if (index == -1)
            {
                return false;
            }
            this.list.RemoveAt(index);
            return true;
        }

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        bool ICollection<T>.Remove(T item) => 
            this.RemoveAny(item);

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public T[] ToArray() => 
            this.list.ToArrayEx<T>();

        public void TrimExcess()
        {
            this.list.TrimExcess();
        }

        public int Capacity =>
            this.list.Capacity;

        public int Count =>
            this.list.Count;

        public bool IsReadOnly =>
            false;

        public T this[int index] =>
            this.list[index];
    }
}

