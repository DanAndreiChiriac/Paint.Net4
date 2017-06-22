namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BitmapDecoderInfoProxy : ObjectRefProxy<IBitmapDecoderInfo>, IBitmapDecoderInfo, IBitmapCodecInfo, IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapDecoderInfoProxy(IBitmapDecoderInfo objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapDecoder CreateInstance(Stream stream, BitmapDecodeOptions cacheOptions) => 
            base.innerRefT.CreateInstance(stream, cacheOptions);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MatchesMimeType(string mimeType) => 
            base.innerRefT.MatchesMimeType(mimeType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MatchesPattern(Stream stream) => 
            base.innerRefT.MatchesPattern(stream);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapDecoderCapabilities QueryCapability(Stream stream) => 
            base.innerRefT.QueryCapability(stream);

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

        public IList<BitmapPattern> Patterns =>
            base.innerRefT.Patterns;

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

