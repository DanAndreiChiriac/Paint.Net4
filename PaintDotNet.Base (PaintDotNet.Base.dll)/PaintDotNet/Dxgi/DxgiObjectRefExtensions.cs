namespace PaintDotNet.Dxgi
{
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    public static class DxgiObjectRefExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiAdapter CreateRef(this IDxgiAdapter objectRef) => 
            ((IDxgiAdapter) objectRef.CreateRef(typeof(IDxgiAdapter)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiAdapter1 CreateRef(this IDxgiAdapter1 objectRef) => 
            ((IDxgiAdapter1) objectRef.CreateRef(typeof(IDxgiAdapter1)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiDevice CreateRef(this IDxgiDevice objectRef) => 
            ((IDxgiDevice) objectRef.CreateRef(typeof(IDxgiDevice)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiDevice1 CreateRef(this IDxgiDevice1 objectRef) => 
            ((IDxgiDevice1) objectRef.CreateRef(typeof(IDxgiDevice1)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiDeviceSubObject CreateRef(this IDxgiDeviceSubObject objectRef) => 
            ((IDxgiDeviceSubObject) objectRef.CreateRef(typeof(IDxgiDeviceSubObject)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiFactory CreateRef(this IDxgiFactory objectRef) => 
            ((IDxgiFactory) objectRef.CreateRef(typeof(IDxgiFactory)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiFactory1 CreateRef(this IDxgiFactory1 objectRef) => 
            ((IDxgiFactory1) objectRef.CreateRef(typeof(IDxgiFactory1)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiKeyedMutex CreateRef(this IDxgiKeyedMutex objectRef) => 
            ((IDxgiKeyedMutex) objectRef.CreateRef(typeof(IDxgiKeyedMutex)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiObject CreateRef(this IDxgiObject objectRef) => 
            ((IDxgiObject) objectRef.CreateRef(typeof(IDxgiObject)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiOutput CreateRef(this IDxgiOutput objectRef) => 
            ((IDxgiOutput) objectRef.CreateRef(typeof(IDxgiOutput)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiResource CreateRef(this IDxgiResource objectRef) => 
            ((IDxgiResource) objectRef.CreateRef(typeof(IDxgiResource)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiSurface CreateRef(this IDxgiSurface objectRef) => 
            ((IDxgiSurface) objectRef.CreateRef(typeof(IDxgiSurface)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiSurface1 CreateRef(this IDxgiSurface1 objectRef) => 
            ((IDxgiSurface1) objectRef.CreateRef(typeof(IDxgiSurface1)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDxgiSwapChain CreateRef(this IDxgiSwapChain objectRef) => 
            ((IDxgiSwapChain) objectRef.CreateRef(typeof(IDxgiSwapChain)));
    }
}

