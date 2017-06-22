namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class RectDoubleExtensions
    {
        public static RectangleF ToGdipRectangleF(this RectDouble rect) => 
            new RectangleF((float) rect.X, (float) rect.Y, (float) rect.Width, (float) rect.Height);
    }
}

