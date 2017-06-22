namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("23bc3f0a-698b-4357-886b-f24d50671334")]
    public interface IImagingComponentInfo : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        string Author { get; }

        Guid ComponentGuid { get; }

        ImagingComponentType ComponentType { get; }

        string FriendlyName { get; }

        ImagingComponentSigning SigningStatus { get; }

        string SpecificationVersion { get; }

        ImagingVendor Vendor { get; }

        string Version { get; }
    }
}

