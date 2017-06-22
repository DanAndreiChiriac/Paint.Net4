namespace PaintDotNet.Runtime
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class AttachedData
    {
        private static readonly ConditionalWeakTable<object, ConcurrentDictionary<object, object>> table = new ConditionalWeakTable<object, ConcurrentDictionary<object, object>>();

        public static object GetOrSetValue(object instance, object key, Func<object> valueFactory)
        {
            Validate.Begin().IsNotNull<object>(instance, "instance").IsNotNull<object>(key, "key").IsNotNull<Func<object>>(valueFactory, "valueFactory").Check();
            return table.GetOrCreateValue(instance).GetOrAdd(key, k => valueFactory());
        }

        public static void SetValue(object instance, object key, object value)
        {
            Validate.Begin().IsNotNull<object>(instance, "instance").IsNotNull<object>(key, "key").Check();
            table.GetOrCreateValue(instance).AddOrUpdate(key, value, (k, v) => value);
        }

        public static bool TryGetValue(object instance, object key, out object value)
        {
            ConcurrentDictionary<object, object> dictionary;
            Validate.Begin().IsNotNull<object>(instance, "instance").IsNotNull<object>(key, "key").Check();
            if (!table.TryGetValue(instance, out dictionary))
            {
                value = null;
                return false;
            }
            return dictionary.TryGetValue(key, out value);
        }
    }
}

