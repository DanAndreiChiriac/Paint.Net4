namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class RectangleFExtensions
    {
        public static float Area(this RectangleF rect) => 
            (rect.Width * rect.Height);

        public static Rectangle RoundBound(this RectangleF rectF)
        {
            float top = (float) Math.Floor((double) rectF.Top);
            float right = (float) Math.Ceiling((double) rectF.Right);
            float bottom = (float) Math.Ceiling((double) rectF.Bottom);
            return Rectangle.Truncate(RectangleF.FromLTRB((float) Math.Floor((double) rectF.Left), top, right, bottom));
        }

        public static RectDouble ToRectDouble(this RectangleF gdipRectF) => 
            new RectDouble((double) gdipRectF.X, (double) gdipRectF.Y, (double) gdipRectF.Width, (double) gdipRectF.Height);
    }
}

