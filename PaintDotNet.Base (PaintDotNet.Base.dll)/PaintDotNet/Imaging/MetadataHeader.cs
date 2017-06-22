namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MetadataHeader : IEquatable<MetadataHeader>
    {
        private long position;
        private byte[] header;
        private long dataOffset;
        public long Position =>
            this.position;
        public byte[] Header =>
            this.header;
        public long DataOffset =>
            this.dataOffset;
        public MetadataHeader(long position, byte[] header, long dataOffset)
        {
            Validate.Begin().IsNotNull<byte[]>(header, "header").Check().IsNotNegative(position, "position").IsNotNegative(dataOffset, "dataOffset").Check();
            this.position = position;
            this.header = header;
            this.dataOffset = dataOffset;
        }

        public bool Equals(MetadataHeader other) => 
            (((this.position == other.position) && ArrayUtil.Equals(this.header, other.header)) && (this.dataOffset == other.dataOffset));

        public override bool Equals(object obj) => 
            base.Equals(obj);

        public static bool operator ==(MetadataHeader a, MetadataHeader b) => 
            a.Equals(b);

        public static bool operator !=(MetadataHeader a, MetadataHeader b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.position.GetHashCode(), HashCodeUtil.CreateHashCode<byte>(this.header), this.dataOffset.GetHashCode());
    }
}

