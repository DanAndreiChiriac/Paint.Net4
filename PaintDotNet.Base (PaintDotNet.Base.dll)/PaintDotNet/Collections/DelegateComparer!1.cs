namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;

    public sealed class DelegateComparer<T> : IComparer<T>
    {
        private Func<T, T, int> compareFn;

        public DelegateComparer(Func<T, T, int> compareFn)
        {
            Validate.IsNotNull<Func<T, T, int>>(compareFn, "compareFn");
            this.compareFn = compareFn;
        }

        public int Compare(T x, T y) => 
            this.compareFn(x, y);
    }
}

