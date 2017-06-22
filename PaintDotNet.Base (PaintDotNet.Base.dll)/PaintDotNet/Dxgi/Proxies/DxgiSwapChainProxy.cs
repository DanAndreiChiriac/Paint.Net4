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
    public class DxgiSwapChainProxy : ObjectRefProxy<IDxgiSwapChain>, IDxgiSwapChain, IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSwapChainProxy(IDxgiSwapChain objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetBuffer(int buferIndex, Type surfaceType) => 
            base.innerRefT.GetBuffer(buferIndex, surfaceType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetFullscreenState(out IDxgiOutput target) => 
            base.innerRefT.GetFullscreenState(out target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiError Present(int syncInterval, DxgiPresentOptions flags) => 
            base.innerRefT.Present(syncInterval, flags);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ResizeBuffers(int bufferCount, int width, int height, DxgiFormat newFormat, SwapChainFlags swapChainFlags)
        {
            base.innerRefT.ResizeBuffers(bufferCount, width, height, newFormat, swapChainFlags);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ResizeTarget(ModeDescription newTargetParameters)
        {
            base.innerRefT.ResizeTarget(newTargetParameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFullscreenState(bool fullscreen, IDxgiOutput target)
        {
            base.innerRefT.SetFullscreenState(fullscreen, target);
        }

        public IDxgiOutput ContainingOutput =>
            base.innerRefT.ContainingOutput;

        public SwapChainDescription Description =>
            base.innerRefT.Description;

        public IDxgiDevice Device =>
            base.innerRefT.Device;

        public PaintDotNet.Dxgi.FrameStatistics FrameStatistics =>
            base.innerRefT.FrameStatistics;

        public long LastPresentCount =>
            base.innerRefT.LastPresentCount;

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

