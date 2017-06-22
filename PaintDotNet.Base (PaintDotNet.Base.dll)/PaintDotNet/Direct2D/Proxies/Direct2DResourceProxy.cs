namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class Direct2DResourceProxy : ObjectRefProxy<IDirect2DResource>, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Direct2DResourceProxy(IDirect2DResource objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;
    }
}

