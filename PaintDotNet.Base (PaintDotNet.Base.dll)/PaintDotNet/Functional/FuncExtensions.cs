namespace PaintDotNet.Functional
{
    using System;
    using System.Runtime.CompilerServices;

    public static class FuncExtensions
    {
        public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> func) where T: IEquatable<T> => 
            Func.Memoize<T, TResult>(func);
    }
}

