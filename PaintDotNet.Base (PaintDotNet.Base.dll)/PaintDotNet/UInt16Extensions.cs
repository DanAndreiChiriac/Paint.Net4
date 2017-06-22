namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class UInt16Extensions
    {
        public static int FastDivideByByte(this ushort n, byte d) => 
            UInt16Util.FastDivideByByte(n, d);
    }
}

