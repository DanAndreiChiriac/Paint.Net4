namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LineMetrics : IEquatable<LineMetrics>
    {
        private int length;
        private int trailingWhitespaceLength;
        private int newlineLength;
        private float height;
        private float baseline;
        public int Length =>
            this.length;
        public int TrailingWhitespaceLength =>
            this.trailingWhitespaceLength;
        public int NewlineLength =>
            this.newlineLength;
        public float Height =>
            this.height;
        public float Baseline =>
            this.baseline;
        public LineMetrics(int length, int trailingWhitespaceLength, int newlineLength, float height, float baseline)
        {
            this.length = length;
            this.trailingWhitespaceLength = trailingWhitespaceLength;
            this.newlineLength = newlineLength;
            this.height = height;
            this.baseline = baseline;
        }

        public bool Equals(LineMetrics other) => 
            ((((this.length == other.length) && (this.trailingWhitespaceLength == other.trailingWhitespaceLength)) && ((this.newlineLength == other.newlineLength) && (this.height == other.height))) && (this.baseline == other.baseline));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<LineMetrics, object>(this, obj);

        public static bool operator ==(LineMetrics a, LineMetrics b) => 
            a.Equals(b);

        public static bool operator !=(LineMetrics a, LineMetrics b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.length.GetHashCode(), this.trailingWhitespaceLength.GetHashCode(), this.newlineLength.GetHashCode(), this.height.GetHashCode(), this.baseline.GetHashCode());
    }
}

