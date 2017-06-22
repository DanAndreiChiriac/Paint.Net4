namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("2cd906aa-12e2-11dc-9fed-001143a055f9")]
    public interface IBitmapBrush : IBrush, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IDeviceBitmap Bitmap { get; set; }

        ExtendMode ExtendModeX { get; set; }

        ExtendMode ExtendModeY { get; set; }

        BitmapInterpolationMode InterpolationMode { get; set; }
    }
}

