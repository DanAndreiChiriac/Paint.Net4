namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;

    [NativeInterfaceID("2cd906ac-12e2-11dc-9fed-001143a055f9")]
    public interface IRadialGradientBrush : IGradientBrush, IBrush, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        PointFloat Center { get; set; }

        PointFloat GradientOriginOffset { get; set; }

        float RadiusX { get; set; }

        float RadiusY { get; set; }
    }
}

