namespace PaintDotNet.ComponentModel
{
    using System;

    public interface IObjectRefHolder<T> : IObjectRefHolder, IDisposable where T: class, IObjectRef
    {
        T ObjectRef { get; }
    }
}

