namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class TupleExtensions
    {
        public static Tuple<T1, T2, T3> GetTuple123<T1, T2, T3, T4>(this Tuple<T1, T2, T3, T4> source) => 
            Tuple.Create<T1, T2, T3>(source.Item1, source.Item2, source.Item3);

        public static Tuple<T2, T3, T4> GetTuple234<T1, T2, T3, T4>(this Tuple<T1, T2, T3, T4> source) => 
            Tuple.Create<T2, T3, T4>(source.Item2, source.Item3, source.Item4);
    }
}

