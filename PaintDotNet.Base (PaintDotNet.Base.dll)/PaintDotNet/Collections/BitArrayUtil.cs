namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;

    public static class BitArrayUtil
    {
        public static BitArray FromBytes(byte[] buffer, int bitCount)
        {
            Validate.IsNotNull<byte[]>(buffer, "buffer");
            int num = buffer.Length * 8;
            if (bitCount > num)
            {
                ExceptionUtil.ThrowArgumentException("bitCount cannot exceed buffer.Length * 8", "bitCount");
            }
            BitArray array = new BitArray(bitCount);
            for (int i = 0; i < bitCount; i++)
            {
                int index = i >> 3;
                int num4 = i & 7;
                int num5 = ((int) 1) << num4;
                byte num6 = buffer[index];
                array[i] = (num6 & num5) > 0;
            }
            return array;
        }
    }
}

