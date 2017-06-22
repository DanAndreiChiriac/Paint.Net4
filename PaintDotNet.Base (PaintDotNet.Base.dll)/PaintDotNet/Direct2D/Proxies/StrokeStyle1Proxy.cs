namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class StrokeStyle1Proxy : ObjectRefProxy<IStrokeStyle1>, IStrokeStyle1, IStrokeStyle, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StrokeStyle1Proxy(IStrokeStyle1 objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public CapStyle DashCap =>
            base.innerRefT.DashCap;

        public IList<float> Dashes =>
            base.innerRefT.Dashes;

        public float DashOffset =>
            base.innerRefT.DashOffset;

        public PaintDotNet.Direct2D.DashStyle DashStyle =>
            base.innerRefT.DashStyle;

        public CapStyle EndCap =>
            base.innerRefT.EndCap;

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;

        public PaintDotNet.Direct2D.LineJoin LineJoin =>
            base.innerRefT.LineJoin;

        public float MiterLimit =>
            base.innerRefT.MiterLimit;

        public CapStyle StartCap =>
            base.innerRefT.StartCap;

        public StrokeTransformType TransformType =>
            base.innerRefT.TransformType;
    }
}

