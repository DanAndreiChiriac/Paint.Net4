namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BitmapFrameDecodeProxy : ObjectRefProxy<IBitmapFrameDecode>, IBitmapFrameDecode, IBitmapSource, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapFrameDecodeProxy(IBitmapFrameDecode objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyPixels(RectInt32? srcRect, int bufferStride, int bufferSize, IntPtr buffer)
        {
            base.innerRefT.CopyPixels(srcRect, bufferStride, bufferSize, buffer);
        }

        public IList<IColorContext> ColorContexts =>
            base.innerRefT.ColorContexts;

        public IMetadataQueryReader MetadataQueryReader =>
            base.innerRefT.MetadataQueryReader;

        public IPalette Palette =>
            base.innerRefT.Palette;

        public PaintDotNet.Imaging.PixelFormat PixelFormat =>
            base.innerRefT.PixelFormat;

        public VectorDouble Resolution =>
            base.innerRefT.Resolution;

        public SizeInt32 Size =>
            base.innerRefT.Size;

        public IBitmapSource Thumbnail =>
            base.innerRefT.Thumbnail;
    }
}

