namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ImagingVendor : IEquatable<ImagingVendor>
    {
        private System.Guid guid;
        public System.Guid Guid =>
            this.guid;
        public static explicit operator ImagingVendor(System.Guid guid) => 
            new ImagingVendor(guid);

        public static explicit operator System.Guid(ImagingVendor pixelFormat) => 
            pixelFormat.Guid;

        public ImagingVendor(System.Guid guid)
        {
            this.guid = guid;
        }

        public override string ToString() => 
            this.guid.ToString();

        public bool Equals(ImagingVendor other) => 
            (this.guid == other.guid);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ImagingVendor, object>(this, obj);

        public static bool operator ==(ImagingVendor a, ImagingVendor b) => 
            a.Equals(b);

        public static bool operator !=(ImagingVendor a, ImagingVendor b) => 
            !(a == b);

        public override int GetHashCode() => 
            this.guid.GetHashCode();
    }
}

