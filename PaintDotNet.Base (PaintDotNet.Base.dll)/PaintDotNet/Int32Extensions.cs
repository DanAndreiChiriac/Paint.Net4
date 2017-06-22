namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class Int32Extensions
    {
        public static int Clamp(this int value, int min, int max) => 
            Int32Util.Clamp(value, min, max);
    }
}

