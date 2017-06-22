namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.ObjectModel;
    using PaintDotNet.Rendering;
    using System;

    [NativeInterfaceID("2cd90698-12e2-11dc-9fed-001143a055f9")]
    public interface IHwndRenderTarget : IRenderTarget, IDrawingContext, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache
    {
        void Resize(SizeInt32 pixelSize);

        IntPtr Hwnd { get; }

        PaintDotNet.Direct2D.WindowState WindowState { get; }
    }
}

