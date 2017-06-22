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
    public class BitmapLockProxy : ObjectRefProxy<IBitmapLock>, IBitmapLock, IImagingObject, IObjectRef, IDisposable, IIsDisposed, IBitmapLockData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapLockProxy(IBitmapLock objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public int BufferSize =>
            base.innerRefT.BufferSize;

        public PaintDotNet.Imaging.PixelFormat PixelFormat =>
            base.innerRefT.PixelFormat;

        public IntPtr Scan0 =>
            base.innerRefT.Scan0;

        public SizeInt32 Size =>
            base.innerRefT.Size;

        public int Stride =>
            base.innerRefT.Stride;
    }
}

