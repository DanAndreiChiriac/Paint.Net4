namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ComparisonWrapper<T> : IComparer<T>
    {
        private Comparison<T> comparison;
        public ComparisonWrapper(Comparison<T> comparison)
        {
            Validate.IsNotNull<Comparison<T>>(comparison, "comparison");
            this.comparison = comparison;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(T x, T y) => 
            this.comparison(x, y);
    }
}

