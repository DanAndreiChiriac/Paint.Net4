namespace PaintDotNet.ComponentModel
{
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    public static class ComponentModelObjectRefExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IObjectRefEnumerable CreateRef(this IObjectRefEnumerable objectRef) => 
            ((IObjectRefEnumerable) objectRef.CreateRef(typeof(IObjectRefEnumerable)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IObjectRefEnumerator CreateRef(this IObjectRefEnumerator objectRef) => 
            ((IObjectRefEnumerator) objectRef.CreateRef(typeof(IObjectRefEnumerator)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IPropertyBag2 CreateRef(this IPropertyBag2 objectRef) => 
            ((IPropertyBag2) objectRef.CreateRef(typeof(IPropertyBag2)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IStringEnumerable CreateRef(this IStringEnumerable objectRef) => 
            ((IStringEnumerable) objectRef.CreateRef(typeof(IStringEnumerable)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IStringEnumerator CreateRef(this IStringEnumerator objectRef) => 
            ((IStringEnumerator) objectRef.CreateRef(typeof(IStringEnumerator)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IValueRef<T> CreateRef<T>(this IValueRef<T> objectRef) => 
            ((IValueRef<T>) objectRef.CreateRef(typeof(IValueRef<T>)));
    }
}

