namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    internal struct DecimalMath : IScalarMath<decimal>, IComparer<decimal>, IEqualityComparer<decimal>
    {
        public decimal Zero =>
            decimal.Zero;
        public decimal One =>
            decimal.One;
        public decimal MaxValue =>
            79228162514264337593543950335M;
        public decimal MinValue =>
            -79228162514264337593543950335M;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Add(decimal a, decimal b) => 
            (a + b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Subtract(decimal a, decimal b) => 
            (a - b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Multiply(decimal a, decimal b) => 
            (a * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Divide(decimal a, decimal b) => 
            (a / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Negate(decimal value) => 
            -value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Abs(decimal value) => 
            Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(decimal x, decimal y) => 
            x.CompareTo(y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(decimal x, decimal y) => 
            x.Equals(y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(decimal obj) => 
            obj.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Ceiling(decimal value) => 
            Math.Ceiling(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Floor(decimal value) => 
            Math.Floor(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal FromDecimal(decimal value) => 
            value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal FromDouble(double value) => 
            ((decimal) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal FromFloat(float value) => 
            ((decimal) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal FromInt32(int value) => 
            value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal FromInt64(long value) => 
            value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Round(decimal value) => 
            Math.Round(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Round(decimal value, int digits) => 
            Math.Round(value, digits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Round(decimal value, MidpointRounding mode) => 
            Math.Round(value, mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Round(decimal value, int digits, MidpointRounding mode) => 
            Math.Round(value, digits, mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Sign(decimal value) => 
            Math.Sign(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal ToDecimal(decimal value) => 
            value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double ToDouble(decimal value) => 
            ((double) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ToFloat(decimal value) => 
            ((float) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ToInt32(decimal value) => 
            ((int) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ToInt64(decimal value) => 
            ((long) value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Truncate(decimal value) => 
            Math.Truncate(value);
    }
}

