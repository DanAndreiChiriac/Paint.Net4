namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class SizeExtensions
    {
        public static long Area(this Size size) => 
            (size.Width * size.Height);

        public static SizeDouble ToSizeDouble(this Size size) => 
            new SizeDouble((double) size.Width, (double) size.Height);

        public static SizeInt32 ToSizeInt32(this Size size) => 
            new SizeInt32(size.Width, size.Height);
    }
}

