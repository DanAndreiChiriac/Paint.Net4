namespace PaintDotNet.Imaging
{
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    public static class ImagingObjectRefExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmap CreateRef(this IBitmap objectRef) => 
            ((IBitmap) objectRef.CreateRef(typeof(IBitmap)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmap<TPixel> CreateRef<TPixel>(this IBitmap<TPixel> objectRef) where TPixel: struct, INaturalPixelInfo => 
            ((IBitmap<TPixel>) objectRef.CreateRef(typeof(IBitmap<TPixel>)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapCodecInfo CreateRef(this IBitmapCodecInfo objectRef) => 
            ((IBitmapCodecInfo) objectRef.CreateRef(typeof(IBitmapCodecInfo)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapDecoder CreateRef(this IBitmapDecoder objectRef) => 
            ((IBitmapDecoder) objectRef.CreateRef(typeof(IBitmapDecoder)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapDecoderInfo CreateRef(this IBitmapDecoderInfo objectRef) => 
            ((IBitmapDecoderInfo) objectRef.CreateRef(typeof(IBitmapDecoderInfo)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapEncoder CreateRef(this IBitmapEncoder objectRef) => 
            ((IBitmapEncoder) objectRef.CreateRef(typeof(IBitmapEncoder)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapEncoderInfo CreateRef(this IBitmapEncoderInfo objectRef) => 
            ((IBitmapEncoderInfo) objectRef.CreateRef(typeof(IBitmapEncoderInfo)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapFrameDecode CreateRef(this IBitmapFrameDecode objectRef) => 
            ((IBitmapFrameDecode) objectRef.CreateRef(typeof(IBitmapFrameDecode)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapFrameEncode CreateRef(this IBitmapFrameEncode objectRef) => 
            ((IBitmapFrameEncode) objectRef.CreateRef(typeof(IBitmapFrameEncode)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapLock CreateRef(this IBitmapLock objectRef) => 
            ((IBitmapLock) objectRef.CreateRef(typeof(IBitmapLock)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapLock<TPixel> CreateRef<TPixel>(this IBitmapLock<TPixel> objectRef) where TPixel: struct, INaturalPixelInfo => 
            ((IBitmapLock<TPixel>) objectRef.CreateRef(typeof(IBitmapLock<TPixel>)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapSource CreateRef(this IBitmapSource objectRef) => 
            ((IBitmapSource) objectRef.CreateRef(typeof(IBitmapSource)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IBitmapSource<TPixel> CreateRef<TPixel>(this IBitmapSource<TPixel> objectRef) where TPixel: struct, INaturalPixelInfo => 
            ((IBitmapSource<TPixel>) objectRef.CreateRef(typeof(IBitmapSource<TPixel>)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IColorContext CreateRef(this IColorContext objectRef) => 
            ((IColorContext) objectRef.CreateRef(typeof(IColorContext)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDevelopRaw CreateRef(this IDevelopRaw objectRef) => 
            ((IDevelopRaw) objectRef.CreateRef(typeof(IDevelopRaw)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IExifColorSpaceColorContext CreateRef(this IExifColorSpaceColorContext objectRef) => 
            ((IExifColorSpaceColorContext) objectRef.CreateRef(typeof(IExifColorSpaceColorContext)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IFastMetadataEncoder CreateRef(this IFastMetadataEncoder objectRef) => 
            ((IFastMetadataEncoder) objectRef.CreateRef(typeof(IFastMetadataEncoder)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IFormatConverterInfo CreateRef(this IFormatConverterInfo objectRef) => 
            ((IFormatConverterInfo) objectRef.CreateRef(typeof(IFormatConverterInfo)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IImagingComponentInfo CreateRef(this IImagingComponentInfo objectRef) => 
            ((IImagingComponentInfo) objectRef.CreateRef(typeof(IImagingComponentInfo)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IImagingFactory CreateRef(this IImagingFactory objectRef) => 
            ((IImagingFactory) objectRef.CreateRef(typeof(IImagingFactory)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IImagingObject CreateRef(this IImagingObject objectRef) => 
            ((IImagingObject) objectRef.CreateRef(typeof(IImagingObject)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IMetadataQueryReader CreateRef(this IMetadataQueryReader objectRef) => 
            ((IMetadataQueryReader) objectRef.CreateRef(typeof(IMetadataQueryReader)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IMetadataQueryWriter CreateRef(this IMetadataQueryWriter objectRef) => 
            ((IMetadataQueryWriter) objectRef.CreateRef(typeof(IMetadataQueryWriter)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IPalette CreateRef(this IPalette objectRef) => 
            ((IPalette) objectRef.CreateRef(typeof(IPalette)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IPixelFormatInfo CreateRef(this IPixelFormatInfo objectRef) => 
            ((IPixelFormatInfo) objectRef.CreateRef(typeof(IPixelFormatInfo)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IPixelFormatInfo2 CreateRef(this IPixelFormatInfo2 objectRef) => 
            ((IPixelFormatInfo2) objectRef.CreateRef(typeof(IPixelFormatInfo2)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IProfileColorContext CreateRef(this IProfileColorContext objectRef) => 
            ((IProfileColorContext) objectRef.CreateRef(typeof(IProfileColorContext)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IProgressiveLevelControl CreateRef(this IProgressiveLevelControl objectRef) => 
            ((IProgressiveLevelControl) objectRef.CreateRef(typeof(IProgressiveLevelControl)));
    }
}

