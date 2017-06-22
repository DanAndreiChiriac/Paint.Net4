namespace PaintDotNet.Imaging
{
    using System;

    public enum MetadataCreationOptions
    {
        AllowUnknown = 0,
        CreationMask = -65536,
        Default = 0,
        FailUnknown = 0x100000
    }
}

