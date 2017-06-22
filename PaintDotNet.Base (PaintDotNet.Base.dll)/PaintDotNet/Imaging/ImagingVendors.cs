namespace PaintDotNet.Imaging
{
    using System;

    public static class ImagingVendors
    {
        public static ImagingVendor Microsoft =>
            new ImagingVendor(new Guid(0x69fd0fdc, 0xa866, 0x4108, 0xb3, 0xb2, 0x98, 0x44, 0x7f, 0xa9, 0xed, 0xd4));

        public static ImagingVendor MicrosoftBuiltIn =>
            new ImagingVendor(new Guid(0x257a30fd, 0x6b6, 0x462b, 0xae, 0xa4, 0x63, 0xf7, 11, 0x86, 0xe5, 0x33));
    }
}

