namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class HashSetExtensions
    {
        public static ReadOnlyHashSet<T> AsReadOnly<T>(this HashSet<T> source) => 
            new ReadOnlyHashSet<T>(source);
    }
}

