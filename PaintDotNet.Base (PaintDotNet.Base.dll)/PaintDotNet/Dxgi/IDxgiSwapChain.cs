namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a")]
    public interface IDxgiSwapChain : IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        object GetBuffer(int buferIndex, Type surfaceType);
        bool GetFullscreenState(out IDxgiOutput target);
        DxgiError Present(int syncInterval, DxgiPresentOptions flags);
        void ResizeBuffers(int bufferCount, int width, int height, DxgiFormat newFormat, SwapChainFlags swapChainFlags);
        void ResizeTarget(ModeDescription newTargetParameters);
        void SetFullscreenState(bool fullscreen, IDxgiOutput target);

        IDxgiOutput ContainingOutput { get; }

        SwapChainDescription Description { get; }

        PaintDotNet.Dxgi.FrameStatistics FrameStatistics { get; }

        long LastPresentCount { get; }
    }
}

