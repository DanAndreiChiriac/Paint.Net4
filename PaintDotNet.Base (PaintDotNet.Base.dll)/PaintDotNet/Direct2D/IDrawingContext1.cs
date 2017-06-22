namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.ObjectModel;
    using System;

    public interface IDrawingContext1 : IDrawingContext, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache, IDeviceResourceFactory1
    {
        PaintDotNet.Direct2D.PrimitiveBlend PrimitiveBlend { get; set; }
    }
}

