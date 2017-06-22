namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("035f3ab4-482e-4e50-b41f-8a7f8bd8960b")]
    public interface IDxgiResource : IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        ResourcePriority EvictionPriority { get; set; }

        IntPtr SharedHandle { get; }

        UsageOptions Usage { get; }
    }
}

