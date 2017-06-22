namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("29038f61-3839-4626-91fd-086879011a05")]
    public interface IDxgiAdapter1 : IDxgiAdapter, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        AdapterDescription1 Description1 { get; }
    }
}

