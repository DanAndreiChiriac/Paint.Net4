namespace PaintDotNet.Concurrency
{
    using System;

    internal sealed class NullAsync : IAsync
    {
        private static readonly NullAsync instance = new NullAsync();

        private NullAsync()
        {
        }

        public IAsync Receive(Action<Result> handler) => 
            this;

        public static IAsync Instance =>
            instance;
    }
}

