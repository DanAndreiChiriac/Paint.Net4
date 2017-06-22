namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ImagingContainerFormat : IEquatable<ImagingContainerFormat>
    {
        private System.Guid guid;
        public System.Guid Guid =>
            this.guid;
        public static explicit operator ImagingContainerFormat(System.Guid guid) => 
            new ImagingContainerFormat(guid);

        public static explicit operator System.Guid(ImagingContainerFormat pixelFormat) => 
            pixelFormat.Guid;

        public ImagingContainerFormat(System.Guid guid)
        {
            this.guid = guid;
        }

        public override string ToString() => 
            this.guid.ToString();

        public bool Equals(ImagingContainerFormat other) => 
            (this.guid == other.guid);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ImagingContainerFormat, object>(this, obj);

        public static bool operator ==(ImagingContainerFormat a, ImagingContainerFormat b) => 
            a.Equals(b);

        public static bool operator !=(ImagingContainerFormat a, ImagingContainerFormat b) => 
            !(a == b);

        public override int GetHashCode() => 
            this.guid.GetHashCode();
    }
}

