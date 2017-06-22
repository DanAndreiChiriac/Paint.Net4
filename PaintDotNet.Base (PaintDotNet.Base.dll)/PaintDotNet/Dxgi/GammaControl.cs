namespace PaintDotNet.Dxgi
{
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Imaging;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct GammaControl
    {
        private const int gammaCurveCount = 0x401;
        private ColorRgb96Float scale;
        private ColorRgb96Float offset;
        [FixedBuffer(typeof(float), 0xc03)]
        private <gammaCurve>e__FixedBuffer gammaCurve;
        public ColorRgb96Float Scale
        {
            get => 
                this.scale;
            set
            {
                this.scale = value;
            }
        }
        public ColorRgb96Float Offset
        {
            get => 
                this.offset;
            set
            {
                this.offset = value;
            }
        }
        public int GammaCurveValueCount =>
            0x401;
        public unsafe ColorRgb96Float GetGammaCurveValue(int index)
        {
            Validate.IsClamped(index, 0, 0x400, "index");
            fixed (float* numRef = &this.gammaCurve.FixedElementField)
            {
                int num = index * 3;
                return new ColorRgb96Float(numRef[num * 4], numRef[(num + 1) * 4], numRef[(num + 2) * 4]);
            }
        }

        public unsafe void SetGammaCurveValue(int index, ColorRgb96Float value)
        {
            Validate.IsClamped(index, 0, 0x400, "index");
            fixed (float* numRef = &this.gammaCurve.FixedElementField)
            {
                int num = index * 3;
                numRef[num * 4] = value.R;
                numRef[(num + 1) * 4] = value.G;
                numRef[(num + 2) * 4] = value.B;
            }
        }
        [StructLayout(LayoutKind.Sequential, Size=0x300c), CompilerGenerated, UnsafeValueType]
        public struct <gammaCurve>e__FixedBuffer
        {
            public float FixedElementField;
        }
    }
}

