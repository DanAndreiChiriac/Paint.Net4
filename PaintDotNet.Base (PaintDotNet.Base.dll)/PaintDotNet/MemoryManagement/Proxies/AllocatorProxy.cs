namespace PaintDotNet.MemoryManagement.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.MemoryManagement;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class AllocatorProxy : ObjectRefProxy<IAllocator>, IAllocator, IMemoryObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AllocatorProxy(IAllocator objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBuffer Allocate(long size, AllocationOptions flags) => 
            base.innerRefT.Allocate(size, flags);
    }
}

