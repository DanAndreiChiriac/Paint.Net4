namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct PixelFormat : IEquatable<PixelFormat>
    {
        private System.Guid guid;
        public System.Guid Guid =>
            this.guid;
        public static explicit operator PixelFormat(System.Guid guid) => 
            new PixelFormat(guid);

        public static explicit operator System.Guid(PixelFormat pixelFormat) => 
            pixelFormat.Guid;

        public PixelFormat(System.Guid guid)
        {
            this.guid = guid;
        }

        public override string ToString() => 
            this.guid.ToString();

        public bool Equals(PixelFormat other) => 
            (this.guid == other.guid);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<PixelFormat, object>(this, obj);

        public static bool operator ==(PixelFormat a, PixelFormat b) => 
            a.Equals(b);

        public static bool operator !=(PixelFormat a, PixelFormat b) => 
            !(a == b);

        public override int GetHashCode() => 
            this.guid.GetHashCode();

        public bool TryGetBitsPerPixel(out int bpp)
        {
            bool flag = true;
            if (this == PixelFormats.Alpha8)
            {
                bpp = 8;
                return flag;
            }
            if (this == PixelFormats.Gray8)
            {
                bpp = 8;
                return flag;
            }
            if (this == PixelFormats.Bgr24)
            {
                bpp = 0x18;
                return flag;
            }
            if (this == PixelFormats.Rgb24)
            {
                bpp = 0x18;
                return flag;
            }
            if (this == PixelFormats.Bgr32)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Bgra32)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Pbgra32)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Rgba32)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Prgba32)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Indexed1)
            {
                bpp = 1;
                return flag;
            }
            if (this == PixelFormats.Indexed2)
            {
                bpp = 2;
                return flag;
            }
            if (this == PixelFormats.Indexed4)
            {
                bpp = 4;
                return flag;
            }
            if (this == PixelFormats.Indexed8)
            {
                bpp = 8;
                return flag;
            }
            if (this == PixelFormats.BlackWhite)
            {
                bpp = 1;
                return flag;
            }
            if (this == PixelFormats.Gray2)
            {
                bpp = 2;
                return flag;
            }
            if (this == PixelFormats.Gray4)
            {
                bpp = 4;
                return flag;
            }
            if (this == PixelFormats.Bgr16_555)
            {
                bpp = 0x10;
                return flag;
            }
            if (this == PixelFormats.Bgr16_565)
            {
                bpp = 0x10;
                return flag;
            }
            if (this == PixelFormats.Bgra16_5551)
            {
                bpp = 0x10;
                return flag;
            }
            if (this == PixelFormats.Gray16)
            {
                bpp = 0x10;
                return flag;
            }
            if (this == PixelFormats.Gray32Float)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Rgb48)
            {
                bpp = 0x30;
                return flag;
            }
            if (this == PixelFormats.Bgr48)
            {
                bpp = 0x30;
                return flag;
            }
            if (this == PixelFormats.Rgba64)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Bgra64)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Prgba64)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Pbgra64)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Gray16Fixed)
            {
                bpp = 0x10;
                return flag;
            }
            if (this == PixelFormats.Bgr32_101010)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Rgb48Fixed)
            {
                bpp = 0x30;
                return flag;
            }
            if (this == PixelFormats.Bgr48Fixed)
            {
                bpp = 0x30;
                return flag;
            }
            if (this == PixelFormats.Rgb96Fixed)
            {
                bpp = 0x60;
                return flag;
            }
            if (this == PixelFormats.Rgba128Float)
            {
                bpp = 0x80;
                return flag;
            }
            if (this == PixelFormats.Prgba128Float)
            {
                bpp = 0x80;
                return flag;
            }
            if (this == PixelFormats.Rgb128Float)
            {
                bpp = 0x80;
                return flag;
            }
            if (this == PixelFormats.Cmyk32)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Rgba64Fixed)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Bgra64Fixed)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Rgb64Fixed)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Rgba128Fixed)
            {
                bpp = 0x80;
                return flag;
            }
            if (this == PixelFormats.Rgb128Fixed)
            {
                bpp = 0x80;
                return flag;
            }
            if (this == PixelFormats.Rgba64Half)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Rgb64Half)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.Rgb48Half)
            {
                bpp = 0x30;
                return flag;
            }
            if (this == PixelFormats.Rgbe32)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Gray16Half)
            {
                bpp = 0x10;
                return flag;
            }
            if (this == PixelFormats.Gray32Fixed)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Rgba32_1010102)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Rgba32_1010102_XR)
            {
                bpp = 0x20;
                return flag;
            }
            if (this == PixelFormats.Cmyk64)
            {
                bpp = 0x40;
                return flag;
            }
            if (this == PixelFormats.DontCare)
            {
                bpp = -1;
                return false;
            }
            bpp = -1;
            return false;
        }
    }
}

