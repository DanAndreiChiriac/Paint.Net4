namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Collections;
    using System;

    public interface IAsyncWorkDeque : IAsyncWorkQueue
    {
        IAsync Enqueue(QueueSide qSide, Action callback);
    }
}

