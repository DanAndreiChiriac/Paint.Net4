namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ComparableUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CompareTo<TThis>(TThis @this, object other) where TThis: IComparable<TThis>, IComparable
        {
            if (other == null)
            {
                return 1;
            }
            if (other is TThis)
            {
                return @this.CompareTo((TThis) other);
            }
            return CompareToThrow<TThis>(other);
        }

        private static int CompareToThrow<TThis>(object other) where TThis: IComparable<TThis>, IComparable
        {
            ExceptionUtil.ThrowArgumentException($"Invalid type (expected: {typeof(TThis).FullName}, actual: {other.GetType().FullName})", "other");
            return -1;
        }
    }
}

