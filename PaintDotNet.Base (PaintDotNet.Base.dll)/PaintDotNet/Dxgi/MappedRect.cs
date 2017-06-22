namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MappedRect
    {
        private int pitch;
        private IntPtr pBits;
        public int Pitch =>
            this.pitch;
        public IntPtr Bits =>
            this.pBits;
    }
}

