namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IExifColorSpaceColorContext : IColorContext, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        PaintDotNet.Imaging.ExifColorSpace ExifColorSpace { get; }
    }
}

