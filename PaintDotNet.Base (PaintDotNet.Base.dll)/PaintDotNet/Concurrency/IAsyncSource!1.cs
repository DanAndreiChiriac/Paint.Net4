namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Functional;
    using System;

    public interface IAsyncSource<T> : IAsync<T>, IAsync
    {
        bool SetResult(Result<T> result);
    }
}

