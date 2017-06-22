namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;

    public static class DictionaryUtil
    {
        public static Dictionary<TKey, TValue> From<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> entries)
        {
            Dictionary<TKey, TValue> dictionary;
            Validate.IsNotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(entries, "entries");
            ICollection<KeyValuePair<TKey, TValue>> is2 = entries as ICollection<KeyValuePair<TKey, TValue>>;
            if (is2 != null)
            {
                dictionary = new Dictionary<TKey, TValue>(is2.Count);
            }
            else
            {
                dictionary = new Dictionary<TKey, TValue>();
            }
            dictionary.AddRange<KeyValuePair<TKey, TValue>>(entries);
            return dictionary;
        }

        public static Dictionary<TKey, TValue> From<TKey, TValue>(IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            Validate.Begin().IsNotNull<IEnumerable<TKey>>(keys, "keys").IsNotNull<IEnumerable<TValue>>(values, "values").Check();
            Dictionary<TKey, TValue> dictionary = null;
            ICollection<TKey> is2 = keys as ICollection<TKey>;
            ICollection<TValue> is3 = values as ICollection<TValue>;
            if ((is2 != null) && (is3 != null))
            {
                int count = is3.Count;
                int capacity = is2.Count;
                if (capacity != count)
                {
                    ExceptionUtil.ThrowArgumentException("keys.Count != values.Count");
                }
                dictionary = new Dictionary<TKey, TValue>(capacity);
            }
            else if (is2 != null)
            {
                dictionary = new Dictionary<TKey, TValue>(is2.Count);
            }
            else if (is3 != null)
            {
                dictionary = new Dictionary<TKey, TValue>(is3.Count);
            }
            else
            {
                dictionary = new Dictionary<TKey, TValue>();
            }
            using (IEnumerator<TKey> enumerator = keys.GetEnumerator())
            {
                using (IEnumerator<TValue> enumerator2 = values.GetEnumerator())
                {
                    bool flag;
                Label_0092:
                    flag = enumerator2.MoveNext();
                    bool flag1 = enumerator.MoveNext();
                    if (flag1 != flag)
                    {
                        ExceptionUtil.ThrowArgumentException("keys.Count() != values.Count()");
                    }
                    if (flag1)
                    {
                        TKey current = enumerator.Current;
                        TValue local2 = enumerator2.Current;
                        dictionary.Add(current, local2);
                        goto Label_0092;
                    }
                }
            }
            return dictionary;
        }
    }
}

