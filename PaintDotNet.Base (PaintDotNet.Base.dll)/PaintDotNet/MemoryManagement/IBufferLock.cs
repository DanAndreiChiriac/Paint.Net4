namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IBufferLock : IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        IntPtr Address { get; }

        MemoryProtection Protection { get; }

        long Size { get; }
    }
}

