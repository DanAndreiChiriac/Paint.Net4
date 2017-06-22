namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct BezierFloat : IEquatable<BezierFloat>
    {
        private PointFloat point1;
        private PointFloat point2;
        private PointFloat point3;
        public PointFloat Point1
        {
            get => 
                this.point1;
            set
            {
                this.point1 = value;
            }
        }
        public PointFloat Point2
        {
            get => 
                this.point2;
            set
            {
                this.point2 = value;
            }
        }
        public PointFloat Point3
        {
            get => 
                this.point3;
            set
            {
                this.point3 = value;
            }
        }
        public static explicit operator BezierFloat(BezierDouble bezier) => 
            new BezierFloat((PointFloat) bezier.Point1, (PointFloat) bezier.Point2, (PointFloat) bezier.Point3);

        public BezierFloat(PointFloat point1, PointFloat point2, PointFloat point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }

        public bool Equals(BezierFloat other) => 
            (((this.point1 == other.point1) && (this.point2 == other.point2)) && (this.point3 == other.point3));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<BezierFloat, object>(this, obj);

        public static bool operator ==(BezierFloat a, BezierFloat b) => 
            a.Equals(b);

        public static bool operator !=(BezierFloat a, BezierFloat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point1.GetHashCode(), this.point2.GetHashCode(), this.point3.GetHashCode());
    }
}

