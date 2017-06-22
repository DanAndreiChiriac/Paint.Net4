namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("689f1f85-c72e-4e33-8f19-85754efd5ace")]
    public interface IDrawingStateBlock1 : IDrawingStateBlock, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        DrawingStateDescription1 Description { get; set; }
    }
}

