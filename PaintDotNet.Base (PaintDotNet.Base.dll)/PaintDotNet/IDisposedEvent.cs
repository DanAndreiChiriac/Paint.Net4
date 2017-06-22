namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public interface IDisposedEvent
    {
        event EventHandler Disposed;
    }
}

