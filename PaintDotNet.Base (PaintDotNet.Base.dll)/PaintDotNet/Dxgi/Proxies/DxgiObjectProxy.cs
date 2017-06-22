namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiObjectProxy : ObjectRefProxy<IDxgiObject>, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiObjectProxy(IDxgiObject objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

