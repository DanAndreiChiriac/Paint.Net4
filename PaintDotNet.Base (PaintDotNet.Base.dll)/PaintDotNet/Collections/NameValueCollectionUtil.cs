namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    public static class NameValueCollectionUtil
    {
        public static NameValueCollection From(IEnumerable<KeyValuePair<string, string>> items)
        {
            NameValueCollection values;
            ICollection<KeyValuePair<string, string>> is2 = items as ICollection<KeyValuePair<string, string>>;
            if (is2 != null)
            {
                values = new NameValueCollection(is2.Count);
            }
            else
            {
                values = new NameValueCollection();
            }
            foreach (KeyValuePair<string, string> pair in items)
            {
                values.Add(pair.Key, pair.Value);
            }
            return values;
        }
    }
}

