namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;

    public interface IObjectRefProxy : IObjectRef, IDisposable, IIsDisposed, ICleanupContainer
    {
        IObjectRef InnerRef { get; }
    }
}

