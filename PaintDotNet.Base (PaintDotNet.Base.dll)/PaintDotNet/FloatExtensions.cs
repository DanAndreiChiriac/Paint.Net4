namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class FloatExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(this float value, float min, float max) => 
            FloatUtil.Clamp(value, min, max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite(this float x) => 
            ((x >= float.MinValue) && (x <= float.MaxValue));
    }
}

