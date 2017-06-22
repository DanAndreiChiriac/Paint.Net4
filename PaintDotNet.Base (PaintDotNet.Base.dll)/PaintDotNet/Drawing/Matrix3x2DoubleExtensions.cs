namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;

    public static class Matrix3x2DoubleExtensions
    {
        public static Matrix ToGdipMatrix(this Matrix3x2Double m) => 
            new Matrix((float) m.M11, (float) m.M12, (float) m.M21, (float) m.M22, (float) m.OffsetX, (float) m.OffsetY);
    }
}

