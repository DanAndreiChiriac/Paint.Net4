namespace PaintDotNet.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiRational
    {
        private uint numerator;
        private uint denominator;
        public uint Numerator
        {
            get => 
                this.numerator;
            set
            {
                this.numerator = value;
            }
        }
        public uint Denominator
        {
            get => 
                this.denominator;
            set
            {
                this.denominator = value;
            }
        }
    }
}

