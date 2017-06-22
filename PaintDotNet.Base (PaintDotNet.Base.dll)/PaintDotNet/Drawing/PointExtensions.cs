namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class PointExtensions
    {
        public static PointDouble ToPointDouble(this Point pt) => 
            new PointDouble((double) pt.X, (double) pt.Y);

        public static PointInt32 ToPointInt32(this Point pt) => 
            new PointInt32(pt.X, pt.Y);
    }
}

