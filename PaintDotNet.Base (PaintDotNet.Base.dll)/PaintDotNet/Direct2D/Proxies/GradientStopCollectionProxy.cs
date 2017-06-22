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
    public class GradientStopCollectionProxy : ObjectRefProxy<IGradientStopCollection>, IGradientStopCollection, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GradientStopCollectionProxy(IGradientStopCollection objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public Gamma ColorInterpolationGamma =>
            base.innerRefT.ColorInterpolationGamma;

        public PaintDotNet.Direct2D.ExtendMode ExtendMode =>
            base.innerRefT.ExtendMode;

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;

        public IList<GradientStopFloat> GradientStops =>
            base.innerRefT.GradientStops;
    }
}

