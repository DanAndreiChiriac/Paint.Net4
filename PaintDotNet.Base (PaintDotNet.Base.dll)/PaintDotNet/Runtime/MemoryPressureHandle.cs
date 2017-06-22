namespace PaintDotNet.Runtime
{
    using PaintDotNet;
    using System;

    public sealed class MemoryPressureHandle : Disposable
    {
        private long bytesAllocated;

        public MemoryPressureHandle(long bytesAllocated)
        {
            GCUtil.AddMemoryPressure(bytesAllocated);
            this.bytesAllocated = bytesAllocated;
        }

        protected override void Dispose(bool disposing)
        {
            GCUtil.RemoveMemoryPressure(this.bytesAllocated);
            base.Dispose(disposing);
        }
    }
}

