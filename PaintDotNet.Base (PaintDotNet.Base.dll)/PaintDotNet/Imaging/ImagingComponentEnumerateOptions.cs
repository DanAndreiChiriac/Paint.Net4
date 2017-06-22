namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum ImagingComponentEnumerateOptions
    {
        BuiltInOnly = 0x20000000,
        Default = 0,
        Disabled = -2147483648,
        Refresh = 1,
        Unsigned = 0x40000000
    }
}

