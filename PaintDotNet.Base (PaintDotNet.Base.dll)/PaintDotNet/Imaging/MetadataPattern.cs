namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MetadataPattern : IEquatable<MetadataPattern>
    {
        private long position;
        private byte[] pattern;
        private byte[] mask;
        private long dataOffset;
        public long Position =>
            this.position;
        public byte[] Pattern =>
            this.pattern;
        public byte[] Mask =>
            this.mask;
        public long DataOffset =>
            this.dataOffset;
        public MetadataPattern(long position, byte[] pattern, byte[] mask, long dataOffset)
        {
            Validate.Begin().IsNotNull<byte[]>(pattern, "pattern").IsNotNull<byte[]>(mask, "mask").Check().IsNotNegative(position, "position").IsNotNegative(dataOffset, "dataOffset").Check();
            if (pattern.Length != mask.Length)
            {
                throw new ArgumentException("pattern.Length must equal mask.Length");
            }
            this.position = position;
            this.pattern = pattern;
            this.mask = mask;
            this.dataOffset = dataOffset;
        }

        public bool Equals(MetadataPattern other) => 
            ((((this.position == other.position) && ArrayUtil.Equals(this.pattern, other.pattern)) && ArrayUtil.Equals(this.mask, other.mask)) && (this.dataOffset == other.dataOffset));

        public override bool Equals(object obj) => 
            base.Equals(obj);

        public static bool operator ==(MetadataPattern a, MetadataPattern b) => 
            a.Equals(b);

        public static bool operator !=(MetadataPattern a, MetadataPattern b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.position.GetHashCode(), HashCodeUtil.CreateHashCode<byte>(this.pattern), HashCodeUtil.CreateHashCode<byte>(this.mask), this.dataOffset.GetHashCode());
    }
}

