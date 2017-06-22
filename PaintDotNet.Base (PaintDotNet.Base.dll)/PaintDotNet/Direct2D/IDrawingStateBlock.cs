namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("28506e39-ebf6-46a1-bb47-fd85565ab957")]
    public interface IDrawingStateBlock : IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        DrawingStateDescription Description { get; set; }

        ITextRenderingParams TextRenderingParams { get; [param: Optional] set; }
    }
}

