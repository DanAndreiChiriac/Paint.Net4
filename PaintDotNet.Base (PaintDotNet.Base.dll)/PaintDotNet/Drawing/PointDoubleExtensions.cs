namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class PointDoubleExtensions
    {
        public static PointF ToGdipPointF(this PointDouble pt) => 
            new PointF((float) pt.X, (float) pt.Y);

        public static PointF[] ToPointFArray(this PointDouble[] pts)
        {
            PointF[] tfArray = new PointF[pts.Length];
            for (int i = 0; i < tfArray.Length; i++)
            {
                tfArray[i] = pts[i].ToGdipPointF();
            }
            return tfArray;
        }
    }
}

