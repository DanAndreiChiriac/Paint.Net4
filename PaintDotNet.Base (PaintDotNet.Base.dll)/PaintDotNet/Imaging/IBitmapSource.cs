namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;

    [CustomImplementationAllowed, NativeInterfaceID("00000120-a8f2-4877-ba0a-fd2b6645fb94")]
    public interface IBitmapSource : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        void CopyPixels(RectInt32? srcRect, int bufferStride, int bufferSize, IntPtr buffer);

        IPalette Palette { get; }

        PaintDotNet.Imaging.PixelFormat PixelFormat { get; }

        VectorDouble Resolution { get; }

        SizeInt32 Size { get; }
    }
}

