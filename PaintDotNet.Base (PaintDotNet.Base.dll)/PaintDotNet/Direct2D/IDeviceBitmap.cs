namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;

    [NativeInterfaceID("a2296057-ea42-4099-983b-539fb6505426")]
    public interface IDeviceBitmap : IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        void CopyFromBitmap(PointInt32? destPoint, IDeviceBitmap bitmap, RectInt32? srcRect);
        void CopyFromMemory(RectInt32? dstRect, IntPtr srcData, int stride);
        void CopyFromRenderTarget(PointInt32? destPoint, IRenderTarget renderTarget, RectInt32? srcRect);

        VectorFloat Dpi { get; }

        Direct2DPixelFormat PixelFormat { get; }

        SizeInt32 PixelSize { get; }

        SizeFloat Size { get; }
    }
}

