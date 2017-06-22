namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct SwapChainDescription
    {
        private ModeDescription bufferDesc;
        private PaintDotNet.Dxgi.SampleDescription sampleDesc;
        private UsageOptions bufferUsage;
        private uint bufferCount;
        private IntPtr outputWindow;
        [MarshalAs(UnmanagedType.Bool)]
        private bool windowed;
        private PaintDotNet.Dxgi.SwapEffect swapEffect;
        private SwapChainFlags flags;
        public ModeDescription BufferDescription =>
            this.bufferDesc;
        public PaintDotNet.Dxgi.SampleDescription SampleDescription =>
            this.sampleDesc;
        public UsageOptions BufferUsage =>
            this.bufferUsage;
        public int BufferCount =>
            ((int) this.bufferCount);
        public IntPtr OutputWindow =>
            this.outputWindow;
        public bool IsWindowed =>
            this.windowed;
        public PaintDotNet.Dxgi.SwapEffect SwapEffect =>
            this.swapEffect;
        public SwapChainFlags Flags =>
            this.flags;
    }
}

