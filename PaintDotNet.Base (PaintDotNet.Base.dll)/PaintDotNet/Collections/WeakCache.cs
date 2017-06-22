namespace PaintDotNet.Collections
{
    using System;

    public static class WeakCache
    {
        public static void EnsureEmpty<TKey, TValue>(ref WeakCache<TKey, TValue> cache, Func<WeakCache<TKey, TValue>> cacheFactory) where TValue: class
        {
            if (cache == null)
            {
                cache = cacheFactory();
            }
            else
            {
                cache.Clear();
            }
        }
    }
}

