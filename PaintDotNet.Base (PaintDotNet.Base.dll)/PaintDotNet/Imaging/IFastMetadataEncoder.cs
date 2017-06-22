namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("b84e2c09-78c9-4ac4-8bd3-524ae1663a2f")]
    public interface IFastMetadataEncoder : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        void Commit();

        IMetadataQueryWriter MetadataQueryWriter { get; }
    }
}

