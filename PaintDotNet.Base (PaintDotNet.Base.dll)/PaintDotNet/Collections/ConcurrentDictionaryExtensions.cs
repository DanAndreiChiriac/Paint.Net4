namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class ConcurrentDictionaryExtensions
    {
        public static TValue GetOrAddClean<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory) where TValue: class, IDisposable
        {
            Action<TKey, TValue> unusedValueCallback = delegate (TKey key2, TValue value2) {
                if (value2 != null)
                {
                    value2.Dispose();
                }
            };
            return dictionary.GetOrAddClean<TKey, TValue>(key, valueFactory, unusedValueCallback);
        }

        public static TValue GetOrAddClean<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory, Action<TKey, TValue> unusedValueCallback) where TValue: class
        {
            TValue ourValue = default(TValue);
            Func<TKey, TValue> func = delegate (TKey key2) {
                TValue local = valueFactory(key);
                if (ourValue != null)
                {
                    unusedValueCallback(key2, ourValue);
                    ourValue = default(TValue);
                }
                ourValue = local;
                return local;
            };
            TValue orAdd = dictionary.GetOrAdd(key, func);
            if (ourValue != orAdd)
            {
                unusedValueCallback(key, ourValue);
            }
            return orAdd;
        }

        public static KeyValuePair<TKey, TValue>[] ToArrayEx<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary)
        {
            KeyValuePair<TKey, TValue>[] pairArray = dictionary.ToArray();
            if (pairArray.Length == 0)
            {
                return Array.Empty<KeyValuePair<TKey, TValue>>();
            }
            return pairArray;
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c__0<TKey, TValue> where TValue: class, IDisposable
        {
            public static readonly ConcurrentDictionaryExtensions.<>c__0<TKey, TValue> <>9;
            public static Action<TKey, TValue> <>9__0_0;

            static <>c__0()
            {
                ConcurrentDictionaryExtensions.<>c__0<TKey, TValue>.<>9 = new ConcurrentDictionaryExtensions.<>c__0<TKey, TValue>();
            }

            internal void <GetOrAddClean>b__0_0(TKey key2, TValue value2)
            {
                if (value2 != null)
                {
                    value2.Dispose();
                }
            }
        }
    }
}

