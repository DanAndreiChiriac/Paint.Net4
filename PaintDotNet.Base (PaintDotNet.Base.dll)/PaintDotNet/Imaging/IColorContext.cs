namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("3c613a02-34b2-44ea-9a7c-45aea9c6fd6d")]
    public interface IColorContext : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        ColorContextType Type { get; }
    }
}

