namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.Runtime.InteropServices;

    public interface IAllocator : IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        IBuffer Allocate(long size, AllocationOptions flags = 0);
    }
}

