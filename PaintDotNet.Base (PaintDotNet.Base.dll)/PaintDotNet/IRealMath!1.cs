namespace PaintDotNet
{
    using System.Collections.Generic;

    internal interface IRealMath<T> : IScalarMath<T>, IComparer<T>, IEqualityComparer<T>
    {
        T Acos(T cosine);
        T Asin(T sine);
        T Atan(T tangent);
        T Atan2(T y, T x);
        T Cos(T radians);
        T Cosh(T radians);
        T Log(T value);
        T Log(T value, T newBase);
        T Log10(T value);
        T Pow(T x, T y);
        T Sin(T radians);
        T Sinh(T radians);
        T Sqrt(T value);
        T Tan(T radians);
        T Tanh(T radians);

        T Epsilon { get; }

        T NaN { get; }

        T NegativeInfinity { get; }

        T PositiveInfinity { get; }
    }
}

