namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ComparerExtensions
    {
        public static T Clamp<T, TComparer>(this TComparer comparer, T value, T min, T max) where TComparer: IComparer<T>
        {
            if (comparer.IsGreaterThan<T, TComparer>(min, max))
            {
                ExceptionUtil.ThrowArgumentException("min", "must be less than or equal to max");
            }
            if (comparer.IsLessThan<T, TComparer>(value, min))
            {
                return min;
            }
            if (comparer.IsGreaterThan<T, TComparer>(value, max))
            {
                return max;
            }
            return value;
        }

        public static bool IsGreaterThan<T, TComparer>(this TComparer comparer, T lhs, T rhs) where TComparer: IComparer<T> => 
            (comparer.Compare(lhs, rhs) > 0);

        public static bool IsGreaterThanOrEqualTo<T, TComparer>(this TComparer comparer, T lhs, T rhs) where TComparer: IComparer<T> => 
            (comparer.Compare(lhs, rhs) >= 0);

        public static bool IsLessThan<T, TComparer>(this TComparer comparer, T lhs, T rhs) where TComparer: IComparer<T> => 
            (comparer.Compare(lhs, rhs) < 0);

        public static bool IsLessThanOrEqualTo<T, TComparer>(this TComparer comparer, T lhs, T rhs) where TComparer: IComparer<T> => 
            (comparer.Compare(lhs, rhs) <= 0);

        public static T Max<T, TComparer>(this TComparer comparer, T a, T b) where TComparer: IComparer<T>
        {
            if (!comparer.IsGreaterThan<T, TComparer>(a, b))
            {
                return b;
            }
            return a;
        }

        public static T Min<T, TComparer>(this TComparer comparer, T a, T b) where TComparer: IComparer<T>
        {
            if (!comparer.IsLessThan<T, TComparer>(a, b))
            {
                return b;
            }
            return a;
        }

        public static T SafeClamp<T, TComparer>(this TComparer comparer, T value, T extreme1, T extreme2) where TComparer: IComparer<T>
        {
            T min = comparer.Min<T, TComparer>(extreme1, extreme2);
            T max = comparer.Max<T, TComparer>(extreme1, extreme2);
            return comparer.Clamp<T, TComparer>(value, min, max);
        }
    }
}

