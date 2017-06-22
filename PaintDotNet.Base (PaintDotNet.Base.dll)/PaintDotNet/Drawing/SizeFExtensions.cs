namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class SizeFExtensions
    {
        public static SizeDouble ToSizeDouble(this SizeF size) => 
            new SizeDouble((double) size.Width, (double) size.Height);

        public static SizeFloat ToSizeFloat(this SizeF size) => 
            new SizeFloat(size.Width, size.Height);
    }
}

