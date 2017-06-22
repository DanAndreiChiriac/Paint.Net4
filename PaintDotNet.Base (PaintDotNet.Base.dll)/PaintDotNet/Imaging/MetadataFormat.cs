namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MetadataFormat : IEquatable<MetadataFormat>
    {
        private System.Guid guid;
        public System.Guid Guid =>
            this.guid;
        public static explicit operator MetadataFormat(System.Guid guid) => 
            new MetadataFormat(guid);

        public static explicit operator System.Guid(MetadataFormat pixelFormat) => 
            pixelFormat.Guid;

        public MetadataFormat(System.Guid guid)
        {
            this.guid = guid;
        }

        public override string ToString() => 
            this.guid.ToString();

        public bool Equals(MetadataFormat other) => 
            (this.guid == other.guid);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<MetadataFormat, object>(this, obj);

        public static bool operator ==(MetadataFormat a, MetadataFormat b) => 
            a.Equals(b);

        public static bool operator !=(MetadataFormat a, MetadataFormat b) => 
            !(a == b);

        public override int GetHashCode() => 
            this.guid.GetHashCode();
    }
}

