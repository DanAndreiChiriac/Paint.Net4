namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    public interface IObjectRefContainer : IDisposable, IIsDisposed
    {
        bool TryAttachObjectRef(object key, IObjectRef objectRef);
        bool? TryGetAttachedObjectRef(object key, Type interfaceType, out IObjectRef newObjectRef);
    }
}

