namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class ExifColorSpaceColorContextProxy : ObjectRefProxy<IExifColorSpaceColorContext>, IExifColorSpaceColorContext, IColorContext, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ExifColorSpaceColorContextProxy(IExifColorSpaceColorContext objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public PaintDotNet.Imaging.ExifColorSpace ExifColorSpace =>
            base.innerRefT.ExifColorSpace;

        public ColorContextType Type =>
            base.innerRefT.Type;
    }
}

