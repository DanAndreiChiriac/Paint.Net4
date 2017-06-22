namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("ec5ec8a9-c395-4314-9c77-54d7a935ff70")]
    public interface IImagingFactory : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        bool CanConvertFormat(PixelFormat srcFormat, PixelFormat dstFormat);
        IPalette ClonePalette(IPalette palette);
        IBitmap CreateBitmap(int width, int height, PixelFormat pixelFormat, BitmapCreateCacheOption option = 2);
        IBitmapSource CreateBitmapClipper(IBitmapSource source, RectInt32 rect);
        IBitmapSource CreateBitmapFlipRotator(IBitmapSource source, BitmapTransformOptions options);
        IBitmap CreateBitmapFromHBITMAP(IntPtr hBitmap, IntPtr hPalette, BitmapAlphaChannelOption option);
        IBitmap CreateBitmapFromHICON(IntPtr hIcon);
        IBitmap CreateBitmapFromMemory(int width, int height, PixelFormat pixelFormat, int stride, long bufferSize, IntPtr buffer);
        IBitmap CreateBitmapFromSource(IBitmapSource bitmapSource, BitmapCreateCacheOption option);
        IBitmap CreateBitmapFromSourceRect(IBitmapSource bitmapSource, RectInt32 sourceRect);
        IBitmapSource CreateBitmapScaler(IBitmapSource source, int dstWidth, int dstHeight, BitmapInterpolationMode mode);
        IBitmapSource CreateBufferedBitmap(IBitmapSource source, IBitmap buffer = null, int maxBufferHeightLog2 = 7);
        IExifColorSpaceColorContext CreateColorContext(ExifColorSpace exifColorSpace);
        IProfileColorContext CreateColorContext(string filename);
        IProfileColorContext CreateColorContext(byte[] profileBytes);
        IBitmapSource CreateColorTransformedBitmap(IBitmapSource source, IColorContext sourceContext, IColorContext dstContext, PixelFormat dstPixelFormat);
        IEnumerable<IImagingComponentInfo> CreateComponentEnumerator(ImagingComponentType componentTypes, ImagingComponentEnumerateOptions options = 0);
        IImagingComponentInfo CreateComponentInfo(Guid componentGuid);
        IPalette CreateCustomPalette(IList<ColorBgra32> colors, int startIndex, int length);
        IBitmapDecoder CreateDecoder(ImagingContainerFormat containerFormat, Stream stream, BitmapDecodeOptions metadataOptions, ImagingVendor? preferredVendor = new ImagingVendor?());
        IBitmapDecoder CreateDecoderFromStream(Stream stream, BitmapDecodeOptions metadataOptions, ImagingVendor? preferredVendor = new ImagingVendor?());
        IBitmapSource CreateFormatConvertedBitmap(IBitmapSource source, PixelFormat dstFormat, BitmapDitherType dither, IPalette palette, double alphaThresholdPercent, BitmapPaletteType paletteTranslate);
        IPalette CreatePaletteFromBitmap(IBitmapSource bitmap, int colorCount, bool addTransparentColor);
        IPalette CreatePredefinedPalette(BitmapPaletteType paletteType, bool addTransparentColor);
        IBitmap CreateSharedBitmap(object keepAlive, int width, int height, PixelFormat pixelFormat, IntPtr scan0, int stride, double dpiX = 96.0, double dpiY = 96.0);
    }
}

