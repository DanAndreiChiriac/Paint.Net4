namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DeviceBitmapProxy : ObjectRefProxy<IDeviceBitmap>, IDeviceBitmap, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DeviceBitmapProxy(IDeviceBitmap objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromBitmap(PointInt32? destPoint, IDeviceBitmap bitmap, RectInt32? srcRect)
        {
            base.innerRefT.CopyFromBitmap(destPoint, bitmap, srcRect);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromMemory(RectInt32? dstRect, IntPtr srcData, int stride)
        {
            base.innerRefT.CopyFromMemory(dstRect, srcData, stride);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromRenderTarget(PointInt32? destPoint, IRenderTarget renderTarget, RectInt32? srcRect)
        {
            base.innerRefT.CopyFromRenderTarget(destPoint, renderTarget, srcRect);
        }

        public VectorFloat Dpi =>
            base.innerRefT.Dpi;

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;

        public Direct2DPixelFormat PixelFormat =>
            base.innerRefT.PixelFormat;

        public SizeInt32 PixelSize =>
            base.innerRefT.PixelSize;

        public SizeFloat Size =>
            base.innerRefT.Size;
    }
}

