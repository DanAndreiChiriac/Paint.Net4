namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;

    [NativeInterfaceID("e87a44c4-b76e-4c47-8b09-298eb12a2714")]
    public interface IBitmapCodecInfo : IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        bool MatchesMimeType(string mimeType);

        string ColorManagementVersion { get; }

        ImagingContainerFormat ContainerFormat { get; }

        string DeviceManufacturer { get; }

        IList<string> DeviceModels { get; }

        IList<string> FileExtensions { get; }

        IList<string> MimeTypes { get; }

        IList<PixelFormat> PixelFormats { get; }

        bool SupportsAnimation { get; }

        bool SupportsChromaKey { get; }

        bool SupportsLossless { get; }

        bool SupportsMultiframe { get; }
    }
}

