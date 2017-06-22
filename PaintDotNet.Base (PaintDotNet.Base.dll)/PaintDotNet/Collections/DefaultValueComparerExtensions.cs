namespace PaintDotNet.Collections
{
    using System;
    using System.Runtime.CompilerServices;

    internal static class DefaultValueComparerExtensions
    {
        internal static bool AreAllDefaultValue<T, TComparer>(this TComparer comparer, T[] array) where TComparer: DefaultValueComparer<T> => 
            comparer.AreAllDefaultValue(array, 0, array.Length);
    }
}

