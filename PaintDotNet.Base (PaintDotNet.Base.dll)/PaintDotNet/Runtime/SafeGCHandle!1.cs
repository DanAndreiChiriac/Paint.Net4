namespace PaintDotNet.Runtime
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class SafeGCHandle<T> : SafeGCHandle where T: class
    {
        internal SafeGCHandle()
        {
        }

        internal SafeGCHandle(GCHandle gcHandle) : base(gcHandle)
        {
        }

        public T Target =>
            ((T) base.Target);
    }
}

