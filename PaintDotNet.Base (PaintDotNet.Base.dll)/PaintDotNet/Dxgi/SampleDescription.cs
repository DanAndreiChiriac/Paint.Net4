namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct SampleDescription
    {
        private uint count;
        private uint quality;
        public uint Count =>
            this.count;
        public uint Quality =>
            this.quality;
    }
}

