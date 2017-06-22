namespace PaintDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class DisposableExtensions
    {
        public static void DisposeAll<T>(this IEnumerable<T> items) where T: class, IDisposable
        {
            if (items != null)
            {
                foreach (T local in items)
                {
                    if (local != null)
                    {
                        local.Dispose();
                    }
                }
            }
        }

        public static void DisposeAll<T>(this IEnumerable<IEnumerable<T>> items2D) where T: class, IDisposable
        {
            if (items2D != null)
            {
                foreach (IEnumerable<T> enumerable in items2D)
                {
                    if (enumerable != null)
                    {
                        enumerable.DisposeAll<T>();
                    }
                }
            }
        }

        public static void DisposeAll<T>(this T[] items) where T: class, IDisposable
        {
            if (items != null)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    T local = items[i];
                    if (local != null)
                    {
                        local.Dispose();
                    }
                }
            }
        }

        public static void DisposeAll<T>(this T[][] items2D) where T: class, IDisposable
        {
            if (items2D != null)
            {
                for (int i = 0; i < items2D.Length; i++)
                {
                    items2D[i].DisposeAll<T>();
                }
            }
        }
    }
}

