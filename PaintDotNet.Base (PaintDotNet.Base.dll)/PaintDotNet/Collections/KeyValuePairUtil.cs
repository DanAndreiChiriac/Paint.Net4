namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class KeyValuePairUtil
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KeyValuePair<TKey, TValue> Create<TKey, TValue>(TKey key, TValue value) => 
            new KeyValuePair<TKey, TValue>(key, value);
    }
}

