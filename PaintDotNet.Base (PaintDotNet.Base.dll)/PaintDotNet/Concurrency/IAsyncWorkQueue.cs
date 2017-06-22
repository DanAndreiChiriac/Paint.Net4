namespace PaintDotNet.Concurrency
{
    using System;

    public interface IAsyncWorkQueue
    {
        IAsync BeginTry(Action callback);
    }
}

