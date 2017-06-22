namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Runtime.CompilerServices;

    public static class NameValueCollectionExtensions
    {
        public static KeyValuePair<string, string>[] ToArray(this NameValueCollection nameValueCollection)
        {
            if (nameValueCollection.Count == 0)
            {
                return Array.Empty<KeyValuePair<string, string>>();
            }
            KeyValuePair<string, string>[] pairArray = new KeyValuePair<string, string>[nameValueCollection.Count];
            for (int i = 0; i < nameValueCollection.Count; i++)
            {
                pairArray[i] = new KeyValuePair<string, string>(nameValueCollection.GetKey(i), nameValueCollection.Get(i));
            }
            return pairArray;
        }
    }
}

