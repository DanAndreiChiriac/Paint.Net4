namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;

    [NativeInterfaceID("2cd906ab-12e2-11dc-9fed-001143a055f9")]
    public interface ILinearGradientBrush : IGradientBrush, IBrush, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        PointFloat EndPoint { get; set; }

        PointFloat StartPoint { get; set; }
    }
}

