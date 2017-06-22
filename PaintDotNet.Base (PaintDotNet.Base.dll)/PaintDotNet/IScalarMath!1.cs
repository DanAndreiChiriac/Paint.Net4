namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;

    internal interface IScalarMath<T> : IComparer<T>, IEqualityComparer<T>
    {
        T Abs(T value);
        T Add(T a, T b);
        T Ceiling(T value);
        T Divide(T a, T b);
        T Floor(T value);
        T FromDecimal(decimal value);
        T FromDouble(double value);
        T FromFloat(float value);
        T FromInt32(int value);
        T FromInt64(long value);
        T Multiply(T a, T b);
        T Negate(T value);
        T Round(T value);
        T Round(T value, int digits);
        T Round(T value, MidpointRounding mode);
        T Round(T value, int digits, MidpointRounding mode);
        int Sign(T value);
        T Subtract(T a, T b);
        decimal ToDecimal(T value);
        double ToDouble(T value);
        float ToFloat(T value);
        int ToInt32(T value);
        long ToInt64(T value);
        T Truncate(T value);

        T MaxValue { get; }

        T MinValue { get; }

        T One { get; }

        T Zero { get; }
    }
}

