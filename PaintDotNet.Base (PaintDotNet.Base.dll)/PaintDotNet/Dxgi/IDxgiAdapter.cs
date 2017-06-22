namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("2411e7e1-12ac-4ccf-bd14-9798e8534dc0")]
    public interface IDxgiAdapter : IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        IDxgiOutput GetOutput(int outputIndex);

        AdapterDescription Description { get; }
    }
}

