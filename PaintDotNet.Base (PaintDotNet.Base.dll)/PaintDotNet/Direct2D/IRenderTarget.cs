namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.ObjectModel;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("2cd90694-12e2-11dc-9fed-001143a055f9")]
    public interface IRenderTarget : IDrawingContext, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache
    {
        void BeginDraw();
        void EndDraw(out Tag tag1, out Tag tag2);

        VectorFloat Dpi { get; set; }
    }
}

