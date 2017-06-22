namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RawToneCurvePoint : IEquatable<RawToneCurvePoint>
    {
        private double input;
        private double output;
        public double Input
        {
            get => 
                this.input;
            set
            {
                this.input = value;
            }
        }
        public double Output
        {
            get => 
                this.output;
            set
            {
                this.output = value;
            }
        }
        public RawToneCurvePoint(double input, double output)
        {
            this.input = input;
            this.output = output;
        }

        public bool Equals(RawToneCurvePoint other) => 
            ((this.input == other.input) && (this.output == other.input));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<RawToneCurvePoint, object>(this, obj);

        public static bool operator ==(RawToneCurvePoint a, RawToneCurvePoint b) => 
            a.Equals(b);

        public static bool operator !=(RawToneCurvePoint a, RawToneCurvePoint b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.input.GetHashCode(), this.output.GetHashCode());
    }
}

