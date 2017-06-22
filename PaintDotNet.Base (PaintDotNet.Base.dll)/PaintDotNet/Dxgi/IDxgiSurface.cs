namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("cafcb56c-6ac3-4889-bf47-9e23bbd260ec")]
    public interface IDxgiSurface : IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        MappedRect Map(MapOptions flags);
        void Unmap();

        SurfaceDescription Description { get; }
    }
}

