namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("9d8e1289-d7b3-465f-8126-250e349af85d")]
    public interface IDxgiKeyedMutex : IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        bool AcquireSync(long key, int milliseconds);
        void ReleaseSync(long key);
    }
}

