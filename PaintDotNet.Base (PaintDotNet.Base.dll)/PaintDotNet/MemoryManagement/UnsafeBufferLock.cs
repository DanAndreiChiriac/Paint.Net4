namespace PaintDotNet.MemoryManagement
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct UnsafeBufferLock
    {
        private IntPtr address;
        private long size;
        public IntPtr Address =>
            this.address;
        public long Size =>
            this.size;
        public UnsafeBufferLock(IntPtr address, long size)
        {
            this.address = address;
            this.size = size;
        }
    }
}

