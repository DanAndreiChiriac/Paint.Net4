namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IPixelFormatInfo2 : IPixelFormatInfo, IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        PixelFormatNumericRepresentation NumericRepresentation { get; }

        bool SupportsTransparency { get; }
    }
}

