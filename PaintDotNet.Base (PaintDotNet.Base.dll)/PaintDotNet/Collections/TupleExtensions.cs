namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class TupleExtensions
    {
        public static TupleStruct<T1, T2> AddTuple<T1, T2>(this ICollection<TupleStruct<T1, T2>> collection, T1 item1, T2 item2)
        {
            TupleStruct<T1, T2> item = TupleStruct.Create<T1, T2>(item1, item2);
            collection.Add(item);
            return item;
        }
    }
}

