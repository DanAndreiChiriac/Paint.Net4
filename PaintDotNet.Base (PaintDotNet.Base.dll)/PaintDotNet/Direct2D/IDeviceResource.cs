namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IDeviceResource : IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
    }
}

