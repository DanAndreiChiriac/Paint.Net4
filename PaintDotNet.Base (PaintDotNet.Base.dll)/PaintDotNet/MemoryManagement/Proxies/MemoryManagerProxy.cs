namespace PaintDotNet.MemoryManagement.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.MemoryManagement;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class MemoryManagerProxy : ObjectRefProxy<IMemoryManager>, IMemoryManager, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MemoryManagerProxy(IMemoryManager objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAllocator CreateHeap() => 
            base.innerRefT.CreateHeap();

        public IAllocator DefaultHeap =>
            base.innerRefT.DefaultHeap;

        public IVirtualMemoryAllocator VirtualMemoryAllocator =>
            base.innerRefT.VirtualMemoryAllocator;
    }
}

