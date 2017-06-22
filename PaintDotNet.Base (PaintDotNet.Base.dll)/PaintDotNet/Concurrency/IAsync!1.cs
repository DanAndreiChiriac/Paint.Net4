namespace PaintDotNet.Concurrency
{
    using System;

    public interface IAsync<T> : IAsync
    {
        IAsync Receive(Action<Result<T>> handler);
    }
}

