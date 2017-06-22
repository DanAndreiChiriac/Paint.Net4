namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Collections.Generic;

    public static class RectDoubleUtil
    {
        public static PointDouble Clamp(RectDouble bounds, PointDouble point) => 
            new PointDouble(DoubleUtil.Clamp(point.x, bounds.Left, bounds.Right), DoubleUtil.Clamp(point.y, bounds.Top, bounds.Bottom));

        public static RectDouble FromPixelPoints(PointDouble a, PointDouble b)
        {
            RectDouble num = RectDouble.FromCorners(a, b);
            double num2 = num.Width + 1.0;
            num.Width = num2;
            num2 = num.Height + 1.0;
            num.Height = num2;
            return num;
        }

        public static RectDouble FromPixelPointsConstrained(PointDouble a, PointDouble b)
        {
            int num = Math.Sign((double) (b.X - a.X));
            int num2 = Math.Sign((double) (b.Y - a.Y));
            double num4 = Math.Min(Math.Abs((double) (b.X - a.X)), Math.Abs((double) (b.Y - a.Y)));
            double x = a.X + (num4 * num);
            double y = a.Y + (num4 * num2);
            PointDouble num7 = new PointDouble(x, y);
            return FromPixelPoints(a, num7);
        }

        public static RectDouble FromPoints(IList<PointDouble> points)
        {
            if (points.Count == 0)
            {
                return RectDouble.Zero;
            }
            PointDouble num = points[0];
            if (points.Count == 1)
            {
                return new RectDouble(num.X, num.Y, 0.0, 0.0);
            }
            PointDouble num2 = points[1];
            double num3 = Math.Min(num.X, num2.X);
            double num4 = Math.Min(num.Y, num2.Y);
            double num5 = Math.Max(num.X, num2.X);
            double num6 = Math.Max(num.Y, num2.Y);
            for (int i = 2; i < points.Count; i++)
            {
                PointDouble num8 = points[i];
                num3 = Math.Min(num3, num8.X);
                num4 = Math.Min(num4, num8.Y);
                num5 = Math.Max(num5, num8.X);
                num6 = Math.Max(num6, num8.Y);
            }
            return RectDouble.FromEdges(num3, num4, num5, num6);
        }

        public static RectDouble FromPointsConstrained(PointDouble a, PointDouble b)
        {
            int num = Math.Sign((double) (b.X - a.X));
            int num2 = Math.Sign((double) (b.Y - a.Y));
            double num4 = Math.Min(Math.Abs((double) (b.X - a.X)), Math.Abs((double) (b.Y - a.Y)));
            double x = a.X + (num4 * num);
            double y = a.Y + (num4 * num2);
            PointDouble num7 = new PointDouble(x, y);
            return RectDouble.FromCorners(a, num7);
        }

        public static RectDouble Union(RectDouble rect1, RectDouble? rect2)
        {
            if (rect2.HasValue)
            {
                return RectDouble.Union(rect1, rect2.GetValueOrDefault());
            }
            return rect1;
        }

        public static RectDouble? Union(RectDouble? rect1, RectDouble? rect2)
        {
            if (!rect1.HasValue && !rect2.HasValue)
            {
                return null;
            }
            if (rect1.HasValue && !rect2.HasValue)
            {
                return new RectDouble?(rect1.Value);
            }
            if (!rect1.HasValue && rect2.HasValue)
            {
                return new RectDouble?(rect2.Value);
            }
            return new RectDouble?(RectDouble.Union(rect1.Value, rect2.Value));
        }
    }
}

