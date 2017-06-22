namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FontFeature : IEquatable<FontFeature>
    {
        private FontFeatureTag nameTag;
        private uint parameter;
        public FontFeatureTag NameTag =>
            this.nameTag;
        public uint Parameter =>
            this.parameter;
        public FontFeature(FontFeatureTag nameTag, uint parameter)
        {
            this.nameTag = nameTag;
            this.parameter = parameter;
        }

        public bool Equals(FontFeature other) => 
            ((this.nameTag == other.nameTag) && (this.parameter == other.parameter));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<FontFeature, object>(this, obj);

        public static bool operator ==(FontFeature a, FontFeature b) => 
            a.Equals(b);

        public static bool operator !=(FontFeature a, FontFeature b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.nameTag, this.parameter.GetHashCode());
    }
}

