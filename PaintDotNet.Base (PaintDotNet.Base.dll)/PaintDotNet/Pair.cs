namespace PaintDotNet
{
    using System;

    public static class Pair
    {
        public static Pair<T, U> Create<T, U>(T first, U second) => 
            new Pair<T, U>(first, second);
    }
}

