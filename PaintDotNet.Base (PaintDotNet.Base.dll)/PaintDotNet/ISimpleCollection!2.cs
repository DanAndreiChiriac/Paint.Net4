namespace PaintDotNet
{
    using System;

    [Obsolete("This class is only provided for compatibility with older plugins.", true)]
    public interface ISimpleCollection<K, V>
    {
        V Get(K key);
        void Set(K key, V value);
    }
}

