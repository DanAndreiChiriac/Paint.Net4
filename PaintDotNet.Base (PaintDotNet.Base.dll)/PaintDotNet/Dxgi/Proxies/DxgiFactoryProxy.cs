namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiFactoryProxy : ObjectRefProxy<IDxgiFactory>, IDxgiFactory, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiFactoryProxy(IDxgiFactory objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDxgiAdapter CreateSoftwareAdapter(IntPtr module) => 
            base.innerRefT.CreateSoftwareAdapter(module);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDxgiSwapChain CreateSwapChain(object device, SwapChainDescription description, out bool isOccluded) => 
            base.innerRefT.CreateSwapChain(device, description, out isOccluded);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDxgiAdapter GetAdapter(int adapterIndex) => 
            base.innerRefT.GetAdapter(adapterIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IntPtr GetWindowAssociation() => 
            base.innerRefT.GetWindowAssociation();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MakeWindowAssociation(IntPtr windowHandle, MakeWindowAssociationOptions flags)
        {
            base.innerRefT.MakeWindowAssociation(windowHandle, flags);
        }

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

