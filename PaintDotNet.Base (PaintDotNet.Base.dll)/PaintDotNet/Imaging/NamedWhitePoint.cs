namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum NamedWhitePoint
    {
        AsShot = 1,
        AutoWhiteBalance = 0x200,
        Cloudy = 4,
        Custom = 0x100,
        Daylight = 2,
        Default = 1,
        Flash = 0x40,
        Fluorescent = 0x20,
        Shade = 8,
        Tungsten = 0x10,
        Underwater = 0x80
    }
}

