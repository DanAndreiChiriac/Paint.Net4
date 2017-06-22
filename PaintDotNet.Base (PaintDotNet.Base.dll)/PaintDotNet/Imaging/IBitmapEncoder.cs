namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("00000103-a8f2-4877-ba0a-fd2b6645fb94")]
    public interface IBitmapEncoder : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        void Commit();
        IBitmapFrameEncode CreateNewFrame(IEnumerable<KeyValuePair<string, object>> encoderOptions = null);
        Dictionary<string, object> GetFrameEncoderOptions();

        IEnumerable<IColorContext> ColorContexts { set; }

        ImagingContainerFormat ContainerFormat { get; }

        IBitmapEncoderInfo EncoderInfo { get; }

        IMetadataQueryWriter MetadataQueryWriter { get; }

        IPalette Palette { set; }

        IBitmapSource Preview { set; }

        IBitmapSource Thumbnail { set; }
    }
}

