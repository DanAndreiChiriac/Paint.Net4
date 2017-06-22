namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;

    [NativeInterfaceID("2cd906a3-12e2-11dc-9fed-001143a055f9")]
    public interface IRoundedRectangleGeometry : IGeometry, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        RoundedRectFloat RoundedRect { get; }
    }
}

