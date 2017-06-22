namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct Colors
    {
        public static ColorBgra32 Zero =>
            new ColorBgra32();
        public static ColorBgra32 Transparent =>
            ColorBgra32.FromBgra(0xff, 0xff, 0xff, 0);
        public static ColorBgra32 TransparentBlack =>
            Zero;
        public static ColorBgra32 AliceBlue =>
            ColorBgra32.FromBgra(0xff, 0xf8, 240, 0xff);
        public static ColorBgra32 AntiqueWhite =>
            ColorBgra32.FromBgra(0xd7, 0xeb, 250, 0xff);
        public static ColorBgra32 Aqua =>
            ColorBgra32.FromBgra(0xff, 0xff, 0, 0xff);
        public static ColorBgra32 Aquamarine =>
            ColorBgra32.FromBgra(0xd4, 0xff, 0x7f, 0xff);
        public static ColorBgra32 Azure =>
            ColorBgra32.FromBgra(0xff, 0xff, 240, 0xff);
        public static ColorBgra32 Beige =>
            ColorBgra32.FromBgra(220, 0xf5, 0xf5, 0xff);
        public static ColorBgra32 Bisque =>
            ColorBgra32.FromBgra(0xc4, 0xe4, 0xff, 0xff);
        public static ColorBgra32 Black =>
            ColorBgra32.FromBgra(0, 0, 0, 0xff);
        public static ColorBgra32 BlanchedAlmond =>
            ColorBgra32.FromBgra(0xcd, 0xeb, 0xff, 0xff);
        public static ColorBgra32 Blue =>
            ColorBgra32.FromBgra(0xff, 0, 0, 0xff);
        public static ColorBgra32 BlueViolet =>
            ColorBgra32.FromBgra(0xe2, 0x2b, 0x8a, 0xff);
        public static ColorBgra32 Brown =>
            ColorBgra32.FromBgra(0x2a, 0x2a, 0xa5, 0xff);
        public static ColorBgra32 BurlyWood =>
            ColorBgra32.FromBgra(0x87, 0xb8, 0xde, 0xff);
        public static ColorBgra32 CadetBlue =>
            ColorBgra32.FromBgra(160, 0x9e, 0x5f, 0xff);
        public static ColorBgra32 Chartreuse =>
            ColorBgra32.FromBgra(0, 0xff, 0x7f, 0xff);
        public static ColorBgra32 Chocolate =>
            ColorBgra32.FromBgra(30, 0x69, 210, 0xff);
        public static ColorBgra32 Coral =>
            ColorBgra32.FromBgra(80, 0x7f, 0xff, 0xff);
        public static ColorBgra32 CornflowerBlue =>
            ColorBgra32.FromBgra(0xed, 0x95, 100, 0xff);
        public static ColorBgra32 Cornsilk =>
            ColorBgra32.FromBgra(220, 0xf8, 0xff, 0xff);
        public static ColorBgra32 Crimson =>
            ColorBgra32.FromBgra(60, 20, 220, 0xff);
        public static ColorBgra32 Cyan =>
            ColorBgra32.FromBgra(0xff, 0xff, 0, 0xff);
        public static ColorBgra32 DarkBlue =>
            ColorBgra32.FromBgra(0x8b, 0, 0, 0xff);
        public static ColorBgra32 DarkCyan =>
            ColorBgra32.FromBgra(0x8b, 0x8b, 0, 0xff);
        public static ColorBgra32 DarkGoldenrod =>
            ColorBgra32.FromBgra(11, 0x86, 0xb8, 0xff);
        public static ColorBgra32 DarkGray =>
            ColorBgra32.FromBgra(0xa9, 0xa9, 0xa9, 0xff);
        public static ColorBgra32 DarkGreen =>
            ColorBgra32.FromBgra(0, 100, 0, 0xff);
        public static ColorBgra32 DarkKhaki =>
            ColorBgra32.FromBgra(0x6b, 0xb7, 0xbd, 0xff);
        public static ColorBgra32 DarkMagenta =>
            ColorBgra32.FromBgra(0x8b, 0, 0x8b, 0xff);
        public static ColorBgra32 DarkOliveGreen =>
            ColorBgra32.FromBgra(0x2f, 0x6b, 0x55, 0xff);
        public static ColorBgra32 DarkOrange =>
            ColorBgra32.FromBgra(0, 140, 0xff, 0xff);
        public static ColorBgra32 DarkOrchid =>
            ColorBgra32.FromBgra(0xcc, 50, 0x99, 0xff);
        public static ColorBgra32 DarkRed =>
            ColorBgra32.FromBgra(0, 0, 0x8b, 0xff);
        public static ColorBgra32 DarkSalmon =>
            ColorBgra32.FromBgra(0x7a, 150, 0xe9, 0xff);
        public static ColorBgra32 DarkSeaGreen =>
            ColorBgra32.FromBgra(0x8b, 0xbc, 0x8f, 0xff);
        public static ColorBgra32 DarkSlateBlue =>
            ColorBgra32.FromBgra(0x8b, 0x3d, 0x48, 0xff);
        public static ColorBgra32 DarkSlateGray =>
            ColorBgra32.FromBgra(0x4f, 0x4f, 0x2f, 0xff);
        public static ColorBgra32 DarkTurquoise =>
            ColorBgra32.FromBgra(0xd1, 0xce, 0, 0xff);
        public static ColorBgra32 DarkViolet =>
            ColorBgra32.FromBgra(0xd3, 0, 0x94, 0xff);
        public static ColorBgra32 DeepPink =>
            ColorBgra32.FromBgra(0x93, 20, 0xff, 0xff);
        public static ColorBgra32 DeepSkyBlue =>
            ColorBgra32.FromBgra(0xff, 0xbf, 0, 0xff);
        public static ColorBgra32 DimGray =>
            ColorBgra32.FromBgra(0x69, 0x69, 0x69, 0xff);
        public static ColorBgra32 DodgerBlue =>
            ColorBgra32.FromBgra(0xff, 0x90, 30, 0xff);
        public static ColorBgra32 Firebrick =>
            ColorBgra32.FromBgra(0x22, 0x22, 0xb2, 0xff);
        public static ColorBgra32 FloralWhite =>
            ColorBgra32.FromBgra(240, 250, 0xff, 0xff);
        public static ColorBgra32 ForestGreen =>
            ColorBgra32.FromBgra(0x22, 0x8b, 0x22, 0xff);
        public static ColorBgra32 Fuchsia =>
            ColorBgra32.FromBgra(0xff, 0, 0xff, 0xff);
        public static ColorBgra32 Gainsboro =>
            ColorBgra32.FromBgra(220, 220, 220, 0xff);
        public static ColorBgra32 GhostWhite =>
            ColorBgra32.FromBgra(0xff, 0xf8, 0xf8, 0xff);
        public static ColorBgra32 Gold =>
            ColorBgra32.FromBgra(0, 0xd7, 0xff, 0xff);
        public static ColorBgra32 Goldenrod =>
            ColorBgra32.FromBgra(0x20, 0xa5, 0xda, 0xff);
        public static ColorBgra32 Gray =>
            ColorBgra32.FromBgra(0x80, 0x80, 0x80, 0xff);
        public static ColorBgra32 Green =>
            ColorBgra32.FromBgra(0, 0x80, 0, 0xff);
        public static ColorBgra32 GreenYellow =>
            ColorBgra32.FromBgra(0x2f, 0xff, 0xad, 0xff);
        public static ColorBgra32 Honeydew =>
            ColorBgra32.FromBgra(240, 0xff, 240, 0xff);
        public static ColorBgra32 HotPink =>
            ColorBgra32.FromBgra(180, 0x69, 0xff, 0xff);
        public static ColorBgra32 IndianRed =>
            ColorBgra32.FromBgra(0x5c, 0x5c, 0xcd, 0xff);
        public static ColorBgra32 Indigo =>
            ColorBgra32.FromBgra(130, 0, 0x4b, 0xff);
        public static ColorBgra32 Ivory =>
            ColorBgra32.FromBgra(240, 0xff, 0xff, 0xff);
        public static ColorBgra32 Khaki =>
            ColorBgra32.FromBgra(140, 230, 240, 0xff);
        public static ColorBgra32 Lavender =>
            ColorBgra32.FromBgra(250, 230, 230, 0xff);
        public static ColorBgra32 LavenderBlush =>
            ColorBgra32.FromBgra(0xf5, 240, 0xff, 0xff);
        public static ColorBgra32 LawnGreen =>
            ColorBgra32.FromBgra(0, 0xfc, 0x7c, 0xff);
        public static ColorBgra32 LemonChiffon =>
            ColorBgra32.FromBgra(0xcd, 250, 0xff, 0xff);
        public static ColorBgra32 LightBlue =>
            ColorBgra32.FromBgra(230, 0xd8, 0xad, 0xff);
        public static ColorBgra32 LightCoral =>
            ColorBgra32.FromBgra(0x80, 0x80, 240, 0xff);
        public static ColorBgra32 LightCyan =>
            ColorBgra32.FromBgra(0xff, 0xff, 0xe0, 0xff);
        public static ColorBgra32 LightGoldenrodYellow =>
            ColorBgra32.FromBgra(210, 250, 250, 0xff);
        public static ColorBgra32 LightGreen =>
            ColorBgra32.FromBgra(0x90, 0xee, 0x90, 0xff);
        public static ColorBgra32 LightGray =>
            ColorBgra32.FromBgra(0xd3, 0xd3, 0xd3, 0xff);
        public static ColorBgra32 LightPink =>
            ColorBgra32.FromBgra(0xc1, 0xb6, 0xff, 0xff);
        public static ColorBgra32 LightSalmon =>
            ColorBgra32.FromBgra(0x7a, 160, 0xff, 0xff);
        public static ColorBgra32 LightSeaGreen =>
            ColorBgra32.FromBgra(170, 0xb2, 0x20, 0xff);
        public static ColorBgra32 LightSkyBlue =>
            ColorBgra32.FromBgra(250, 0xce, 0x87, 0xff);
        public static ColorBgra32 LightSlateGray =>
            ColorBgra32.FromBgra(0x99, 0x88, 0x77, 0xff);
        public static ColorBgra32 LightSteelBlue =>
            ColorBgra32.FromBgra(0xde, 0xc4, 0xb0, 0xff);
        public static ColorBgra32 LightYellow =>
            ColorBgra32.FromBgra(0xe0, 0xff, 0xff, 0xff);
        public static ColorBgra32 Lime =>
            ColorBgra32.FromBgra(0, 0xff, 0, 0xff);
        public static ColorBgra32 LimeGreen =>
            ColorBgra32.FromBgra(50, 0xcd, 50, 0xff);
        public static ColorBgra32 Linen =>
            ColorBgra32.FromBgra(230, 240, 250, 0xff);
        public static ColorBgra32 Magenta =>
            ColorBgra32.FromBgra(0xff, 0, 0xff, 0xff);
        public static ColorBgra32 Maroon =>
            ColorBgra32.FromBgra(0, 0, 0x80, 0xff);
        public static ColorBgra32 MediumAquamarine =>
            ColorBgra32.FromBgra(170, 0xcd, 0x66, 0xff);
        public static ColorBgra32 MediumBlue =>
            ColorBgra32.FromBgra(0xcd, 0, 0, 0xff);
        public static ColorBgra32 MediumOrchid =>
            ColorBgra32.FromBgra(0xd3, 0x55, 0xba, 0xff);
        public static ColorBgra32 MediumPurple =>
            ColorBgra32.FromBgra(0xdb, 0x70, 0x93, 0xff);
        public static ColorBgra32 MediumSeaGreen =>
            ColorBgra32.FromBgra(0x71, 0xb3, 60, 0xff);
        public static ColorBgra32 MediumSlateBlue =>
            ColorBgra32.FromBgra(0xee, 0x68, 0x7b, 0xff);
        public static ColorBgra32 MediumSpringGreen =>
            ColorBgra32.FromBgra(0x9a, 250, 0, 0xff);
        public static ColorBgra32 MediumTurquoise =>
            ColorBgra32.FromBgra(0xcc, 0xd1, 0x48, 0xff);
        public static ColorBgra32 MediumVioletRed =>
            ColorBgra32.FromBgra(0x85, 0x15, 0xc7, 0xff);
        public static ColorBgra32 MidnightBlue =>
            ColorBgra32.FromBgra(0x70, 0x19, 0x19, 0xff);
        public static ColorBgra32 MintCream =>
            ColorBgra32.FromBgra(250, 0xff, 0xf5, 0xff);
        public static ColorBgra32 MistyRose =>
            ColorBgra32.FromBgra(0xe1, 0xe4, 0xff, 0xff);
        public static ColorBgra32 Moccasin =>
            ColorBgra32.FromBgra(0xb5, 0xe4, 0xff, 0xff);
        public static ColorBgra32 NavajoWhite =>
            ColorBgra32.FromBgra(0xad, 0xde, 0xff, 0xff);
        public static ColorBgra32 Navy =>
            ColorBgra32.FromBgra(0x80, 0, 0, 0xff);
        public static ColorBgra32 OldLace =>
            ColorBgra32.FromBgra(230, 0xf5, 0xfd, 0xff);
        public static ColorBgra32 Olive =>
            ColorBgra32.FromBgra(0, 0x80, 0x80, 0xff);
        public static ColorBgra32 OliveDrab =>
            ColorBgra32.FromBgra(0x23, 0x8e, 0x6b, 0xff);
        public static ColorBgra32 Orange =>
            ColorBgra32.FromBgra(0, 0xa5, 0xff, 0xff);
        public static ColorBgra32 OrangeRed =>
            ColorBgra32.FromBgra(0, 0x45, 0xff, 0xff);
        public static ColorBgra32 Orchid =>
            ColorBgra32.FromBgra(0xd6, 0x70, 0xda, 0xff);
        public static ColorBgra32 PaleGoldenrod =>
            ColorBgra32.FromBgra(170, 0xe8, 0xee, 0xff);
        public static ColorBgra32 PaleGreen =>
            ColorBgra32.FromBgra(0x98, 0xfb, 0x98, 0xff);
        public static ColorBgra32 PaleTurquoise =>
            ColorBgra32.FromBgra(0xee, 0xee, 0xaf, 0xff);
        public static ColorBgra32 PaleVioletRed =>
            ColorBgra32.FromBgra(0x93, 0x70, 0xdb, 0xff);
        public static ColorBgra32 PapayaWhip =>
            ColorBgra32.FromBgra(0xd5, 0xef, 0xff, 0xff);
        public static ColorBgra32 PeachPuff =>
            ColorBgra32.FromBgra(0xb9, 0xda, 0xff, 0xff);
        public static ColorBgra32 Peru =>
            ColorBgra32.FromBgra(0x3f, 0x85, 0xcd, 0xff);
        public static ColorBgra32 Pink =>
            ColorBgra32.FromBgra(0xcb, 0xc0, 0xff, 0xff);
        public static ColorBgra32 Plum =>
            ColorBgra32.FromBgra(0xdd, 160, 0xdd, 0xff);
        public static ColorBgra32 PowderBlue =>
            ColorBgra32.FromBgra(230, 0xe0, 0xb0, 0xff);
        public static ColorBgra32 Purple =>
            ColorBgra32.FromBgra(0x80, 0, 0x80, 0xff);
        public static ColorBgra32 Red =>
            ColorBgra32.FromBgra(0, 0, 0xff, 0xff);
        public static ColorBgra32 RosyBrown =>
            ColorBgra32.FromBgra(0x8f, 0x8f, 0xbc, 0xff);
        public static ColorBgra32 RoyalBlue =>
            ColorBgra32.FromBgra(0xe1, 0x69, 0x41, 0xff);
        public static ColorBgra32 SaddleBrown =>
            ColorBgra32.FromBgra(0x13, 0x45, 0x8b, 0xff);
        public static ColorBgra32 Salmon =>
            ColorBgra32.FromBgra(0x72, 0x80, 250, 0xff);
        public static ColorBgra32 SandyBrown =>
            ColorBgra32.FromBgra(0x60, 0xa4, 0xf4, 0xff);
        public static ColorBgra32 SeaGreen =>
            ColorBgra32.FromBgra(0x57, 0x8b, 0x2e, 0xff);
        public static ColorBgra32 SeaShell =>
            ColorBgra32.FromBgra(0xee, 0xf5, 0xff, 0xff);
        public static ColorBgra32 Sienna =>
            ColorBgra32.FromBgra(0x2d, 0x52, 160, 0xff);
        public static ColorBgra32 Silver =>
            ColorBgra32.FromBgra(0xc0, 0xc0, 0xc0, 0xff);
        public static ColorBgra32 SkyBlue =>
            ColorBgra32.FromBgra(0xeb, 0xce, 0x87, 0xff);
        public static ColorBgra32 SlateBlue =>
            ColorBgra32.FromBgra(0xcd, 90, 0x6a, 0xff);
        public static ColorBgra32 SlateGray =>
            ColorBgra32.FromBgra(0x90, 0x80, 0x70, 0xff);
        public static ColorBgra32 Snow =>
            ColorBgra32.FromBgra(250, 250, 0xff, 0xff);
        public static ColorBgra32 SpringGreen =>
            ColorBgra32.FromBgra(0x7f, 0xff, 0, 0xff);
        public static ColorBgra32 SteelBlue =>
            ColorBgra32.FromBgra(180, 130, 70, 0xff);
        public static ColorBgra32 Tan =>
            ColorBgra32.FromBgra(140, 180, 210, 0xff);
        public static ColorBgra32 Teal =>
            ColorBgra32.FromBgra(0x80, 0x80, 0, 0xff);
        public static ColorBgra32 Thistle =>
            ColorBgra32.FromBgra(0xd8, 0xbf, 0xd8, 0xff);
        public static ColorBgra32 Tomato =>
            ColorBgra32.FromBgra(0x47, 0x63, 0xff, 0xff);
        public static ColorBgra32 Turquoise =>
            ColorBgra32.FromBgra(0xd0, 0xe0, 0x40, 0xff);
        public static ColorBgra32 Violet =>
            ColorBgra32.FromBgra(0xee, 130, 0xee, 0xff);
        public static ColorBgra32 Wheat =>
            ColorBgra32.FromBgra(0xb3, 0xde, 0xf5, 0xff);
        public static ColorBgra32 White =>
            ColorBgra32.FromBgra(0xff, 0xff, 0xff, 0xff);
        public static ColorBgra32 WhiteSmoke =>
            ColorBgra32.FromBgra(0xf5, 0xf5, 0xf5, 0xff);
        public static ColorBgra32 Yellow =>
            ColorBgra32.FromBgra(0, 0xff, 0xff, 0xff);
        public static ColorBgra32 YellowGreen =>
            ColorBgra32.FromBgra(50, 0xcd, 0x9a, 0xff);
    }
}

