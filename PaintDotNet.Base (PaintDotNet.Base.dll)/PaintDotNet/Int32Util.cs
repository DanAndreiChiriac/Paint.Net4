namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class Int32Util
    {
        private static readonly object[] boxedInt32 = new object[0x101];
        private const int maxCachedBoxValue = 0x80;
        private const int minCachedBoxValue = -128;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int value, int min, int max)
        {
            if (min > max)
            {
                ClampThrow(value, min, max);
            }
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampSafe(int value, int bound1, int bound2) => 
            Clamp(value, Math.Min(bound1, bound2), Math.Max(bound1, bound2));

        private static void ClampThrow(int value, int min, int max)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException("min", $"min must be less than or equal to max. value={value}, min={min}, max={max}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ClampToByte(int x)
        {
            if (x > 0xff)
            {
                return 0xff;
            }
            if (x < 0)
            {
                return 0;
            }
            return (byte) x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DivLog2RoundDown(int x, int log2N)
        {
            if (log2N == 0)
            {
                return x;
            }
            return (x >> log2N);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DivLog2RoundUp(int x, int log2N)
        {
            if (log2N == 0)
            {
                return x;
            }
            return (((x + (1 << (log2N & 0x1f))) - 1) >> log2N);
        }

        public static object GetBoxed(int value)
        {
            if ((value < -128) || (value > 0x80))
            {
                return value;
            }
            int index = value - -128;
            object obj2 = boxedInt32[index];
            if (obj2 == null)
            {
                obj2 = value;
                boxedInt32[index] = obj2;
            }
            return obj2;
        }

        public static int GreatestCommonDivisor(int a, int b)
        {
            int num;
            if (a < b)
            {
                num = a;
                a = b;
                b = num;
            }
            do
            {
                num = a % b;
                a = b;
                b = num;
            }
            while (num != 0);
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int HighestBit(int x) => 
            UInt32Util.HighestBit((uint) x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IncrementRoundUp(int x, int i) => 
            ((((x + i) - 1) / i) * i);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsClamped(int value, int min, int max)
        {
            if (min > max)
            {
                IsClampedThrow(value, min, max);
            }
            return ((value >= min) && (value <= max));
        }

        private static void IsClampedThrow(int value, int min, int max)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException("min", $"min must be less than or equal to max. value={value}, min={min}, max={max}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2(int x)
        {
            if (x <= 0)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("x", "must be positive");
            }
            if (x == 1)
            {
                return 0;
            }
            return UInt32Util.HighestBit((uint) x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Log2Floor(int x)
        {
            int num = 0;
            while (x >= 1)
            {
                num++;
                x = x >> 1;
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2RoundUp(int x)
        {
            if ((x <= 0) || (x > 0x40000000))
            {
                ThrowForLog2RoundUp(x);
            }
            return Log2((x + x) - 1);
        }

        public static int Max(int val0, params int[] vals)
        {
            int num = val0;
            for (int i = 0; i < vals.Length; i++)
            {
                if (vals[i] > num)
                {
                    num = vals[i];
                }
            }
            return num;
        }

        public static int Max(int val0, int val1, int val2) => 
            Math.Max(val0, Math.Max(val1, val2));

        public static int Max(int val0, int val1, int val2, int val3) => 
            Math.Max(val0, Math.Max(val1, Math.Max(val2, val3)));

        public static int Min(int val0, params int[] vals)
        {
            int num = val0;
            for (int i = 0; i < vals.Length; i++)
            {
                if (vals[i] < num)
                {
                    num = vals[i];
                }
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Pow2RoundDown(int x)
        {
            if (x < 0)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("x", "must be non-negative");
            }
            return (int) UInt32Util.Pow2RoundDown((uint) x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Pow2RoundUp(int x)
        {
            if ((x < 0) || (x > 0x40000000))
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("x", "must be in the range [1, 2^30]");
            }
            return (int) UInt32Util.Pow2RoundUp((uint) x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RotateLeft(int x, int count) => 
            ((int) UInt32Util.RotateLeft((uint) x, count));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RotateRight(int x, int count) => 
            ((int) UInt32Util.RotateRight((uint) x, count));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundDownLog2N(int x, int log2N) => 
            ((x >> (log2N & 0x1f)) << log2N);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundDownN(int x, int n) => 
            ((x / n) * n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundUpLog2N(int x, int log2N) => 
            ((((x + (1 << (log2N & 0x1f))) - 1) >> (log2N & 0x1f)) << log2N);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundUpN(int x, int n) => 
            ((((x + n) - 1) / n) * n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SafeIsClamped(int value, int extreme1, int extreme2)
        {
            int min = Math.Min(extreme1, extreme2);
            int max = Math.Max(extreme1, extreme2);
            return IsClamped(value, min, max);
        }

        private static void ThrowForLog2RoundUp(int x)
        {
            throw new ArgumentOutOfRangeException($"x = {x.ToString()}", "must be in the range [1, 2^30]");
        }
    }
}

