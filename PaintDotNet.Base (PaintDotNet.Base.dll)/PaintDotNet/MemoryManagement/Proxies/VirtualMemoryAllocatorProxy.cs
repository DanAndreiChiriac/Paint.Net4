namespace PaintDotNet.MemoryManagement.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.MemoryManagement;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class VirtualMemoryAllocatorProxy : ObjectRefProxy<IVirtualMemoryAllocator>, IVirtualMemoryAllocator, IAllocator, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public VirtualMemoryAllocatorProxy(IVirtualMemoryAllocator objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IVirtualMemory Allocate(long size, AllocationOptions flags) => 
            base.innerRefT.Allocate(size, flags);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IVirtualMemory Allocate(long size, MemoryProtection protection, AllocationOptions flags) => 
            base.innerRefT.Allocate(size, protection, flags);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual IBuffer OnExplicitIAllocatorAllocate(long size, AllocationOptions flags) => 
            base.innerRefT.Allocate(size, flags);

        IBuffer IAllocator.Allocate(long size, AllocationOptions flags) => 
            this.OnExplicitIAllocatorAllocate(size, flags);

        public int AllocationGranularity =>
            base.innerRefT.AllocationGranularity;

        public int PageSize =>
            base.innerRefT.PageSize;
    }
}

