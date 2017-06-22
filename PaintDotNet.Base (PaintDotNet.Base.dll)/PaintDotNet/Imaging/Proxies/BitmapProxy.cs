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
    public class BitmapProxy : ObjectRefProxy<IBitmap>, IBitmap, IBitmapSource, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapProxy(IBitmap objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyPixels(RectInt32? srcRect, int bufferStride, int bufferSize, IntPtr buffer)
        {
            base.innerRefT.CopyPixels(srcRect, bufferStride, bufferSize, buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapLock Lock(RectInt32 rect, BitmapLockOptions lockOptions) => 
            base.innerRefT.Lock(rect, lockOptions);

        IPalette IBitmapSource.Palette =>
            base.innerRefT.Palette;

        VectorDouble IBitmapSource.Resolution =>
            base.innerRefT.Resolution;

        public IPalette Palette
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Palette;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Palette = value;
            }
        }

        public PaintDotNet.Imaging.PixelFormat PixelFormat =>
            base.innerRefT.PixelFormat;

        public VectorDouble Resolution
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Resolution;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Resolution = value;
            }
        }

        public SizeInt32 Size =>
            base.innerRefT.Size;
    }
}

