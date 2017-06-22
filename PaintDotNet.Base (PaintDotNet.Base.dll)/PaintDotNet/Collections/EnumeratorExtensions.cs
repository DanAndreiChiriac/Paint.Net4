namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class EnumeratorExtensions
    {
        public static TCollection DrainTo<T, TCollection>(this IEnumerator<T> enumerator, TCollection collection) where TCollection: ICollection<T>
        {
            T local;
            while (enumerator.TryGetNextValue<T>(out local))
            {
                collection.Add(local);
            }
            return collection;
        }

        public static List<T> DrainToList<T>(this IEnumerator<T> enumerator) => 
            enumerator.DrainTo<T, List<T>>(new List<T>());

        public static TCollection DrainToNew<T, TCollection>(this IEnumerator<T> enumerator) where TCollection: ICollection<T>, new() => 
            enumerator.DrainTo<T, TCollection>(Activator.CreateInstance<TCollection>());

        public static T GetNextValue<T>(this IEnumerator<T> enumerator)
        {
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException("past the end of the sequence");
            }
            return enumerator.Current;
        }

        public static bool TryGetNextValue<T>(this IEnumerator<T> enumerator, out T value)
        {
            if (enumerator.MoveNext())
            {
                value = enumerator.Current;
                return true;
            }
            value = default(T);
            return false;
        }
    }
}

