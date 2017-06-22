namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct HitTestPointResult : IEquatable<HitTestPointResult>
    {
        private bool isTrailingHit;
        private bool isInside;
        private PaintDotNet.DirectWrite.HitTestMetrics hitTestMetrics;
        public bool IsTrailingHit =>
            this.isTrailingHit;
        public bool IsInside =>
            this.isInside;
        public PaintDotNet.DirectWrite.HitTestMetrics HitTestMetrics =>
            this.hitTestMetrics;
        public HitTestPointResult(bool isTrailingHit, bool isInside, PaintDotNet.DirectWrite.HitTestMetrics hitTestMetrics)
        {
            this.isTrailingHit = isTrailingHit;
            this.isInside = isInside;
            this.hitTestMetrics = hitTestMetrics;
        }

        public bool Equals(HitTestPointResult other) => 
            (((this.isTrailingHit == other.isTrailingHit) && (this.isInside == other.isInside)) && (this.hitTestMetrics == other.hitTestMetrics));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<HitTestPointResult, object>(this, obj);

        public static bool operator ==(HitTestPointResult a, HitTestPointResult b) => 
            a.Equals(b);

        public static bool operator !=(HitTestPointResult a, HitTestPointResult b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.isTrailingHit.GetHashCode(), this.isInside.GetHashCode(), this.hitTestMetrics.GetHashCode());
    }
}

