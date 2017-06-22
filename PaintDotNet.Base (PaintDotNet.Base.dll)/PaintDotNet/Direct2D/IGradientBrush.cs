namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IGradientBrush : IBrush, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IGradientStopCollection GradientStopCollection { get; }
    }
}

