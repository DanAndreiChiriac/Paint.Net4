namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LineSpacingParameters : IEquatable<LineSpacingParameters>
    {
        private PaintDotNet.DirectWrite.LineSpacingMethod lineSpacingMethod;
        private float lineSpacing;
        private float baseline;
        public PaintDotNet.DirectWrite.LineSpacingMethod LineSpacingMethod
        {
            get => 
                this.lineSpacingMethod;
            set
            {
                this.lineSpacingMethod = value;
            }
        }
        public float LineSpacing
        {
            get => 
                this.lineSpacing;
            set
            {
                this.lineSpacing = value;
            }
        }
        public float Baseline
        {
            get => 
                this.baseline;
            set
            {
                this.baseline = value;
            }
        }
        public LineSpacingParameters(PaintDotNet.DirectWrite.LineSpacingMethod lineSpacingMethod, float lineSpacing, float baseline)
        {
            this.lineSpacingMethod = lineSpacingMethod;
            this.lineSpacing = lineSpacing;
            this.baseline = baseline;
        }

        public bool Equals(LineSpacingParameters other) => 
            (((this.lineSpacingMethod == other.lineSpacingMethod) && (this.lineSpacing == other.lineSpacing)) && (this.baseline == other.baseline));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<LineSpacingParameters, object>(this, obj);

        public static bool operator ==(LineSpacingParameters a, LineSpacingParameters b) => 
            a.Equals(b);

        public static bool operator !=(LineSpacingParameters a, LineSpacingParameters b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.lineSpacingMethod, this.lineSpacing.GetHashCode(), this.baseline.GetHashCode());
    }
}

