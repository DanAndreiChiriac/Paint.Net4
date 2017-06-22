namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class RectangleExtensions
    {
        public static long Area(this Rectangle rect) => 
            ((long) (rect.Width * rect.Height));

        public static bool HasPositiveArea(this Rectangle rect) => 
            ((rect.Width > 0) && (rect.Height > 0));

        public static bool HasZeroArea(this Rectangle rect)
        {
            if (rect.Width != 0)
            {
                return (rect.Height == 0);
            }
            return true;
        }

        public static bool PixelsIntersectWith(this Rectangle rect1, Rectangle rect2)
        {
            Rectangle rect = Rectangle.Intersect(rect1, rect2);
            return (rect1.IntersectsWith(rect2) && rect.HasPositiveArea());
        }

        public static RectDouble ToRectDouble(this Rectangle rect) => 
            new RectDouble((double) rect.X, (double) rect.Y, (double) rect.Width, (double) rect.Height);

        public static RectFloat ToRectFloat(this Rectangle rect) => 
            new RectFloat((float) rect.X, (float) rect.Y, (float) rect.Width, (float) rect.Height);

        public static RectInt32 ToRectInt32(this Rectangle rect) => 
            new RectInt32(rect.Left, rect.Top, rect.Width, rect.Height);

        public static RectInt32[] ToRectInt32Array(this Rectangle[] array)
        {
            if (array.Length == 0)
            {
                return Array.Empty<RectInt32>();
            }
            RectInt32[] numArray = new RectInt32[array.Length];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = array[i].ToRectInt32();
            }
            return numArray;
        }

        public static Rectangle[] TranslateCopy(this Rectangle[] rects, int dx, int dy)
        {
            Rectangle[] rectangleArray = new Rectangle[rects.Length];
            for (int i = 0; i < rects.Length; i++)
            {
                rectangleArray[i] = new Rectangle(rects[i].X + dx, rects[i].Y + dy, rects[i].Width, rects[i].Height);
            }
            return rectangleArray;
        }
    }
}

