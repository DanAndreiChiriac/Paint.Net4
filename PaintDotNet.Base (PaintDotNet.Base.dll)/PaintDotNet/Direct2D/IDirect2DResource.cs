namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("2cd90691-12e2-11dc-9fed-001143a055f9")]
    public interface IDirect2DResource : IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IDirect2DFactory Factory { get; }
    }
}

