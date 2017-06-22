namespace PaintDotNet.Concurrency
{
    using System;

    internal sealed class NullAsync<T> : IAsync<T>, IAsync
    {
        private static readonly NullAsync<T> instance;

        static NullAsync()
        {
            NullAsync<T>.instance = new NullAsync<T>();
        }

        private NullAsync()
        {
        }

        public IAsync Receive(Action<Result> handler) => 
            this;

        public IAsync Receive(Action<Result<T>> handler) => 
            NullAsync.Instance;

        public static IAsync<T> Instance =>
            NullAsync<T>.instance;
    }
}

