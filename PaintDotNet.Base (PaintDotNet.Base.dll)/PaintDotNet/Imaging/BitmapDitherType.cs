namespace PaintDotNet.Imaging
{
    using System;

    public enum BitmapDitherType
    {
        DualSpiral4x4 = 6,
        DualSpiral8x8 = 7,
        ErrorDiffusion = 8,
        None = 0,
        Ordered16x16 = 3,
        Ordered4x4 = 1,
        Ordered8x8 = 2,
        Solid = 0,
        Spiral4x4 = 4,
        Spiral8x8 = 5
    }
}

