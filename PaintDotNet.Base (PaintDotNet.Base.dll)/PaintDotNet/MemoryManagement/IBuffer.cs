namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IBuffer : IBufferSource, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        IBufferLock Lock(long startOffset, long length, BufferAccess requestedAccess);

        BufferAccess Access { get; }
    }
}

