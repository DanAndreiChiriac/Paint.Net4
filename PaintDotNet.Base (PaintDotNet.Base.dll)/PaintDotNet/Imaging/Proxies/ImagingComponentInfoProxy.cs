namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class ImagingComponentInfoProxy : ObjectRefProxy<IImagingComponentInfo>, IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ImagingComponentInfoProxy(IImagingComponentInfo objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public string Author =>
            base.innerRefT.Author;

        public Guid ComponentGuid =>
            base.innerRefT.ComponentGuid;

        public ImagingComponentType ComponentType =>
            base.innerRefT.ComponentType;

        public string FriendlyName =>
            base.innerRefT.FriendlyName;

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

