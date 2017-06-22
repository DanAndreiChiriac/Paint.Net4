namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BitmapSourceProxy<TPixel> : ObjectRefProxy<IBitmapSource<TPixel>>, IBitmapSource<TPixel>, IBitmapSource, IImagingObject, IObjectRef, IDisposable, IIsDisposed where TPixel: struct, INaturalPixelInfo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapSourceProxy(IBitmapSource<TPixel> objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyPixels(RectInt32? srcRect, int bufferStride, int bufferSize, IntPtr buffer)
        {
            base.innerRefT.CopyPixels(srcRect, bufferStride, bufferSize, buffer);
        }

        public IPalette Palette =>
            base.innerRefT.Palette;

        public PaintDotNet.Imaging.PixelFormat PixelFormat =>
            base.innerRefT.PixelFormat;

        public VectorDouble Resolution =>
            base.innerRefT.Resolution;

        public SizeInt32 Size =>
            base.innerRefT.Size;
    }
}

