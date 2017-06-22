namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class MathUtil
    {
        private const double _180OverPi = 57.295779513082323;
        private const double piOver180 = 0.017453292519943295;
        public const double PIOver2 = 1.5707963267948966;
        public const double Sqrt2 = 1.4142135623730951;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DegreesToRadians(double angle) => 
            (angle * 0.017453292519943295);

        public static double Gaussian(double x, double a, double b, double c)
        {
            double num = (2.0 * c) * c;
            double y = -(((x - b) * (x - b)) / num);
            double num3 = Math.Pow(2.7182818284590451, y);
            return (a * num3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double val1, double val2) => 
            Math.Max(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int val1, int val2) => 
            Math.Max(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2) => 
            Math.Max(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(T val1, T val2) where T: struct, IComparable<T>
        {
            if (val1.CompareTo(val2) <= 0)
            {
                return val2;
            }
            return val1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double val1, double val2, double val3) => 
            Math.Max(val1, Math.Max(val2, val3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int val1, int val2, int val3) => 
            Math.Max(val1, Math.Max(val2, val3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2, float val3) => 
            Math.Max(val1, Math.Max(val2, val3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(T val1, T val2, T val3) where T: struct, IComparable<T> => 
            Max<T>(val1, Max<T>(val2, val3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double val1, double val2, double val3, double val4) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, val4)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int val1, int val2, int val3, int val4) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, val4)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2, float val3, float val4) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, val4)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(T val1, T val2, T val3, T val4) where T: struct, IComparable<T> => 
            Max<T>(val1, Max<T>(val2, Max<T>(val3, val4)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double val1, double val2, double val3, double val4, double val5) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, val5))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int val1, int val2, int val3, int val4, int val5) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, val5))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2, float val3, float val4, float val5) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, val5))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(T val1, T val2, T val3, T val4, T val5) where T: struct, IComparable<T> => 
            Max<T>(val1, Max<T>(val2, Max<T>(val3, Max<T>(val4, val5))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double val1, double val2, double val3, double val4, double val5, double val6) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, val6)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int val1, int val2, int val3, int val4, int val5, int val6) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, val6)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2, float val3, float val4, float val5, float val6) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, val6)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(T val1, T val2, T val3, T val4, T val5, T val6) where T: struct, IComparable<T> => 
            Max<T>(val1, Max<T>(val2, Max<T>(val3, Max<T>(val4, Max<T>(val5, val6)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double val1, double val2, double val3, double val4, double val5, double val6, double val7) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, Math.Max(val6, val7))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int val1, int val2, int val3, int val4, int val5, int val6, int val7) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, Math.Max(val6, val7))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2, float val3, float val4, float val5, float val6, float val7) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, Math.Max(val6, val7))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(T val1, T val2, T val3, T val4, T val5, T val6, T val7) where T: struct, IComparable<T> => 
            Max<T>(val1, Max<T>(val2, Max<T>(val3, Max<T>(val4, Max<T>(val5, Max<T>(val6, val7))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double val1, double val2, double val3, double val4, double val5, double val6, double val7, double val8) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, Math.Max(val6, Math.Max(val7, val8)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int val1, int val2, int val3, int val4, int val5, int val6, int val7, int val8) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, Math.Max(val6, Math.Max(val7, val8)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2, float val3, float val4, float val5, float val6, float val7, float val8) => 
            Math.Max(val1, Math.Max(val2, Math.Max(val3, Math.Max(val4, Math.Max(val5, Math.Max(val6, Math.Max(val7, val8)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(T val1, T val2, T val3, T val4, T val5, T val6, T val7, T val8) where T: struct, IComparable<T> => 
            Max<T>(val1, Max<T>(val2, Max<T>(val3, Max<T>(val4, Max<T>(val5, Max<T>(val6, Max<T>(val7, val8)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double val1, double val2) => 
            Math.Min(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int val1, int val2) => 
            Math.Min(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2) => 
            Math.Min(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(T val1, T val2) where T: struct, IComparable<T>
        {
            if (val1.CompareTo(val2) > 0)
            {
                return val2;
            }
            return val1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double val1, double val2, double val3) => 
            Math.Min(val1, Math.Min(val2, val3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int val1, int val2, int val3) => 
            Math.Min(val1, Math.Min(val2, val3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2, float val3) => 
            Math.Min(val1, Math.Min(val2, val3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(T val1, T val2, T val3) where T: struct, IComparable<T> => 
            Min<T>(val1, Min<T>(val2, val3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double val1, double val2, double val3, double val4) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, val4)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int val1, int val2, int val3, int val4) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, val4)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2, float val3, float val4) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, val4)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(T val1, T val2, T val3, T val4) where T: struct, IComparable<T> => 
            Min<T>(val1, Min<T>(val2, Min<T>(val3, val4)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double val1, double val2, double val3, double val4, double val5) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, val5))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int val1, int val2, int val3, int val4, int val5) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, val5))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2, float val3, float val4, float val5) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, val5))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(T val1, T val2, T val3, T val4, T val5) where T: struct, IComparable<T> => 
            Min<T>(val1, Min<T>(val2, Min<T>(val3, Min<T>(val4, val5))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double val1, double val2, double val3, double val4, double val5, double val6) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, val6)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int val1, int val2, int val3, int val4, int val5, int val6) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, val6)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2, float val3, float val4, float val5, float val6) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, val6)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(T val1, T val2, T val3, T val4, T val5, T val6) where T: struct, IComparable<T> => 
            Min<T>(val1, Min<T>(val2, Min<T>(val3, Min<T>(val4, Min<T>(val5, val6)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double val1, double val2, double val3, double val4, double val5, double val6, double val7) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, Math.Min(val6, val7))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int val1, int val2, int val3, int val4, int val5, int val6, int val7) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, Math.Min(val6, val7))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2, float val3, float val4, float val5, float val6, float val7) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, Math.Min(val6, val7))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(T val1, T val2, T val3, T val4, T val5, T val6, T val7) where T: struct, IComparable<T> => 
            Min<T>(val1, Min<T>(val2, Min<T>(val3, Min<T>(val4, Min<T>(val5, Min<T>(val6, val7))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double val1, double val2, double val3, double val4, double val5, double val6, double val7, double val8) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, Math.Min(val6, Math.Min(val7, val8)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int val1, int val2, int val3, int val4, int val5, int val6, int val7, int val8) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, Math.Min(val6, Math.Min(val7, val8)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2, float val3, float val4, float val5, float val6, float val7, float val8) => 
            Math.Min(val1, Math.Min(val2, Math.Min(val3, Math.Min(val4, Math.Min(val5, Math.Min(val6, Math.Min(val7, val8)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(T val1, T val2, T val3, T val4, T val5, T val6, T val7, T val8) where T: struct, IComparable<T> => 
            Min<T>(val1, Min<T>(val2, Min<T>(val3, Min<T>(val4, Min<T>(val5, Min<T>(val6, Min<T>(val7, val8)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RadiansToDegrees(double radians) => 
            (radians * 57.295779513082323);
    }
}

