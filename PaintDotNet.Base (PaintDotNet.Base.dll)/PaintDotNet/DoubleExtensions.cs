namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class DoubleExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(this double value, double min, double max) => 
            DoubleUtil.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite(this double x) => 
            ((x >= double.MinValue) && (x <= double.MaxValue));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInteger(this double x) => 
            DoubleUtil.IsInteger(x);
    }
}

