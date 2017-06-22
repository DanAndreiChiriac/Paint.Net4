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
    public class BitmapDecoderProxy : ObjectRefProxy<IBitmapDecoder>, IBitmapDecoder, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapDecoderProxy(IBitmapDecoder objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public IList<IColorContext> ColorContexts =>
            base.innerRefT.ColorContexts;

        public ImagingContainerFormat ContainerFormat =>
            base.innerRefT.ContainerFormat;

        public IBitmapDecoderInfo DecoderInfo =>
            base.innerRefT.DecoderInfo;

        public IList<IBitmapFrameDecode> Frames =>
            base.innerRefT.Frames;

        public bool HasPalette =>
            base.innerRefT.HasPalette;

        public IMetadataQueryReader MetadataQueryReader =>
            base.innerRefT.MetadataQueryReader;

        public IPalette Palette =>
            base.innerRefT.Palette;

        public IBitmapSource Preview =>
            base.innerRefT.Preview;

        public IBitmapSource Thumbnail =>
            base.innerRefT.Thumbnail;
    }
}

