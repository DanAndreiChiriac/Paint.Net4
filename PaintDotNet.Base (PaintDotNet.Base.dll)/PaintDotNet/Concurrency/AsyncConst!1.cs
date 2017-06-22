namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Functional;
    using System;

    internal sealed class AsyncConst<T> : IAsync<T>, IAsync
    {
        private readonly Result<T> result;

        public AsyncConst(Result<T> result)
        {
            this.result = result;
        }

        public IAsync Receive(Action<Result> handler) => 
            new AsyncConst(handler.Try<Result>(this.result));

        public IAsync Receive(Action<Result<T>> handler) => 
            new AsyncConst(handler.Try<Result<T>>(this.result));
    }
}

