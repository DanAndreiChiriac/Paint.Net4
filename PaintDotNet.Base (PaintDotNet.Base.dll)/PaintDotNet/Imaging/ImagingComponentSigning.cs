namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum ImagingComponentSigning
    {
        Disabled = -2147483648,
        Safe = 4,
        Signed = 1,
        Unsigned = 2
    }
}

