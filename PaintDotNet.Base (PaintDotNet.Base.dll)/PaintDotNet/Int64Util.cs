namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class Int64Util
    {
        private static readonly object[] boxedInt64 = new object[0x101L];
        private const long maxCachedBoxValue = 0x80L;
        private const long minCachedBoxValue = -128L;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Clamp(long value, long min, long max)
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
        public static long ClampSafe(long value, long bound1, long bound2) => 
            Clamp(value, Math.Min(bound1, bound2), Math.Max(bound1, bound2));

        private static void ClampThrow(long value, long min, long max)
        {
            throw new ArgumentException($"min must be less than or equal to max. value={value}, min={min}, max={max}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ClampToByte(long x)
        {
            if (x > 0xffL)
            {
                return 0xff;
            }
            if (x < 0L)
            {
                return 0;
            }
            return (byte) x;
        }

        public static object GetBoxed(long value)
        {
            if ((value < -128L) || (value > 0x80L))
            {
                return value;
            }
            long num = value - -128L;
            object obj2 = boxedInt64[(int) ((IntPtr) num)];
            if (obj2 == null)
            {
                obj2 = value;
                boxedInt64[(int) ((IntPtr) num)] = obj2;
            }
            return obj2;
        }

        public static long GreatestCommonDivisor(long a, long b)
        {
            long num;
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

        public static int HighestBit(long x)
        {
            if (x == 0)
            {
                return 0;
            }
            int num = 0;
            int num2 = 0;
            while (num <= 0x3e)
            {
                if ((x & (((long) 1L) << num)) != 0)
                {
                    num2 = num;
                }
                num++;
            }
            return num2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsClamped(long value, long min, long max)
        {
            if (min > max)
            {
                IsClampedThrow(value, min, max);
            }
            return ((value >= min) && (value <= max));
        }

        private static void IsClampedThrow(long value, long min, long max)
        {
            ExceptionUtil.ThrowArgumentOutOfRangeException("min", $"min must be less than or equal to max. value={value}, min={min}, max={max}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2(long x)
        {
            if (x == 0)
            {
                return 0;
            }
            if (x == 1L)
            {
                return 0;
            }
            return (1 + HighestBit(x - 1L));
        }

        public static long Max(long val0, params long[] vals)
        {
            long num = val0;
            for (int i = 0; i < vals.Length; i++)
            {
                if (vals[i] > num)
                {
                    num = vals[i];
                }
            }
            return num;
        }

        public static long Max(long val0, long val1, long val2) => 
            Math.Max(val0, Math.Max(val1, val2));

        public static long Max(long val0, long val1, long val2, long val3) => 
            Math.Max(val0, Math.Max(val1, Math.Max(val2, val3)));

        public static long Min(long val0, params long[] vals)
        {
            long num = val0;
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
        public static int Pow2RoundUp(long x)
        {
            if (x == 0)
            {
                return 1;
            }
            if (x == 1L)
            {
                return 1;
            }
            return (((int) 1) << (1 + HighestBit(x - 1L)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RotateLeft(long x, int count) => 
            ((long) UInt64Util.RotateLeft((ulong) x, count));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RotateRight(long x, int count) => 
            ((long) UInt64Util.RotateRight((ulong) x, count));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SafeIsClamped(long value, long extreme1, long extreme2)
        {
            long min = Math.Min(extreme1, extreme2);
            long max = Math.Max(extreme1, extreme2);
            return IsClamped(value, min, max);
        }
    }
}

