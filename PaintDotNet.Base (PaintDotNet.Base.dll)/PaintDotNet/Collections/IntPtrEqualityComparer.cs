namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;

    public sealed class IntPtrEqualityComparer : EqualityComparer<IntPtr>, IEqualityComparerByRef<IntPtr>, IEqualityComparer<IntPtr>
    {
        private static readonly IntPtrEqualityComparer instance = new IntPtrEqualityComparer();

        public sealed override bool Equals(IntPtr x, IntPtr y) => 
            (x == y);

        public bool Equals(ref IntPtr a, ref IntPtr b) => 
            (a == b);

        public override int GetHashCode(IntPtr obj) => 
            obj.GetHashCode();

        public int GetHashCode(ref IntPtr x) => 
            x.GetHashCode();

        public static IntPtrEqualityComparer Instance =>
            instance;
    }
}

