namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct PointDescriptionFloat : IEquatable<PointDescriptionFloat>
    {
        private PointFloat point;
        private PointFloat unitTangentVector;
        private int endSegment;
        private int endFigure;
        private float lengthToEndSegment;
        public PointDescriptionFloat(PointFloat point, PointFloat unitTangentVector, int endSegment, int endFigure, float lengthToEndSegment)
        {
            this.point = point;
            this.unitTangentVector = unitTangentVector;
            this.endSegment = endSegment;
            this.endFigure = endFigure;
            this.lengthToEndSegment = lengthToEndSegment;
        }

        public bool Equals(PointDescriptionFloat other) => 
            ((((this.point == other.point) && (this.unitTangentVector == other.unitTangentVector)) && ((this.endSegment == other.endSegment) && (this.endFigure == other.endFigure))) && (this.lengthToEndSegment == other.lengthToEndSegment));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<PointDescriptionFloat, object>(this, obj);

        public static bool operator ==(PointDescriptionFloat a, PointDescriptionFloat b) => 
            a.Equals(b);

        public static bool operator !=(PointDescriptionFloat a, PointDescriptionFloat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point.GetHashCode(), this.unitTangentVector.GetHashCode(), this.endSegment, this.endFigure, this.lengthToEndSegment.GetHashCode());
    }
}

