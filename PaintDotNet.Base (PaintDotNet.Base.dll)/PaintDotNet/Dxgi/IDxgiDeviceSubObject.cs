namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("3d3e0379-f9de-4d58-bb6c-18d62992f1a6")]
    public interface IDxgiDeviceSubObject : IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        IDxgiDevice Device { get; }
    }
}

