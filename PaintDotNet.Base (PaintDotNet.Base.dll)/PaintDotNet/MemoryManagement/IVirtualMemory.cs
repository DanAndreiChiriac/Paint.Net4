namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IVirtualMemory : IBuffer, IBufferSource, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        void DisregardContents();

        MemoryProtection Protection { get; set; }
    }
}

