namespace PaintDotNet.Concurrency
{
    using System;

    public interface IAsync
    {
        IAsync Receive(Action<Result> handler);
    }
}

