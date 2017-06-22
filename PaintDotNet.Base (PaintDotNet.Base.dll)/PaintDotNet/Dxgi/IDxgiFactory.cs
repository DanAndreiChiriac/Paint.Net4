namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("7b7166ec-21c7-44ae-b21a-c9ae321ae369")]
    public interface IDxgiFactory : IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        IDxgiAdapter CreateSoftwareAdapter(IntPtr module);
        IDxgiSwapChain CreateSwapChain(object device, SwapChainDescription description, out bool isOccluded);
        IDxgiAdapter GetAdapter(int adapterIndex);
        IntPtr GetWindowAssociation();
        void MakeWindowAssociation(IntPtr windowHandle, MakeWindowAssociationOptions flags);
    }
}

