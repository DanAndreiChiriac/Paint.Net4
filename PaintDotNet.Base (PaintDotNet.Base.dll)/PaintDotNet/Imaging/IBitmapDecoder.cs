namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;

    [NativeInterfaceID("9edde9e7-8dee-47ea-99df-e6faf2ed44bf")]
    public interface IBitmapDecoder : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        IList<IColorContext> ColorContexts { get; }

        ImagingContainerFormat ContainerFormat { get; }

        IBitmapDecoderInfo DecoderInfo { get; }

        IList<IBitmapFrameDecode> Frames { get; }

        bool HasPalette { get; }

        IMetadataQueryReader MetadataQueryReader { get; }

        IPalette Palette { get; }

        IBitmapSource Preview { get; }

        IBitmapSource Thumbnail { get; }
    }
}

