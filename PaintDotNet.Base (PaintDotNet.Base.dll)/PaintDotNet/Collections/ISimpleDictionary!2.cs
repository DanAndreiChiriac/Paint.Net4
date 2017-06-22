namespace PaintDotNet.Collections
{
    using System;

    public interface ISimpleDictionary<K, V>
    {
        V Get(K key);
        void Set(K key, V value);
    }
}

