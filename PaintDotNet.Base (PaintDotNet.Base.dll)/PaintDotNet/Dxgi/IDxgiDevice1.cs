namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("77db970f-6276-48ba-ba28-070143b4392c")]
    public interface IDxgiDevice1 : IDxgiDevice, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        int MaximumFrameLatency { get; set; }
    }
}

