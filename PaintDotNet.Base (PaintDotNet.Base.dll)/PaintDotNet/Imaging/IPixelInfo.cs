namespace PaintDotNet.Imaging
{
    using System;

    public interface IPixelInfo
    {
        int BitsPerPixel { get; }

        PaintDotNet.Imaging.PixelFormat PixelFormat { get; }
    }
}

