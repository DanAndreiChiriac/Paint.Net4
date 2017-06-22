namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            Validate.IsNotNull<IDictionary<TKey, TValue>>(dictionary, "dictionary");
            if (dictionary.IsReadOnly)
            {
                return dictionary;
            }
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        public static void ClearValues<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            foreach (TKey local in dictionary.Keys)
            {
                TValue local2 = default(TValue);
                dictionary[local] = local2;
            }
        }

        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                return false;
            }
            dictionary.Add(key, value);
            return true;
        }

        public static bool TryRemove<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, out TValue value)
        {
            if (!dictionary.TryGetValue(key, out value))
            {
                return false;
            }
            if (!dictionary.Remove(key))
            {
                ExceptionUtil.ThrowInternalErrorException();
            }
            return true;
        }
    }
}

