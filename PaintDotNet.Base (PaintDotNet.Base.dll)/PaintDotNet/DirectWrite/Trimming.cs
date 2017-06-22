namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Trimming : IEquatable<Trimming>
    {
        private TrimmingGranularity granularity;
        private uint delimiter;
        private int delimiterCount;
        public TrimmingGranularity Granularity =>
            this.granularity;
        public uint Delimiter =>
            this.delimiter;
        public int DelimiterCount =>
            this.delimiterCount;
        public Trimming(TrimmingGranularity granularity, uint delimiter, int delimiterCount)
        {
            this.granularity = granularity;
            this.delimiter = delimiter;
            this.delimiterCount = delimiterCount;
        }

        public bool Equals(Trimming other) => 
            (((this.granularity == other.granularity) && (this.delimiter == other.delimiter)) && (this.delimiterCount == other.delimiterCount));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<Trimming, object>(this, obj);

        public static bool operator ==(Trimming a, Trimming b) => 
            a.Equals(b);

        public static bool operator !=(Trimming a, Trimming b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.granularity, this.delimiter.GetHashCode(), this.delimiterCount.GetHashCode());
    }
}

