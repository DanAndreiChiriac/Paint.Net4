namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Tag : IEquatable<Tag>
    {
        private ulong value;
        public ulong Value
        {
            get => 
                this.value;
            set
            {
                this.value = value;
            }
        }
        public Tag(ulong value)
        {
            this.value = value;
        }

        public override int GetHashCode() => 
            this.value.GetHashCode();

        public bool Equals(Tag other) => 
            (this.value == other.value);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<Tag, object>(this, obj);

        public static bool operator ==(Tag a, Tag b) => 
            a.Equals(b);

        public static bool operator !=(Tag a, Tag b) => 
            !(a == b);
    }
}

