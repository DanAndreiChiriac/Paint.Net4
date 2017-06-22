namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class FastMetadataEncoderProxy : ObjectRefProxy<IFastMetadataEncoder>, IFastMetadataEncoder, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FastMetadataEncoderProxy(IFastMetadataEncoder objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Commit()
        {
            base.innerRefT.Commit();
        }

        public IMetadataQueryWriter MetadataQueryWriter =>
            base.innerRefT.MetadataQueryWriter;
    }
}

