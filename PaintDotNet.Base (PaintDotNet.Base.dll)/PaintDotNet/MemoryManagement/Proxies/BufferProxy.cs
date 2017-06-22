namespace PaintDotNet.MemoryManagement.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.MemoryManagement;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BufferProxy : ObjectRefProxy<IBuffer>, IBuffer, IBufferSource, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BufferProxy(IBuffer objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyData(long startOffset, long length, IntPtr dstBuffer)
        {
            base.innerRefT.CopyData(startOffset, length, dstBuffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBufferLock Lock(long startOffset, long length, BufferAccess requestedAccess) => 
            base.innerRefT.Lock(startOffset, length, requestedAccess);

        public BufferAccess Access =>
            base.innerRefT.Access;

        public long Size =>
            base.innerRefT.Size;
    }
}

