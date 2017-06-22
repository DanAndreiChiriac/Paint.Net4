namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;

    public interface IValueRef<T> : IObjectRef, IDisposable, IIsDisposed
    {
        T Value { get; }
    }
}

