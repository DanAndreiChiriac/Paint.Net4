namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Functional;
    using System;
    using System.Runtime.CompilerServices;

    public static class AsyncSourceExtensions
    {
        public static IAsync AsReceiveOnly(this IAsyncSource source) => 
            source;

        public static IAsync<T> AsReceiveOnly<T>(this IAsyncSource<T> source) => 
            source;

        public static bool Return(this IAsyncSource source) => 
            source.SetResult(Result.Void);

        public static bool Return<T>(this IAsyncSource<T> source, T value) => 
            source.SetResult(Result.New<T>(value));

        public static bool Throw(this IAsyncSource source, Exception ex) => 
            source.SetResult(Result.NewError(ex));

        public static bool Throw<T>(this IAsyncSource<T> source, Exception ex) => 
            source.SetResult(Result.NewError<T>(ex));
    }
}

