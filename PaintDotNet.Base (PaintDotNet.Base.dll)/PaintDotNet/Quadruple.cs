namespace PaintDotNet
{
    using System;

    [Obsolete("Use Tuple or TupleStruct instead")]
    public static class Quadruple
    {
        public static Quadruple<T, U, V, W> Create<T, U, V, W>(T first, U second, V third, W fourth) => 
            new Quadruple<T, U, V, W>(first, second, third, fourth);
    }
}

