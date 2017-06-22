namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class FormatConverterInfoProxy : ObjectRefProxy<IFormatConverterInfo>, IFormatConverterInfo, IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FormatConverterInfoProxy(IFormatConverterInfo objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CanConvert(PixelFormat srcPixelFormat, PixelFormat dstPixelFormat) => 
            base.innerRefT.CanConvert(srcPixelFormat, dstPixelFormat);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapSource CreateInstance(IBitmapSource source, PixelFormat dstFormat, BitmapDitherType dither, IPalette palette, double alphaThresholdPercent, BitmapPaletteType paletteTranslate) => 
            base.innerRefT.CreateInstance(source, dstFormat, dither, palette, alphaThresholdPercent, paletteTranslate);

        public string Author =>
            base.innerRefT.Author;

        public Guid ComponentGuid =>
            base.innerRefT.ComponentGuid;

        public ImagingComponentType ComponentType =>
            base.innerRefT.ComponentType;

        public string FriendlyName =>
            base.innerRefT.FriendlyName;

        public IList<PixelFormat> PixelFormats =>
            base.innerRefT.PixelFormats;

        public ImagingComponentSigning SigningStatus =>
            base.innerRefT.SigningStatus;

        public string SpecificationVersion =>
            base.innerRefT.SpecificationVersion;

        public ImagingVendor Vendor =>
            base.innerRefT.Vendor;

        public string Version =>
            base.innerRefT.Version;
    }
}

