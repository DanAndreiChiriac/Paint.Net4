namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class RectInt32Extensions
    {
        public static Rectangle ToGdipRectangle(this RectInt32 rect) => 
            new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
    }
}

