namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class UInt32Util
    {
        private static readonly byte[] multiplyDeBruijnBitPosition = new byte[] { 
            0, 9, 1, 10, 13, 0x15, 2, 0x1d, 11, 14, 0x10, 0x12, 0x16, 0x19, 3, 30,
            8, 12, 20, 0x1c, 15, 0x11, 0x18, 7, 0x13, 0x1b, 0x17, 6, 0x1a, 5, 4, 0x1f
        };
        private unsafe static readonly uint* pMasTable = FastDivisionHelpers.MasTablePtr;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountBits(uint x)
        {
            int num = 0;
            while (x > 0)
            {
                x &= x - 1;
                num++;
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Div2Ceiling(uint x) => 
            ((x >> 1) + (x & 1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Div2Floor(uint x) => 
            (x >> 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Div3Ceiling(uint x)
        {
            uint num = (uint) ((0xaaaaaaabL * x) >> 0x21);
            uint num2 = x - (num * 3);
            return (num + ((num2 & 1) | (num2 >> 1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Div3Floor(uint x) => 
            ((uint) ((0xaaaaaaabL * x) >> 0x21));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Div3Round(uint x)
        {
            uint num = Div3Floor(x);
            uint num2 = x - (num * 3);
            uint num3 = (num2 & 1) + (num2 >> 1);
            return (num + num3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe uint FastDivideByUInt16(uint n, ushort d)
        {
            uint* numPtr = pMasTable + (d * 3);
            return (((n * numPtr[0]) + numPtr[1]) >> numPtr[2]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int HighestBit(uint x)
        {
            uint num1 = x | (x >> 1);
            uint num2 = num1 | (num1 >> 2);
            uint num3 = num2 | (num2 >> 4);
            uint num4 = num3 | (num3 >> 8);
            uint index = (uint) (((num4 | (num4 >> 0x10)) * 0x7c4acdd) >> 0x1b);
            return multiplyDeBruijnBitPosition[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2(uint x)
        {
            if (x == 0)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("x", "must be 1 or greater");
            }
            return HighestBit(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2RoundUp(uint x)
        {
            if ((x == 0) || (x > 0x80000000))
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("x must be in the range [1, 2^31]");
            }
            return Log2((x - 1) + x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Pow2RoundDown(uint x)
        {
            if (x == 0)
            {
                return 0;
            }
            return (((uint) 1) << Log2(x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Pow2RoundUp(uint x)
        {
            if (x > 0x80000000)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("x", "must be less than or equal to 2^31");
            }
            if (x == 0)
            {
                return 1;
            }
            return Pow2RoundUpNonZero(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint Pow2RoundUpNonZero(uint x)
        {
            long num1 = x - 1;
            long num2 = num1 | (num1 >> 1);
            long num3 = num2 | (num2 >> 2);
            long num4 = num3 | (num3 >> 4);
            long num5 = num4 | (num4 >> 8);
            return (uint) ((num5 | (num5 >> 0x10)) + 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RotateLeft(uint x, int count)
        {
            if (count < 0)
            {
                return RotateRight(x, -count);
            }
            int num = count & 0x1f;
            return ((x << num) | (x >> (0x20 - num)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RotateRight(uint x, int count)
        {
            if (count < 0)
            {
                return RotateLeft(x, -count);
            }
            int num = count & 0x1f;
            return ((x >> num) | (x << (0x20 - num)));
        }
    }
}

