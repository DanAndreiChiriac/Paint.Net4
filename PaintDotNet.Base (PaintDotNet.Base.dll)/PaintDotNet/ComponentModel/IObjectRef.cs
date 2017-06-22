namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("00000000-0000-0000-C000-000000000046")]
    public interface IObjectRef : IDisposable, IIsDisposed
    {
        bool? TryCreateRef(Type interfaceType, out IObjectRef newObjectRef);
    }
}

