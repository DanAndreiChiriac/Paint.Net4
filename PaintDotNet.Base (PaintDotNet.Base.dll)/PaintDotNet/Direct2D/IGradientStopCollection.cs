namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;

    [NativeInterfaceID("2cd906a7-12e2-11dc-9fed-001143a055f9")]
    public interface IGradientStopCollection : IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        Gamma ColorInterpolationGamma { get; }

        PaintDotNet.Direct2D.ExtendMode ExtendMode { get; }

        IList<GradientStopFloat> GradientStops { get; }
    }
}

