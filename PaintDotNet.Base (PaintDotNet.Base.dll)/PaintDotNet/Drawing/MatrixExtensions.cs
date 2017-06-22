namespace PaintDotNet.Drawing
{
    using PaintDotNet.Rendering;
    using System;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;

    public static class MatrixExtensions
    {
        public static Matrix3x2Double ToMatrix3x2Double(this Matrix m)
        {
            float[] elements = m.Elements;
            return new Matrix3x2Double((double) elements[0], (double) elements[1], (double) elements[2], (double) elements[3], (double) elements[4], (double) elements[5]);
        }
    }
}

