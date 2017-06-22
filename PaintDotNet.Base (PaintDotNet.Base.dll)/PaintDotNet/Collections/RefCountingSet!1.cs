namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed class RefCountingSet<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        private static readonly EqualityComparer<T> comparer;
        private Dictionary<T, int> itemToRefCountMap;

        static RefCountingSet()
        {
            RefCountingSet<T>.comparer = EqualityComparer<T>.Default;
        }

        public RefCountingSet()
        {
            this.itemToRefCountMap = new Dictionary<T, int>(RefCountingSet<T>.comparer);
        }

        public bool Add(T item)
        {
            int num;
            if (!this.itemToRefCountMap.TryGetValue(item, out num))
            {
                this.itemToRefCountMap.Add(item, 1);
                return true;
            }
            num++;
            this.itemToRefCountMap[item] = num;
            return false;
        }

        public void Clear()
        {
            this.itemToRefCountMap.Clear();
        }

        public bool Contains(T item) => 
            this.itemToRefCountMap.ContainsKey(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.itemToRefCountMap.Keys.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => 
            this.itemToRefCountMap.Keys.GetEnumerator();

        public int GetRefCount(T item)
        {
            int num;
            if (!this.itemToRefCountMap.TryGetValue(item, out num))
            {
                return 0;
            }
            return num;
        }

        public bool Release(T item)
        {
            int num;
            if (this.itemToRefCountMap.TryGetValue(item, out num))
            {
                num--;
                if (num == 0)
                {
                    this.itemToRefCountMap.Remove(item);
                    return true;
                }
                this.itemToRefCountMap[item] = num;
            }
            return false;
        }

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        bool ICollection<T>.Remove(T item) => 
            this.Release(item);

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public int Count =>
            this.itemToRefCountMap.Count;

        public bool IsReadOnly =>
            false;
    }
}

