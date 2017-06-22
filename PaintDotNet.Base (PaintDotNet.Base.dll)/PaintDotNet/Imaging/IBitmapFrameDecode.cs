namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;

    [NativeInterfaceID("3b16811b-6a43-4ec9-a813-3d930c13b940")]
    public interface IBitmapFrameDecode : IBitmapSource, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        IList<IColorContext> ColorContexts { get; }

        IMetadataQueryReader MetadataQueryReader { get; }

        IBitmapSource Thumbnail { get; }
    }
}

