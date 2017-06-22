namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class ImagingFactoryProxy : ObjectRefProxy<IImagingFactory>, IImagingFactory, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ImagingFactoryProxy(IImagingFactory objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CanConvertFormat(PixelFormat srcFormat, PixelFormat dstFormat) => 
            base.innerRefT.CanConvertFormat(srcFormat, dstFormat);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IPalette ClonePalette(IPalette palette) => 
            base.innerRefT.ClonePalette(palette);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmap CreateBitmap(int width, int height, PixelFormat pixelFormat, BitmapCreateCacheOption option) => 
            base.innerRefT.CreateBitmap(width, height, pixelFormat, option);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapSource CreateBitmapClipper(IBitmapSource source, RectInt32 rect) => 
            base.innerRefT.CreateBitmapClipper(source, rect);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapSource CreateBitmapFlipRotator(IBitmapSource source, BitmapTransformOptions options) => 
            base.innerRefT.CreateBitmapFlipRotator(source, options);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmap CreateBitmapFromHBITMAP(IntPtr hBitmap, IntPtr hPalette, BitmapAlphaChannelOption option) => 
            base.innerRefT.CreateBitmapFromHBITMAP(hBitmap, hPalette, option);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmap CreateBitmapFromHICON(IntPtr hIcon) => 
            base.innerRefT.CreateBitmapFromHICON(hIcon);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmap CreateBitmapFromMemory(int width, int height, PixelFormat pixelFormat, int stride, long bufferSize, IntPtr buffer) => 
            base.innerRefT.CreateBitmapFromMemory(width, height, pixelFormat, stride, bufferSize, buffer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmap CreateBitmapFromSource(IBitmapSource bitmapSource, BitmapCreateCacheOption option) => 
            base.innerRefT.CreateBitmapFromSource(bitmapSource, option);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmap CreateBitmapFromSourceRect(IBitmapSource bitmapSource, RectInt32 sourceRect) => 
            base.innerRefT.CreateBitmapFromSourceRect(bitmapSource, sourceRect);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapSource CreateBitmapScaler(IBitmapSource source, int dstWidth, int dstHeight, BitmapInterpolationMode mode) => 
            base.innerRefT.CreateBitmapScaler(source, dstWidth, dstHeight, mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapSource CreateBufferedBitmap(IBitmapSource source, IBitmap buffer, int maxBufferHeightLog2) => 
            base.innerRefT.CreateBufferedBitmap(source, buffer, maxBufferHeightLog2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IExifColorSpaceColorContext CreateColorContext(ExifColorSpace exifColorSpace) => 
            base.innerRefT.CreateColorContext(exifColorSpace);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IProfileColorContext CreateColorContext(string filename) => 
            base.innerRefT.CreateColorContext(filename);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IProfileColorContext CreateColorContext(byte[] profileBytes) => 
            base.innerRefT.CreateColorContext(profileBytes);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapSource CreateColorTransformedBitmap(IBitmapSource source, IColorContext sourceContext, IColorContext dstContext, PixelFormat dstPixelFormat) => 
            base.innerRefT.CreateColorTransformedBitmap(source, sourceContext, dstContext, dstPixelFormat);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<IImagingComponentInfo> CreateComponentEnumerator(ImagingComponentType componentTypes, ImagingComponentEnumerateOptions options) => 
            base.innerRefT.CreateComponentEnumerator(componentTypes, options);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IImagingComponentInfo CreateComponentInfo(Guid componentGuid) => 
            base.innerRefT.CreateComponentInfo(componentGuid);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IPalette CreateCustomPalette(IList<ColorBgra32> colors, int startIndex, int length) => 
            base.innerRefT.CreateCustomPalette(colors, startIndex, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapDecoder CreateDecoder(ImagingContainerFormat containerFormat, Stream stream, BitmapDecodeOptions metadataOptions, ImagingVendor? preferredVendor) => 
            base.innerRefT.CreateDecoder(containerFormat, stream, metadataOptions, preferredVendor);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapDecoder CreateDecoderFromStream(Stream stream, BitmapDecodeOptions metadataOptions, ImagingVendor? preferredVendor) => 
            base.innerRefT.CreateDecoderFromStream(stream, metadataOptions, preferredVendor);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapSource CreateFormatConvertedBitmap(IBitmapSource source, PixelFormat dstFormat, BitmapDitherType dither, IPalette palette, double alphaThresholdPercent, BitmapPaletteType paletteTranslate) => 
            base.innerRefT.CreateFormatConvertedBitmap(source, dstFormat, dither, palette, alphaThresholdPercent, paletteTranslate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IPalette CreatePaletteFromBitmap(IBitmapSource bitmap, int colorCount, bool addTransparentColor) => 
            base.innerRefT.CreatePaletteFromBitmap(bitmap, colorCount, addTransparentColor);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IPalette CreatePredefinedPalette(BitmapPaletteType paletteType, bool addTransparentColor) => 
            base.innerRefT.CreatePredefinedPalette(paletteType, addTransparentColor);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmap CreateSharedBitmap(object keepAlive, int width, int height, PixelFormat pixelFormat, IntPtr scan0, int stride, double dpiX, double dpiY) => 
            base.innerRefT.CreateSharedBitmap(keepAlive, width, height, pixelFormat, scan0, stride, dpiX, dpiY);
    }
}

