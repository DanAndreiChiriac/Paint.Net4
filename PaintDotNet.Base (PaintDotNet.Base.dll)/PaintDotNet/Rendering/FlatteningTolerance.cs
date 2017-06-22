namespace PaintDotNet.Rendering
{
    using System;

    public static class FlatteningTolerance
    {
        public static double Default =>
            0.25;

        public static double Minimum =>
            1E-06;
    }
}

