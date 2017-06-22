namespace PaintDotNet.MemoryManagement
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IMemoryObject : IObjectRef, IDisposable, IIsDisposed
    {
    }
}

