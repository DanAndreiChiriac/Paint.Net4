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
    public class PixelFormatInfoProxy : ObjectRefProxy<IPixelFormatInfo>, IPixelFormatInfo, IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PixelFormatInfoProxy(IPixelFormatInfo objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public string Author =>
            base.innerRefT.Author;

        public int BitsPerPixel =>
            base.innerRefT.BitsPerPixel;

        public int ChannelCount =>
            base.innerRefT.ChannelCount;

        public IList<IList<byte>> ChannelMasks =>
            base.innerRefT.ChannelMasks;

        public IColorContext ColorContext =>
            base.innerRefT.ColorContext;

        public Guid ComponentGuid =>
            base.innerRefT.ComponentGuid;

        public ImagingComponentType ComponentType =>
            base.innerRefT.ComponentType;

        public string FriendlyName =>
            base.innerRefT.FriendlyName;

        public PaintDotNet.Imaging.PixelFormat PixelFormat =>
            base.innerRefT.PixelFormat;

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

