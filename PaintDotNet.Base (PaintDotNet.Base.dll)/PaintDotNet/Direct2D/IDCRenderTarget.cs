namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.ObjectModel;
    using PaintDotNet.Rendering;
    using System;

    [NativeInterfaceID("1c51bc64-de61-46fd-9899-63a5d8f03950")]
    public interface IDCRenderTarget : IRenderTarget, IDrawingContext, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache
    {
        void BindDC(IntPtr hdc, RectInt32 subRect);
    }
}

