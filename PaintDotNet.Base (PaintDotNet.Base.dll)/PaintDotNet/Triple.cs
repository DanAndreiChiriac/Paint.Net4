namespace PaintDotNet
{
    using System;

    [Obsolete("Use Tuple or TupleStruct instead")]
    public static class Triple
    {
        public static Triple<T, U, V> Create<T, U, V>(T first, U second, V third) => 
            new Triple<T, U, V>(first, second, third);
    }
}

