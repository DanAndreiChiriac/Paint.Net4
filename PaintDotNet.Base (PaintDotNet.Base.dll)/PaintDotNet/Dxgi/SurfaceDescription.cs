namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct SurfaceDescription
    {
        private uint width;
        private uint height;
        private DxgiFormat format;
        private PaintDotNet.Dxgi.SampleDescription sampleDesc;
        public int Width =>
            ((int) this.width);
        public int Height =>
            ((int) this.height);
        public DxgiFormat Format =>
            this.format;
        public PaintDotNet.Dxgi.SampleDescription SampleDescription =>
            this.sampleDesc;
    }
}

