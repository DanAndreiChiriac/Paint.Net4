namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public sealed class SafeCoTaskMemAllocHandle : SafeHandleZeroIsInvalid
    {
        private SafeCoTaskMemAllocHandle() : base(true)
        {
        }

        public SafeCoTaskMemAllocHandle(bool ownsHandle) : base(ownsHandle)
        {
        }

        public SafeCoTaskMemAllocHandle(IntPtr pBuffer, bool ownsHandle) : base(ownsHandle)
        {
            base.SetHandle(pBuffer);
        }

        public static SafeCoTaskMemAllocHandle Alloc(int cb)
        {
            IntPtr pBuffer = Marshal.AllocCoTaskMem(cb);
            SafeCoTaskMemAllocHandle handle1 = new SafeCoTaskMemAllocHandle();
            handle1.TakeHandle(ref pBuffer);
            return handle1;
        }

        protected override bool ReleaseHandle()
        {
            Marshal.FreeCoTaskMem(base.handle);
            return true;
        }

        private void TakeHandle(ref IntPtr pBuffer)
        {
            base.SetHandle(pBuffer);
            pBuffer = IntPtr.Zero;
        }

        public IntPtr Address =>
            base.handle;
    }
}

