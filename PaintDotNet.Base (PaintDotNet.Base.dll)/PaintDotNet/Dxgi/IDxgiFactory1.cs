namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("770aae78-f26f-4dba-a829-253c83d1b387")]
    public interface IDxgiFactory1 : IDxgiFactory, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        IDxgiAdapter1 GetAdapter1(int adapter);

        bool IsCurrent { get; }
    }
}

