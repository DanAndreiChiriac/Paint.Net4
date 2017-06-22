namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    internal static class ScalarMathExtensions
    {
        public static T DegreesToRadians<T, TMath>(this TMath math, T angle) where TMath: IScalarMath<T> => 
            math.Divide(math.Multiply(angle, Constants<T, TMath>.PI), Constants<T, TMath>._180);

        public static T RadiansToDegrees<T, TMath>(this TMath math, T angle) where TMath: IScalarMath<T> => 
            math.Divide(math.Multiply(angle, Constants<T, TMath>._180), Constants<T, TMath>.PI);

        private static class Constants<T, TMath> where TMath: IScalarMath<T>
        {
            public static readonly T _180;
            private static readonly TMath math;
            public static readonly T PI;
            public static readonly T Sqrt2;

            static Constants()
            {
                ScalarMathExtensions.Constants<T, TMath>.math = default(TMath);
                ScalarMathExtensions.Constants<T, TMath>.Sqrt2 = ScalarMathExtensions.Constants<T, TMath>.math.FromDouble(1.4142135623730951);
                ScalarMathExtensions.Constants<T, TMath>.PI = ScalarMathExtensions.Constants<T, TMath>.math.FromDouble(3.1415926535897931);
                ScalarMathExtensions.Constants<T, TMath>._180 = ScalarMathExtensions.Constants<T, TMath>.math.FromInt32(180);
            }
        }
    }
}

