namespace PaintDotNet.Runtime
{
    using System;

    public class PartitioningRef<T> : PartitioningRef where T: class
    {
        public PartitioningRef(T target) : base(target)
        {
        }

        public T Target =>
            ((T) base.Target);
    }
}

