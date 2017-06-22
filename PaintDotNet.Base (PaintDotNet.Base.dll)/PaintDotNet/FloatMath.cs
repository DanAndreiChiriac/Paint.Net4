namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    internal struct FloatMath : IRealMath<float>, IScalarMath<float>, IComparer<float>, IEqualityComparer<float>
    {
        public float Epsilon =>
            float.Epsilon;
        public float NaN =>
            float.NaN;
        public float NegativeInfinity =>
            float.NegativeInfinity;
        public float PositiveInfinity =>
            float.PositiveInfinity;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Acos(float cosine) => 
            ((float) Math.Acos((double) cosine));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Asin(float sine) => 
            ((float) Math.Asin((double) sine));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Atan(float tangent) => 
            ((float) Math.Atan((double) tangent));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Atan2(float y, float x) => 
            ((float) Math.Atan2((double) y, (double) x));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Ceiling(float value) => 
            ((float) Math.Ceiling((double) value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Cos(float radians) => 
            ((float) Math.Cos((double) radians));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Cosh(float radians) => 
            ((float) Math.Cosh((double) radians));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Floor(float value) => 
            ((float) Math.Floor((double) value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float FromDecimal(decimal value) => 
            ((float) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float FromDouble(double value) => 
            ((float) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float FromFloat(float value) => 
            value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float FromInt32(int value) => 
            ((float) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float FromInt64(long value) => 
            ((float) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Log(float value) => 
            ((float) Math.Log((double) value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Log(float value, float newBase) => 
            ((float) Math.Log((double) value, (double) newBase));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Log10(float value) => 
            ((float) Math.Log10((double) value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Pow(float x, float y) => 
            ((float) Math.Pow((double) x, (double) y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Round(float value) => 
            ((float) Math.Round((double) value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Round(float value, int digits) => 
            ((float) Math.Round((double) value, digits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Round(float value, MidpointRounding mode) => 
            ((float) Math.Round((double) value, mode));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Round(float value, int digits, MidpointRounding mode) => 
            ((float) Math.Round((double) value, digits, mode));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Sign(float value) => 
            Math.Sign(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Sin(float radians) => 
            ((float) Math.Sin((double) radians));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Sinh(float radians) => 
            ((float) Math.Sinh((double) radians));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Sqrt(float value) => 
            ((float) Math.Sqrt((double) value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Tan(float radians) => 
            ((float) Math.Tan((double) radians));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Tanh(float radians) => 
            ((float) Math.Tanh((double) radians));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal ToDecimal(float value) => 
            ((decimal) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double ToDouble(float value) => 
            ((double) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ToFloat(float value) => 
            value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ToInt32(float value) => 
            ((int) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ToInt64(float value) => 
            ((long) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Truncate(float value) => 
            ((float) Math.Truncate((double) value));

        public float Zero =>
            0f;
        public float One =>
            1f;
        public float MaxValue =>
            float.MaxValue;
        public float MinValue =>
            float.MinValue;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Add(float a, float b) => 
            (a + b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Subtract(float a, float b) => 
            (a - b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Multiply(float a, float b) => 
            (a * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Divide(float a, float b) => 
            (a / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Negate(float value) => 
            -value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Abs(float value) => 
            Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(float x, float y) => 
            x.CompareTo(y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float x, float y) => 
            x.Equals(y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(float obj) => 
            obj.GetHashCode();
    }
}

