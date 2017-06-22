namespace PaintDotNet
{
    using System;

    public static class DoubleUtil
    {
        private static readonly object boxed0 = 0.0;
        private static readonly object boxed1 = 1.0;
        private static readonly object boxedNaN = (double) 1.0 / (double) 0.0;
        private const double epsilon = 2.2204460492503131E-15;

        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

        public static byte ClampToByte(double value)
        {
            if (value <= 0.0)
            {
                return 0;
            }
            if (value >= 255.0)
            {
                return 0xff;
            }
            return (byte) value;
        }

        public static int ClampToInt32(double value)
        {
            if (value <= -2147483648.0)
            {
                return -2147483648;
            }
            if (value >= 2147483647.0)
            {
                return 0x7fffffff;
            }
            return (int) value;
        }

        public static long ClampToInt64(double value)
        {
            if (value <= -9.2233720368547758E+18)
            {
                return -9223372036854775808L;
            }
            if (value >= 9.2233720368547758E+18)
            {
                return 0x7fffffffffffffffL;
            }
            return (long) value;
        }

        public static object GetBoxed(double value)
        {
            if (value == 0.0)
            {
                return boxed0;
            }
            if (value == 1.0)
            {
                return boxed1;
            }
            if (!double.IsNaN(value))
            {
                return value;
            }
            return boxedNaN;
        }

        public static bool IsClamped(double value, double min, double max)
        {
            if (min > max)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("min", "min must be less than or equal to max");
            }
            return ((value >= min) && (value <= max));
        }

        public static bool IsCloseToOne(double x) => 
            (Math.Abs((double) (x - 1.0)) < 2.2204460492503131E-15);

        public static bool IsCloseToZero(double x) => 
            (Math.Abs(x) < 2.2204460492503131E-15);

        public static bool IsInteger(double x) => 
            (x.IsFinite() && (Math.Floor(x) == Math.Ceiling(x)));

        public static double Lerp(double from, double to, double frac) => 
            (from + (frac * (to - from)));

        public static double SafeClamp(double value, double constraint1, double constraint2) => 
            Clamp(value, Math.Min(constraint1, constraint2), Math.Max(constraint1, constraint2));

        public static bool SafeIsClamped(double value, double extreme1, double extreme2)
        {
            double min = Math.Min(extreme1, extreme2);
            double max = Math.Max(extreme1, extreme2);
            return IsClamped(value, min, max);
        }

        public static int? TryConvertToInt32(double value)
        {
            if ((!value.IsFinite() || (value <= -2147483648.0)) || (value >= 2147483647.0))
            {
                return null;
            }
            try
            {
                return new int?((int) value);
            }
            catch (OverflowException)
            {
                return null;
            }
        }
    }
}

