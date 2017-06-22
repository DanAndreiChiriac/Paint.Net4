namespace PaintDotNet.Imaging
{
    using System;

    [Flags]
    public enum BitmapDecoderCapabilities
    {
        CanDecodeAllImages = 2,
        CanDecodeSomeImages = 4,
        CanDecodeThumbnail = 0x10,
        CanEnumerateMetadata = 8,
        SameEncoder = 1
    }
}

