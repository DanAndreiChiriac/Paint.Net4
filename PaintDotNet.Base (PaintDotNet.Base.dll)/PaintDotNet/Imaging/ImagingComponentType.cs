namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum ImagingComponentType
    {
        AllComponents = 0x3f,
        Decoder = 1,
        Encoder = 2,
        MetadataReader = 8,
        MetadataWriter = 0x10,
        PixelFormat = 0x20,
        PixelFormatConverter = 4
    }
}

