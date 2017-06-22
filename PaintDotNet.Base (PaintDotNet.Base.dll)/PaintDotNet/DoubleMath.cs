namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    internal struct DoubleMath : IRealMath<double>, IScalarMath<double>, IComparer<double>, IEqualityComparer<double>
    {
        public double Epsilon =>
            double.Epsilon;
        public double NaN =>
            double.NaN;
        public double NegativeInfinity =>
            double.NegativeInfinity;
        public double PositiveInfinity =>
            double.PositiveInfinity;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Acos(double cosine) => 
            Math.Acos(cosine);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Asin(double sine) => 
            Math.Asin(sine);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Atan(double tangent) => 
            Math.Atan(tangent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Atan2(double y, double x) => 
            Math.Atan2(y, x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Ceiling(double value) => 
            Math.Ceiling(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Cos(double radians) => 
            Math.Cos(radians);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Cosh(double radians) => 
            Math.Cosh(radians);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Floor(double value) => 
            Math.Floor(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double FromDecimal(decimal value) => 
            ((double) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double FromDouble(double value) => 
            value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double FromFloat(float value) => 
            ((double) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double FromInt32(int value) => 
            ((double) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double FromInt64(long value) => 
            ((double) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Log(double value) => 
            Math.Log(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Log(double value, double newBase) => 
            Math.Log(value, newBase);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Log10(double value) => 
            Math.Log10(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Pow(double x, double y) => 
            Math.Pow(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Round(double value) => 
            Math.Round(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Round(double value, int digits) => 
            Math.Round(value, digits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Round(double value, MidpointRounding mode) => 
            Math.Round(value, mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Round(double value, int digits, MidpointRounding mode) => 
            Math.Round(value, digits, mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Sign(double value) => 
            Math.Sign(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Sin(double radians) => 
            Math.Sin(radians);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Sinh(double radians) => 
            Math.Sinh(radians);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Sqrt(double value) => 
            Math.Sqrt(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Tan(double radians) => 
            Math.Tan(radians);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Tanh(double radians) => 
            Math.Tanh(radians);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal ToDecimal(double value) => 
            ((decimal) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double ToDouble(double value) => 
            value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ToFloat(double value) => 
            ((float) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ToInt32(double value) => 
            ((int) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ToInt64(double value) => 
            ((long) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Truncate(double value) => 
            Math.Truncate(value);

        public double Zero =>
            0.0;
        public double One =>
            1.0;
        public double MaxValue =>
            double.MaxValue;
        public double MinValue =>
            double.MinValue;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Add(double a, double b) => 
            (a + b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Subtract(double a, double b) => 
            (a - b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Multiply(double a, double b) => 
            (a * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Divide(double a, double b) => 
            (a / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Negate(double value) => 
            -value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Abs(double value) => 
            Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(double x, double y) => 
            x.CompareTo(y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(double x, double y) => 
            x.Equals(y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(double obj) => 
            obj.GetHashCode();
    }
}

