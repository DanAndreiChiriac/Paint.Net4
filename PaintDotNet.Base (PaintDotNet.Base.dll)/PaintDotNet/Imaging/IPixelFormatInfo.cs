namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.Collections.Generic;

    public interface IPixelFormatInfo : IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        int BitsPerPixel { get; }

        int ChannelCount { get; }

        IList<IList<byte>> ChannelMasks { get; }

        IColorContext ColorContext { get; }

        PaintDotNet.Imaging.PixelFormat PixelFormat { get; }
    }
}

