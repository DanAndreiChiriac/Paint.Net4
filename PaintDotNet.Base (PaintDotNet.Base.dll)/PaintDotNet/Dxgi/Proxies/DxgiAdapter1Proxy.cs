namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiAdapter1Proxy : ObjectRefProxy<IDxgiAdapter1>, IDxgiAdapter1, IDxgiAdapter, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiAdapter1Proxy(IDxgiAdapter1 objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDxgiOutput GetOutput(int outputIndex) => 
            base.innerRefT.GetOutput(outputIndex);

        public AdapterDescription Description =>
            base.innerRefT.Description;

        public AdapterDescription1 Description1 =>
            base.innerRefT.Description1;

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

