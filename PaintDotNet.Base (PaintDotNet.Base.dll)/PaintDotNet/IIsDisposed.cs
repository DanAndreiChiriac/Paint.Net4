namespace PaintDotNet
{
    using System;

    public interface IIsDisposed : IDisposable
    {
        bool IsDisposed { get; }
    }
}

