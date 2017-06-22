namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IBufferSource : IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        void CopyData(long startOffset, long length, IntPtr dstBuffer);

        long Size { get; }
    }
}

