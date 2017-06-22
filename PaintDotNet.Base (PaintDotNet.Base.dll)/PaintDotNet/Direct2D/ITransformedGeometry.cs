namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;

    [NativeInterfaceID("2cd906bb-12e2-11dc-9fed-001143a055f9")]
    public interface ITransformedGeometry : IGeometry, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IGeometry SourceGeometry { get; }

        Matrix3x2Float Transform { get; }
    }
}

