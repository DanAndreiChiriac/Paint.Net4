namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiAdapterProxy : ObjectRefProxy<IDxgiAdapter>, IDxgiAdapter, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiAdapterProxy(IDxgiAdapter objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDxgiOutput GetOutput(int outputIndex) => 
            base.innerRefT.GetOutput(outputIndex);

        public AdapterDescription Description =>
            base.innerRefT.Description;

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

