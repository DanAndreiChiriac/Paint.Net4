namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ByteUtil
    {
        private unsafe static double* pByteToScalingDoubleLookup;
        private unsafe static float* pByteToScalingFloatLookup;
        private unsafe static byte* pFastScaleLookup;
        private unsafe static byte* pHighestBitLookup;
        private unsafe static byte* pUnscaleLookup = ((byte*) Marshal.AllocCoTaskMem(0x10000));

        static unsafe ByteUtil()
        {
            for (int i = 0; i <= 0xff; i++)
            {
                for (int n = 0; n <= 0xff; n++)
                {
                    int index = i + (n * 0x100);
                    if (n == 0)
                    {
                        pUnscaleLookup[index] = 0;
                    }
                    else
                    {
                        pUnscaleLookup[index] = Int32Util.ClampToByte((i * 0xff) / n);
                    }
                }
            }
            pByteToScalingFloatLookup = (float*) Marshal.AllocCoTaskMem(0x400);
            pByteToScalingDoubleLookup = (double*) Marshal.AllocCoTaskMem(0x800);
            for (int j = 0; j <= 0xff; j++)
            {
                pByteToScalingFloatLookup[j * 4] = ((float) j) / 255f;
                pByteToScalingDoubleLookup[j * 8] = ((double) j) / 255.0;
            }
            pHighestBitLookup = (byte*) Marshal.AllocCoTaskMem(0x100);
            for (int k = 2; k < 7; k++)
            {
                int num6 = (k << 2) - 1;
                for (int num7 = num6; num7 < (num6 + k); num7++)
                {
                    pHighestBitLookup[num7] = (byte) k;
                }
            }
            pFastScaleLookup = (byte*) Marshal.AllocCoTaskMem(0x10000);
            for (int m = 0; m <= 0xff; m++)
            {
                for (int num9 = 0; num9 <= 0xff; num9++)
                {
                    pFastScaleLookup[(num9 << 8) + m] = FastScaleImpl((byte) m, (byte) num9);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte FastScale(byte x, byte frac) => 
            pFastScaleLookup[(frac << 8) + x];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte FastScaleImpl(byte x, byte frac)
        {
            int num = (x * frac) + 0x80;
            return (byte) (((num >> 8) + num) >> 8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte FastUnscale(byte x, byte frac) => 
            pUnscaleLookup[x + (frac << 8)];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int HighestBit(byte x) => 
            pHighestBitLookup[x];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int Log2(byte x)
        {
            if (x == 0)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("x", "must be 1 or greater");
            }
            return pHighestBitLookup[x];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe double ToScalingDouble(byte x) => 
            pByteToScalingDoubleLookup[x * 8];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float ToScalingFloat(byte x) => 
            pByteToScalingFloatLookup[x * 4];
    }
}

