namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.Runtime.InteropServices;

    public interface IVirtualMemoryAllocator : IAllocator, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        IVirtualMemory Allocate(long size, AllocationOptions flags = 0);
        IVirtualMemory Allocate(long size, MemoryProtection protection, AllocationOptions flags = 0);

        int AllocationGranularity { get; }

        int PageSize { get; }
    }
}

