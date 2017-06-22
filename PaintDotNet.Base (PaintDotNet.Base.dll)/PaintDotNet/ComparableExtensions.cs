namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ComparableExtensions
    {
        public static T Clamp<T>(this T value, T min, T max) where T: IComparable<T>
        {
            T local = value;
            if (min.IsGreaterThan<T>(max))
            {
                throw new ArgumentOutOfRangeException("min must be less than or equal to max");
            }
            if (value.IsGreaterThan<T>(max))
            {
                local = max;
            }
            if (value.IsLessThan<T>(min))
            {
                local = min;
            }
            return local;
        }

        public static bool IsEqualTo<T>(this T lhs, T rhs) where T: IComparable<T> => 
            (lhs.CompareTo(rhs) == 0);

        public static bool IsGreaterThan<T>(this T lhs, T rhs) where T: IComparable<T> => 
            (lhs.CompareTo(rhs) > 0);

        public static bool IsGreaterThanOrEqualTo<T>(this T lhs, T rhs) where T: IComparable<T> => 
            (lhs.CompareTo(rhs) >= 0);

        public static bool IsLessThan<T>(this T lhs, T rhs) where T: IComparable<T> => 
            (lhs.CompareTo(rhs) < 0);

        public static bool IsLessThanOrEqualTo<T>(this T lhs, T rhs) where T: IComparable<T> => 
            (lhs.CompareTo(rhs) <= 0);
    }
}

