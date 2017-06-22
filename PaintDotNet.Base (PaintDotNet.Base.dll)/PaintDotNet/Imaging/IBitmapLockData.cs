namespace PaintDotNet.Imaging
{
    using PaintDotNet.Rendering;
    using System;

    public interface IBitmapLockData
    {
        int BufferSize { get; }

        PaintDotNet.Imaging.PixelFormat PixelFormat { get; }

        IntPtr Scan0 { get; }

        SizeInt32 Size { get; }

        int Stride { get; }
    }
}

