namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct PointAndTangentDouble : IEquatable<PointAndTangentDouble>
    {
        private PointDouble point;
        private VectorDouble tangent;
        public PointDouble Point =>
            this.point;
        public VectorDouble Tangent =>
            this.tangent;
        public static implicit operator PointAndTangentDouble(PointAndTangentFloat value) => 
            new PointAndTangentDouble(value.Point, value.Tangent);

        public PointAndTangentDouble(PointDouble point, VectorDouble tangent)
        {
            this.point = point;
            this.tangent = tangent;
        }

        public bool Equals(PointAndTangentDouble other) => 
            ((this.point == other.point) && (this.tangent == other.tangent));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<PointAndTangentDouble, object>(this, obj);

        public static bool operator ==(PointAndTangentDouble a, PointAndTangentDouble b) => 
            a.Equals(b);

        public static bool operator !=(PointAndTangentDouble a, PointAndTangentDouble b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point.GetHashCode(), this.tangent.GetHashCode());
    }
}

