namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;
    using System.IO;

    [NativeInterfaceID("d8cd007f-d08f-4191-9bfc-236ea7f0e4b5")]
    public interface IBitmapDecoderInfo : IBitmapCodecInfo, IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        IBitmapDecoder CreateInstance(Stream stream, BitmapDecodeOptions cacheOptions);
        bool MatchesPattern(Stream stream);
        BitmapDecoderCapabilities QueryCapability(Stream stream);

        IList<BitmapPattern> Patterns { get; }
    }
}

