namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum ImagingProgressNotification
    {
        All = -65536,
        Begin = 0x10000,
        End = 0x20000,
        Frequent = 0x40000
    }
}

