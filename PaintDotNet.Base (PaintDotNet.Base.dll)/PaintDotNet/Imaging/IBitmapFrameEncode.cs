namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;
    using System.Collections.Generic;

    [NativeInterfaceID("00000105-a8f2-4877-ba0a-fd2b6645fb94")]
    public interface IBitmapFrameEncode : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        void Commit();
        PixelFormat SetPixelFormat(PixelFormat pixelFormat);
        void WritePixels(int lineCount, int stride, long bufferSize, IntPtr pixels);
        void WriteSource(IBitmapSource bitmapSource, RectInt32? rect);

        IEnumerable<IColorContext> ColorContexts { set; }

        IMetadataQueryWriter MetadataQueryWriter { get; }

        IPalette Palette { set; }

        VectorDouble Resolution { set; }

        SizeInt32 Size { set; }

        IBitmapSource Thumbnail { set; }
    }
}

