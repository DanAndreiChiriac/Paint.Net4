namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class CastingListAdapter<TInternal, TExternal, TToExternal, TToInternal> : IList<TExternal>, ICollection<TExternal>, IEnumerable<TExternal>, IEnumerable, IReadOnlyList<TExternal>, IReadOnlyCollection<TExternal> where TToExternal: struct, IFunc<TInternal, TExternal> where TToInternal: struct, IFunc<TExternal, TInternal>
    {
        private IList<TInternal> internalList;
        private TToExternal toExternal;
        private TToInternal toInternal;

        public CastingListAdapter(IList<TInternal> internalList, TToExternal toExternal, TToInternal toInternal)
        {
            Validate.IsNotNull<IList<TInternal>>(internalList, "internalList");
            this.internalList = internalList;
            this.toExternal = toExternal;
            this.toInternal = toInternal;
        }

        public void Add(TExternal item)
        {
            this.internalList.Add(this.toInternal.Invoke(item));
        }

        public void Clear()
        {
            this.internalList.Clear();
        }

        public bool Contains(TExternal item) => 
            this.internalList.Contains(this.toInternal.Invoke(item));

        public void CopyTo(TExternal[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TExternal> GetEnumerator() => 
            this.internalList.Select<TInternal, TExternal>(x => this.toExternal.Invoke(x)).GetEnumerator();

        public int IndexOf(TExternal item) => 
            this.internalList.IndexOf(this.toInternal.Invoke(item));

        public void Insert(int index, TExternal item)
        {
            this.internalList.Insert(index, this.toInternal.Invoke(item));
        }

        public bool Remove(TExternal item) => 
            this.internalList.Remove(this.toInternal.Invoke(item));

        public void RemoveAt(int index)
        {
            this.internalList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public int Count =>
            this.internalList.Count;

        public bool IsReadOnly =>
            this.internalList.IsReadOnly;

        public TExternal this[int index]
        {
            get => 
                this.toExternal.Invoke(this.internalList[index]);
            set
            {
                this.internalList[index] = this.toInternal.Invoke(value);
            }
        }
    }
}

