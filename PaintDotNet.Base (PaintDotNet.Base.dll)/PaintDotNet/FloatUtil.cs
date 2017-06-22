namespace PaintDotNet
{
    using System;

    public static class FloatUtil
    {
        public static float Clamp(float value, float min, float max)
        {
            if (min > max)
            {
                throw new ArgumentException($"min must be less than or equal to max. value={value}, min={min}, max={max}");
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

        public static bool IsClamped(float value, float min, float max)
        {
            if (min > max)
            {
                ExceptionUtil.ThrowArgumentOutOfRangeException("min", "min must be less than or equal to max");
            }
            return ((value >= min) && (value <= max));
        }

        public static float Lerp(float from, float to, float frac) => 
            (from + (frac * (to - from)));

        public static float SafeClamp(float value, float constraint1, float constraint2) => 
            Clamp(value, Math.Min(constraint1, constraint2), Math.Max(constraint1, constraint2));

        public static bool SafeIsClamepd(float value, float extreme1, float extreme2)
        {
            float min = Math.Min(extreme1, extreme2);
            float max = Math.Max(extreme1, extreme2);
            return IsClamped(value, min, max);
        }
    }
}

