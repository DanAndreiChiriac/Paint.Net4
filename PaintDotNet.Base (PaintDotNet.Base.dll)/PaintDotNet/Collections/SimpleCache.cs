namespace PaintDotNet.Collections
{
    using System;

    public static class SimpleCache
    {
        public static void EnsureEmpty<TKey, TValue>(ref SimpleCache<TKey, TValue> cache, Func<SimpleCache<TKey, TValue>> cacheFactory)
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

