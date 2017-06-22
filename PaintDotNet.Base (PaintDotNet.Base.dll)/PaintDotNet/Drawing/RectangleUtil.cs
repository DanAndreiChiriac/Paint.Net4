namespace PaintDotNet.Drawing
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public static class RectangleUtil
    {
        public static Rectangle Bounds(IEnumerable<Rectangle> rects)
        {
            using (IEnumerator<Rectangle> enumerator = rects.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return Rectangle.Empty;
                }
                Rectangle current = enumerator.Current;
                int left = current.Left;
                int top = current.Top;
                int right = current.Right;
                int bottom = current.Bottom;
                while (enumerator.MoveNext())
                {
                    Rectangle rectangle3 = enumerator.Current;
                    left = Math.Min(left, rectangle3.Left);
                    top = Math.Min(top, rectangle3.Top);
                    right = Math.Max(right, rectangle3.Right);
                    bottom = Math.Max(bottom, rectangle3.Bottom);
                }
                return Rectangle.FromLTRB(left, top, right, bottom);
            }
        }

        public static Rectangle Bounds(IList<Rectangle> rects) => 
            Bounds(rects, 0, rects.Count);

        public static Rectangle Bounds(Rectangle[] rects) => 
            Bounds(rects, 0, rects.Length);

        public static Rectangle Bounds(IList<Rectangle> rects, int startIndex, int length)
        {
            Validate.Begin().IsNotNull<IList<Rectangle>>(rects, "rects").Check().IsRangeValid(rects.Count, startIndex, length, "rects").Check();
            if (length == 0)
            {
                return Rectangle.Empty;
            }
            Rectangle rectangle = rects[startIndex];
            int left = rectangle.Left;
            int top = rectangle.Top;
            int right = rectangle.Right;
            int bottom = rectangle.Bottom;
            for (int i = startIndex + 1; i < (startIndex + length); i++)
            {
                Rectangle rectangle2 = rects[i];
                left = Math.Min(left, rectangle2.Left);
                top = Math.Min(top, rectangle2.Top);
                right = Math.Max(right, rectangle2.Right);
                bottom = Math.Max(bottom, rectangle2.Bottom);
            }
            return Rectangle.FromLTRB(left, top, right, bottom);
        }

        public static Rectangle Bounds(Rectangle[] rects, int startIndex, int length) => 
            Bounds((IList<Rectangle>) rects, startIndex, length);

        public static Rectangle Offset(Rectangle rect, int dx, int dy) => 
            new Rectangle(rect.Left + dx, rect.Top + dy, rect.Width, rect.Height);
    }
}

