namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Functional;
    using System;

    public interface IAsyncSource : IAsync
    {
        bool SetResult(Result result);
    }
}

