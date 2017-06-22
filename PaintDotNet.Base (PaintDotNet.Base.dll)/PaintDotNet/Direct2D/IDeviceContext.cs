namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.ObjectModel;
    using System;

    [NativeInterfaceID("e8f7fe7a-191c-466d-ad95-975678bda998")]
    public interface IDeviceContext : IRenderTarget, IDrawingContext, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache, IDrawingContext1, IDeviceResourceFactory1
    {
        IDevice Device { get; }
    }
}

