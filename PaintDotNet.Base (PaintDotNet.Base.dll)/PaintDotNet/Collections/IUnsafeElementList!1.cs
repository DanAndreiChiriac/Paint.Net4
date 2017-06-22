namespace PaintDotNet.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IUnsafeElementList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T: struct
    {
        IUnsafeElementAccessor<T> Accessor { get; }

        void* Buffer { get; }
    }
}

