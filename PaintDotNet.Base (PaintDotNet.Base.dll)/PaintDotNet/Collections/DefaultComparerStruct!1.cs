namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct DefaultComparerStruct<T> : IComparer<T> where T: IComparable<T>
    {
        public int Compare(T x, T y) => 
            x.CompareTo(y);
    }
}

