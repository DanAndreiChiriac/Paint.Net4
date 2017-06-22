namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("2cd906a9-12e2-11dc-9fed-001143a055f9")]
    public interface ISolidColorBrush : IBrush, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        ColorRgba128Float Color { get; set; }
    }
}

