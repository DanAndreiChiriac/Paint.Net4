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
    public class BitmapCodecInfoProxy : ObjectRefProxy<IBitmapCodecInfo>, IBitmapCodecInfo, IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapCodecInfoProxy(IBitmapCodecInfo objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MatchesMimeType(string mimeType) => 
            base.innerRefT.MatchesMimeType(mimeType);

        public string Author =>
            base.innerRefT.Author;

        public string ColorManagementVersion =>
            base.innerRefT.ColorManagementVersion;

        public Guid ComponentGuid =>
            base.innerRefT.ComponentGuid;

        public ImagingComponentType ComponentType =>
            base.innerRefT.ComponentType;

        public ImagingContainerFormat ContainerFormat =>
            base.innerRefT.ContainerFormat;

        public string DeviceManufacturer =>
            base.innerRefT.DeviceManufacturer;

        public IList<string> DeviceModels =>
            base.innerRefT.DeviceModels;

        public IList<string> FileExtensions =>
            base.innerRefT.FileExtensions;

        public string FriendlyName =>
            base.innerRefT.FriendlyName;

        public IList<string> MimeTypes =>
            base.innerRefT.MimeTypes;

        public IList<PixelFormat> PixelFormats =>
            base.innerRefT.PixelFormats;

        public ImagingComponentSigning SigningStatus =>
            base.innerRefT.SigningStatus;

        public string SpecificationVersion =>
            base.innerRefT.SpecificationVersion;

        public bool SupportsAnimation =>
            base.innerRefT.SupportsAnimation;

        public bool SupportsChromaKey =>
            base.innerRefT.SupportsChromaKey;

        public bool SupportsLossless =>
            base.innerRefT.SupportsLossless;

        public bool SupportsMultiframe =>
            base.innerRefT.SupportsMultiframe;

        public ImagingVendor Vendor =>
            base.innerRefT.Vendor;

        public string Version =>
            base.innerRefT.Version;
    }
}

