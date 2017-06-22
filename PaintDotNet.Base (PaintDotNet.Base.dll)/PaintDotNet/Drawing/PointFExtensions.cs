namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class PointFExtensions
    {
        public static float Length(this PointF pt) => 
            ((float) Math.Sqrt((double) ((pt.X * pt.X) + (pt.Y * pt.Y))));

        public static PointF MultiplyCopy(this PointF ptF, float scale) => 
            new PointF(ptF.X * scale, ptF.Y * scale);

        public static PointF OffsetCopy(this PointF ptF, PointF ptT) => 
            new PointF(ptF.X + ptT.X, ptF.Y + ptT.Y);

        public static PointF OffsetCopy(this PointF ptF, float tX, float tY) => 
            new PointF(ptF.X + tX, ptF.Y + tY);

        public static PointDouble ToDoublePoint(this PointF ptF) => 
            new PointDouble((double) ptF.X, (double) ptF.Y);

        public static PointF TruncateCopy(this PointF ptF) => 
            new PointF((float) Math.Truncate((double) ptF.X), (float) Math.Truncate((double) ptF.Y));
    }
}

