namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("d21768e1-23a4-4823-a14b-7c3eba85d658")]
    public interface IDevice1 : IDevice, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        PaintDotNet.Direct2D.RenderingPriority RenderingPriority { get; set; }
    }
}

