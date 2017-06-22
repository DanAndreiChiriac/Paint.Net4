namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Functional;
    using System;

    public static class Async
    {
        public static IAsync Const() => 
            AsyncConst.Unit;

        public static IAsync<T> Const<T>(Result<T> result) => 
            new AsyncConst<T>(result);

        public static IAsync<T> ConstError<T>(Exception error) => 
            new AsyncConst<T>(Result.NewError<T>(error));

        public static IAsync<T> ConstValue<T>(T value) => 
            new AsyncConst<T>(Result.New<T>(value));

        public static IAsync Never() => 
            NullAsync.Instance;

        public static IAsync Never<T>() => 
            NullAsync<T>.Instance;

        public static IAsyncSource NewSource() => 
            new AsyncSource();

        public static IAsyncSource<T> NewSource<T>() => 
            new AsyncSource<T>();
    }
}

