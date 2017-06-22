namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum BitmapLockOptions
    {
        Read = 1,
        ReadWrite = 3,
        Write = 2
    }
}

