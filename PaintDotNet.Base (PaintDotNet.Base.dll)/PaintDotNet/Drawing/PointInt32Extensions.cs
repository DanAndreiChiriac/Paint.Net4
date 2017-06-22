namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class PointInt32Extensions
    {
        public static Point ToGdipPoint(this PointInt32 pt) => 
            new Point(pt.X, pt.Y);
    }
}

