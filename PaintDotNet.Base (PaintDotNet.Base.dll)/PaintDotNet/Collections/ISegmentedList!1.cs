namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface ISegmentedList<T> : ISegmentedCollection<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>
    {
        void Resize(int newCount);
    }
}

