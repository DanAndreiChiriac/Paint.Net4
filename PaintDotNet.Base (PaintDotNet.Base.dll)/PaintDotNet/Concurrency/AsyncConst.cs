namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Functional;
    using System;

    internal sealed class AsyncConst : IAsync
    {
        private Result result;
        private static readonly AsyncConst unitAsync = new AsyncConst(Result.Void);

        public AsyncConst(Result result)
        {
            this.result = result;
        }

        public IAsync Receive(Action<Result> handler) => 
            new AsyncConst(handler.Try<Result>(this.result));

        public static IAsync Unit =>
            unitAsync;
    }
}

