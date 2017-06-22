namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;

    internal interface IListSource<T>
    {
        IList<T> List { get; }

        int Version { get; }
    }
}

