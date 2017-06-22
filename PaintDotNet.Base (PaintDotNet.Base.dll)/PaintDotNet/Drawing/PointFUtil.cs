namespace PaintDotNet.Drawing
{
    using System;
    using System.Drawing;

    public static class PointFUtil
    {
        public static float Distance(PointF a, PointF b) => 
            new PointF(a.X - b.X, a.Y - b.Y).Length();

        public static PointF Lerp(PointF a, PointF b, float t) => 
            new PointF(a.X + (t * (b.X - a.X)), a.Y + (t * (b.Y - a.Y)));
    }
}

