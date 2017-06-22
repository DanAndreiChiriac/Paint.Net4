namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;

    public sealed class SynchronizedList<T> : SynchronizedList<T, IList<T>>
    {
        public SynchronizedList(IList<T> source) : this(source, new object())
        {
        }

        public SynchronizedList(IList<T> source, object sync) : base(source, sync)
        {
        }
    }
}

