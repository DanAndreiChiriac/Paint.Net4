namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TrimmingParameters : IEquatable<TrimmingParameters>
    {
        private Trimming trimmingOptions;
        private IInlineObject trimmingSign;
        public Trimming TrimmingOptions =>
            this.trimmingOptions;
        public IInlineObject TrimmingSign =>
            this.trimmingSign;
        public TrimmingParameters(Trimming trimmingOptions, IInlineObject trimmingSign)
        {
            this.trimmingOptions = trimmingOptions;
            this.trimmingSign = trimmingSign;
        }

        public bool Equals(TrimmingParameters other) => 
            ((this.trimmingOptions == other.trimmingOptions) && (this.trimmingSign == other.trimmingSign));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<TrimmingParameters, object>(this, obj);

        public static bool operator ==(TrimmingParameters a, TrimmingParameters b) => 
            a.Equals(b);

        public static bool operator !=(TrimmingParameters a, TrimmingParameters b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.trimmingOptions.GetHashCode(), this.trimmingSign.GetHashCode());
    }
}

