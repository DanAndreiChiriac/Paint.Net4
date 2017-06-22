namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class SizeInt32Extensions
    {
        public static Size ToGdipSize(this SizeInt32 size) => 
            new Size(size.Width, size.Height);
    }
}

