namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;

    [NativeInterfaceID("2cd906a8-12e2-11dc-9fed-001143a055f9")]
    public interface IBrush : IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        float Opacity { get; set; }

        Matrix3x2Float Transform { get; set; }
    }
}

