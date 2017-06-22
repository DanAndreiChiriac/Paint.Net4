namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class UInt16Util
    {
        private unsafe static readonly uint* pMasTable = FastDivisionHelpers.MasTablePtr;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FastDivideBy255(ushort n) => 
            ((int) ((n * 0x80808081L) >> 0x27));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int FastDivideByByte(ushort n, byte d)
        {
            uint* numPtr = pMasTable + (d * 3);
            return (int) (((n * numPtr[0]) + numPtr[1]) >> numPtr[2]);
        }
    }
}

