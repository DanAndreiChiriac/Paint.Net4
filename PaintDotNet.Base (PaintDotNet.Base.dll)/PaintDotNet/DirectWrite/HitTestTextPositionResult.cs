namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct HitTestTextPositionResult : IEquatable<HitTestTextPositionResult>
    {
        private PointFloat point;
        private PaintDotNet.DirectWrite.HitTestMetrics hitTestMetrics;
        public PointFloat Point =>
            this.point;
        public PaintDotNet.DirectWrite.HitTestMetrics HitTestMetrics =>
            this.hitTestMetrics;
        public HitTestTextPositionResult(PointFloat point, PaintDotNet.DirectWrite.HitTestMetrics hitTestMetrics)
        {
            this.point = point;
            this.hitTestMetrics = hitTestMetrics;
        }

        public bool Equals(HitTestTextPositionResult other) => 
            ((this.point == other.point) && (this.hitTestMetrics == other.hitTestMetrics));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<HitTestTextPositionResult, object>(this, obj);

        public static bool operator ==(HitTestTextPositionResult a, HitTestTextPositionResult b) => 
            a.Equals(b);

        public static bool operator !=(HitTestTextPositionResult a, HitTestTextPositionResult b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point.GetHashCode(), this.hitTestMetrics.GetHashCode());
    }
}

