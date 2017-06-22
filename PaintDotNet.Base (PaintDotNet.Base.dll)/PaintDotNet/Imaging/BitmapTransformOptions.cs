namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum BitmapTransformOptions
    {
        FlipHorizontal = 8,
        FlipVertical = 0x10,
        None = 0,
        Rotate180 = 2,
        Rotate270 = 3,
        Rotate90 = 1
    }
}

