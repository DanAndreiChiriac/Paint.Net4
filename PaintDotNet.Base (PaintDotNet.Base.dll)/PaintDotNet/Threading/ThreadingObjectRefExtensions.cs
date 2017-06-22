namespace PaintDotNet.Threading
{
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    public static class ThreadingObjectRefExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDispatcher CreateRef(this IDispatcher objectRef) => 
            ((IDispatcher) objectRef.CreateRef(typeof(IDispatcher)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static ISynchronizationContext CreateRef(this ISynchronizationContext objectRef) => 
            ((ISynchronizationContext) objectRef.CreateRef(typeof(ISynchronizationContext)));
    }
}

