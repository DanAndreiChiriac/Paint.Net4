namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    internal static class RealMathExtensions
    {
        public static bool IsFinite<T, TMath>(this TMath math, T value) where TMath: IRealMath<T> => 
            (math.IsGreaterThan<T, TMath>(value, math.MinValue) && math.IsLessThan<T, TMath>(value, math.MaxValue));
    }
}

