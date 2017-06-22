namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ModeDescription
    {
        private uint width;
        private uint height;
        private DxgiRational refreshRate;
        private DxgiFormat format;
        private ScanlineOrderMode scanlineOrdering;
        private ScalingMode scaling;
        public int Width =>
            ((int) this.width);
        public int Height =>
            ((int) this.height);
        public DxgiRational RefreshRate =>
            this.refreshRate;
        public DxgiFormat Format =>
            this.format;
        public ScanlineOrderMode ScanlineOrdering =>
            this.scanlineOrdering;
        public ScalingMode Scaling =>
            this.scaling;
    }
}

