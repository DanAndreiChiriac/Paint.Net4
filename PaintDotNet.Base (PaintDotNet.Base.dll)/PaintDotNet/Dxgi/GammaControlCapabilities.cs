namespace PaintDotNet.Dxgi
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct GammaControlCapabilities
    {
        private const int maxControlPointPositionsCount = 0x401;
        [MarshalAs(UnmanagedType.Bool)]
        private bool scaleAndOffsetSupported;
        private float maxConvertedValue;
        private float minConvertedValue;
        private int numGammaControlPoints;
        [FixedBuffer(typeof(float), 0x401)]
        private <controlPointPositions>e__FixedBuffer controlPointPositions;
        public static int MaxGammaControlPointsCount =>
            0x401;
        public bool ScaleAndOffsetSupported =>
            this.scaleAndOffsetSupported;
        public float MaxConvertedValue =>
            this.maxConvertedValue;
        public float MinConvertedValue =>
            this.minConvertedValue;
        public int GammaControlPointsCount =>
            this.numGammaControlPoints;
        public unsafe float GetGammaControlPoint(int index)
        {
            Validate.IsClamped(index, 0, this.GammaControlPointsCount - 1, "index");
            fixed (float* numRef = &this.controlPointPositions.FixedElementField)
            {
                return numRef[index * 4];
            }
        }
        [StructLayout(LayoutKind.Sequential, Size=0x1004), CompilerGenerated, UnsafeValueType]
        public struct <controlPointPositions>e__FixedBuffer
        {
            public float FixedElementField;
        }
    }
}

