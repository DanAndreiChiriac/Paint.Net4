namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;

    [NativeInterfaceID("9f34fb65-13f4-4f15-bc57-3726b5e53d9f")]
    public interface IFormatConverterInfo : IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        bool CanConvert(PixelFormat srcPixelFormat, PixelFormat dstPixelFormat);
        IBitmapSource CreateInstance(IBitmapSource source, PixelFormat dstFormat, BitmapDitherType dither, IPalette palette, double alphaThresholdPercent, BitmapPaletteType paletteTranslate);

        IList<PixelFormat> PixelFormats { get; }
    }
}

