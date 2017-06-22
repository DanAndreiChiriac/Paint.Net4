namespace PaintDotNet.Drawing
{
    using PaintDotNet;
    using PaintDotNet.Imaging;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ColorRgba128FloatExtensions
    {
        public static Color ToGdipColor(this ColorRgba128Float color, MidpointRounding roundingMode = 1)
        {
            byte red = Int32Util.ClampToByte((int) Math.Round((double) (color.r * 255.0), roundingMode));
            byte green = Int32Util.ClampToByte((int) Math.Round((double) (color.g * 255.0), roundingMode));
            byte blue = Int32Util.ClampToByte((int) Math.Round((double) (color.b * 255.0), roundingMode));
            return Color.FromArgb(Int32Util.ClampToByte((int) Math.Round((double) (color.a * 255.0), roundingMode)), red, green, blue);
        }
    }
}

