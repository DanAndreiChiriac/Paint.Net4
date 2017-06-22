namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct PointAndTangentFloat : IEquatable<PointAndTangentFloat>
    {
        private PointFloat point;
        private VectorFloat tangent;
        public PointFloat Point =>
            this.point;
        public VectorFloat Tangent =>
            this.tangent;
        public static explicit operator PointAndTangentFloat(PointAndTangentDouble value) => 
            new PointAndTangentFloat((PointFloat) value.Point, (VectorFloat) value.Tangent);

        public PointAndTangentFloat(PointFloat point, VectorFloat tangent)
        {
            this.point = point;
            this.tangent = tangent;
        }

        public bool Equals(PointAndTangentFloat other) => 
            ((this.point == other.point) && (this.tangent == other.tangent));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<PointAndTangentFloat, object>(this, obj);

        public static bool operator ==(PointAndTangentFloat a, PointAndTangentFloat b) => 
            a.Equals(b);

        public static bool operator !=(PointAndTangentFloat a, PointAndTangentFloat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point.GetHashCode(), this.tangent.GetHashCode());
    }
}

