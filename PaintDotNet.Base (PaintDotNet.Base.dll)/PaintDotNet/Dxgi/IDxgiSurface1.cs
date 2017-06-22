namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("4ae63092-6327-4c1b-80ae-bfe12ea32b86")]
    public interface IDxgiSurface1 : IDxgiSurface, IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        IntPtr GetDC(bool discard);
        void ReleaseDC(RectInt32? dirtyRect = new RectInt32?());
    }
}

