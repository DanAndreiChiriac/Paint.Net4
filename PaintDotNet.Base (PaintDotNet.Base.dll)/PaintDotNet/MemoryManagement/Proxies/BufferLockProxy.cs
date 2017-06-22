namespace PaintDotNet.MemoryManagement.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.MemoryManagement;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BufferLockProxy : ObjectRefProxy<IBufferLock>, IBufferLock, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BufferLockProxy(IBufferLock objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public IntPtr Address =>
            base.innerRefT.Address;

        public MemoryProtection Protection =>
            base.innerRefT.Protection;

        public long Size =>
            base.innerRefT.Size;
    }
}

