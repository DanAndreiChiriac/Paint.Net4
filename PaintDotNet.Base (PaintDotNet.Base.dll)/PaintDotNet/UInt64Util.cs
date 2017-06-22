namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class UInt64Util
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountBits(ulong x)
        {
            int num = 0;
            while (x > 0L)
            {
                x &= x - ((ulong) 1L);
                num++;
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong RotateLeft(ulong x, int count)
        {
            if (count < 0)
            {
                return RotateRight(x, -count);
            }
            int num = count & 0x3f;
            return ((x << num) | (x >> (0x40 - num)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong RotateRight(ulong x, int count)
        {
            if (count < 0)
            {
                return RotateLeft(x, -count);
            }
            int num = count & 0x3f;
            return ((x >> num) | (x << (0x40 - num)));
        }
    }
}

