namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    public static class MemoryManagementObjectRefExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IAllocator CreateRef(this IAllocator objectRef) => 
            ((IAllocator) objectRef.CreateRef(typeof(IAllocator)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBuffer CreateRef(this IBuffer objectRef) => 
            ((IBuffer) objectRef.CreateRef(typeof(IBuffer)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBufferLock CreateRef(this IBufferLock objectRef) => 
            ((IBufferLock) objectRef.CreateRef(typeof(IBufferLock)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBufferSource CreateRef(this IBufferSource objectRef) => 
            ((IBufferSource) objectRef.CreateRef(typeof(IBufferSource)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IMemoryManager CreateRef(this IMemoryManager objectRef) => 
            ((IMemoryManager) objectRef.CreateRef(typeof(IMemoryManager)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IMemoryObject CreateRef(this IMemoryObject objectRef) => 
            ((IMemoryObject) objectRef.CreateRef(typeof(IMemoryObject)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IVirtualMemory CreateRef(this IVirtualMemory objectRef) => 
            ((IVirtualMemory) objectRef.CreateRef(typeof(IVirtualMemory)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IVirtualMemoryAllocator CreateRef(this IVirtualMemoryAllocator objectRef) => 
            ((IVirtualMemoryAllocator) objectRef.CreateRef(typeof(IVirtualMemoryAllocator)));
    }
}

