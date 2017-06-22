namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("aec22fb8-76f3-4639-9be0-28eb43a67a2e")]
    public interface IDxgiObject : IObjectRef, IDisposable, IIsDisposed
    {
        IDxgiObject Parent { get; }
    }
}

