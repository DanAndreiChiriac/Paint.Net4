namespace PaintDotNet.ComponentModel
{
    using System;

    public interface IObjectRefHolder : IDisposable
    {
        IObjectRef ObjectRef { get; }
    }
}

