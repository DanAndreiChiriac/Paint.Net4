namespace PaintDotNet.Imaging
{
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ImagingFactoryExtensions
    {
        public static IBitmap<TPixel> CreateBitmap<TPixel>(this IImagingFactory factory, SizeInt32 size, BitmapCreateCacheOption option = 2) where TPixel: struct, INaturalPixelInfo => 
            factory.CreateBitmap<TPixel>(size.width, size.height, option);

        public static IBitmap<TPixel> CreateBitmap<TPixel>(this IImagingFactory factory, int width, int height, BitmapCreateCacheOption option = 2) where TPixel: struct, INaturalPixelInfo
        {
            TPixel local = default(TPixel);
            return (IBitmap<TPixel>) factory.CreateBitmap(width, height, local.PixelFormat, option);
        }

        public static IBitmapSource<TPixel> CreateBitmapClipper<TPixel>(this IImagingFactory factory, IBitmapSource<TPixel> source, RectInt32 rect) where TPixel: struct, INaturalPixelInfo => 
            ((IBitmapSource<TPixel>) factory.CreateBitmapClipper(source, rect));

        public static IBitmapSource<TPixel> CreateBitmapFlipRotator<TPixel>(this IImagingFactory factory, IBitmapSource<TPixel> source, BitmapTransformOptions options) where TPixel: struct, INaturalPixelInfo => 
            ((IBitmapSource<TPixel>) factory.CreateBitmapFlipRotator(source, options));

        public static IBitmap<TPixel> CreateBitmapFromSourceRect<TPixel>(this IImagingFactory factory, IBitmapSource<TPixel> source, RectInt32 sourceRect) where TPixel: struct, INaturalPixelInfo => 
            ((IBitmap<TPixel>) factory.CreateBitmapFromSourceRect(source, sourceRect));

        public static IBitmapSource<TPixel> CreateBitmapScaler<TPixel>(this IImagingFactory factory, IBitmapSource<TPixel> source, int dstWidth, int dstHeight, BitmapInterpolationMode mode) where TPixel: struct, INaturalPixelInfo => 
            ((IBitmapSource<TPixel>) factory.CreateBitmapScaler(source, dstWidth, dstHeight, mode));

        public static IBitmapSource<TPixel> CreateBufferedBitmap<TPixel>(this IImagingFactory factory, IBitmapSource<TPixel> source, IBitmap<TPixel> buffer = null, int maxBufferHeightLog2 = 7) where TPixel: struct, INaturalPixelInfo => 
            ((IBitmapSource<TPixel>) factory.CreateBufferedBitmap(source, buffer, maxBufferHeightLog2));

        public static IBitmapSource<TPixel> CreateFormatConvertedBitmap<TPixel>(this IImagingFactory factory, IBitmapSource source) where TPixel: struct, INaturalPixelInfo => 
            factory.CreateFormatConvertedBitmap<TPixel>(source, BitmapDitherType.None, null, 0.0, BitmapPaletteType.Custom);

        public static IBitmapSource CreateFormatConvertedBitmap(this IImagingFactory factory, IBitmapSource source, PixelFormat dstFormat) => 
            factory.CreateFormatConvertedBitmap(source, dstFormat, BitmapDitherType.None, null, 0.0, BitmapPaletteType.Custom);

        public static IBitmapSource<TPixel> CreateFormatConvertedBitmap<TPixel>(this IImagingFactory factory, IBitmapSource source, BitmapDitherType dither, IPalette palette, double alphaThresholdPercent, BitmapPaletteType paletteTranslate) where TPixel: struct, INaturalPixelInfo
        {
            TPixel local = default(TPixel);
            return (IBitmapSource<TPixel>) factory.CreateFormatConvertedBitmap(source, local.PixelFormat, dither, palette, alphaThresholdPercent, paletteTranslate);
        }

        public static int GetBufferBitmapHeight(this IImagingFactory factory, IBitmapSource source, int maxBufferHeightLog2 = 7) => 
            Math.Min(((int) 1) << maxBufferHeightLog2, source.Size.Height);
    }
}

