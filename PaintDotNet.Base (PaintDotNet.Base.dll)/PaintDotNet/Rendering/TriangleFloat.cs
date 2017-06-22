namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TriangleFloat : IEquatable<TriangleFloat>
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
        public TriangleFloat(PointFloat point1, PointFloat point2, PointFloat point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }

        public bool Equals(TriangleFloat other) => 
            (((this.point1 == other.point1) && (this.point2 == other.point2)) && (this.point3 == other.point3));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<TriangleFloat, object>(this, obj);

        public static bool operator ==(TriangleFloat a, TriangleFloat b) => 
            a.Equals(b);

        public static bool operator !=(TriangleFloat a, TriangleFloat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point1.GetHashCode(), this.point2.GetHashCode(), this.point3.GetHashCode());
    }
}

