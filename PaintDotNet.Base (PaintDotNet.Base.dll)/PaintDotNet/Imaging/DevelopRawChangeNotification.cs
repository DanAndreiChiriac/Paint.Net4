namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum DevelopRawChangeNotification
    {
        Contrast = 0x10,
        DestinationColorContext = 0x400,
        ExposureCompensation = 1,
        Gamma = 0x20,
        KelvinWhitePoint = 4,
        NamedWhitePoint = 2,
        NoiseReduction = 0x200,
        RenderMode = 0x2000,
        RgbWhitePoint = 8,
        Rotation = 0x1000,
        Saturation = 0x80,
        Sharpness = 0x40,
        Tint = 0x100,
        ToneCurve = 0x800
    }
}

