namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OverhangMetrics : IEquatable<OverhangMetrics>
    {
        private float left;
        private float top;
        private float right;
        private float bottom;
        public float Left =>
            this.left;
        public float Top =>
            this.top;
        public float Right =>
            this.right;
        public float Bottom =>
            this.bottom;
        public OverhangMetrics(float left, float top, float right, float bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public bool Equals(OverhangMetrics other) => 
            ((((this.left == other.left) && (this.top == other.top)) && (this.right == other.right)) && (this.bottom == other.bottom));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<OverhangMetrics, object>(this, obj);

        public static bool operator ==(OverhangMetrics a, OverhangMetrics b) => 
            a.Equals(b);

        public static bool operator !=(OverhangMetrics a, OverhangMetrics b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.left.GetHashCode(), this.top.GetHashCode(), this.right.GetHashCode(), this.bottom.GetHashCode());
    }
}

