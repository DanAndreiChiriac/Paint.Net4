namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;

    public interface IEqualityComparerByRef<T> : IEqualityComparer<T>
    {
        bool Equals(ref T a, ref T b);
        int GetHashCode(ref T x);
    }
}

