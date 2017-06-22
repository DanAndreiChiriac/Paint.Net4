namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;

    public static class BitArrayExtensions
    {
        public static byte[] GetBytes(this BitArray bitArray)
        {
            Validate.IsNotNull<BitArray>(bitArray, "bitArray");
            if (bitArray.Count == 0)
            {
                return Array.Empty<byte>();
            }
            byte[] buffer = new byte[(bitArray.Count + 7) >> 3];
            for (int i = 0; i < bitArray.Count; i++)
            {
                if (bitArray[i])
                {
                    byte num2 = (byte) (((int) 1) << (i & 7));
                    buffer[i] = (byte) (buffer[i] | num2);
                }
            }
            return buffer;
        }

        public static bool[] ToArray(this BitArray bitArray)
        {
            Validate.IsNotNull<BitArray>(bitArray, "bitArray");
            if (bitArray.Count == 0)
            {
                return Array.Empty<bool>();
            }
            bool[] flagArray = new bool[bitArray.Count];
            for (int i = 0; i < flagArray.Length; i++)
            {
                flagArray[i] = bitArray[i];
            }
            return flagArray;
        }
    }
}

