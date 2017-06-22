namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IMemoryManager : IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        IAllocator CreateHeap();

        IAllocator DefaultHeap { get; }

        IVirtualMemoryAllocator VirtualMemoryAllocator { get; }
    }
}

