namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum ImagingPersistOptions
    {
        BigEndian = 1,
        Default = 0,
        LittleEndian = 0,
        Mask = 0xffff,
        NoCacheStream = 4,
        PreferUtf8 = 8,
        StrictFormat = 2
    }
}

