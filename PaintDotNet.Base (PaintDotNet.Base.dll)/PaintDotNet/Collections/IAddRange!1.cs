namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;

    internal interface IAddRange<T>
    {
        void AddRange(IEnumerable<T> items);
    }
}

