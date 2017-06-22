namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface ISegmentedCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        void EnsureCapacity(int capacity);
        void TrimExcess();

        int Capacity { get; }

        int SegmentLengthLog2 { get; }
    }
}

