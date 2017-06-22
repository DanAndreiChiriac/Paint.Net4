namespace PaintDotNet.MemoryManagement.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.MemoryManagement;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BufferSourceProxy : ObjectRefProxy<IBufferSource>, IBufferSource, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BufferSourceProxy(IBufferSource objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyData(long startOffset, long length, IntPtr dstBuffer)
        {
            base.innerRefT.CopyData(startOffset, length, dstBuffer);
        }

        public long Size =>
            base.innerRefT.Size;
    }
}

