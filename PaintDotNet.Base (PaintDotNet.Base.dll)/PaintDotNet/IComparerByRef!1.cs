namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;

    public interface IComparerByRef<T> : IComparer<T>
    {
        int Compare(ref T a, ref T b);
    }
}

