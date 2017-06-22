namespace PaintDotNet.Functional
{
    using System;
    using System.Runtime.CompilerServices;

    public static class OptionalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? AsNullable<T>(this Optional<T> optional) where T: struct
        {
            if (!optional.HasValue)
            {
                return null;
            }
            return new T?(optional.GetValueOrDefault());
        }
    }
}

