namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.ObjectModel;
    using System;

    [NativeInterfaceID("2cd90695-12e2-11dc-9fed-001143a055f9")]
    public interface IDeviceBitmapRenderTarget : IRenderTarget, IDrawingContext, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache, IDeviceResource
    {
        IDeviceBitmap Bitmap { get; }
    }
}

