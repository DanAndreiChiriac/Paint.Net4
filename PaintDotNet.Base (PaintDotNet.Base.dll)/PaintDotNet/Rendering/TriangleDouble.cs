namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TriangleDouble : IEquatable<TriangleDouble>
    {
        private PointDouble point1;
        private PointDouble point2;
        private PointDouble point3;
        public PointDouble Point1
        {
            get => 
                this.point1;
            set
            {
                this.point1 = value;
            }
        }
        public PointDouble Point2
        {
            get => 
                this.point2;
            set
            {
                this.point2 = value;
            }
        }
        public PointDouble Point3
        {
            get => 
                this.point3;
            set
            {
                this.point3 = value;
            }
        }
        public TriangleDouble(PointDouble point1, PointDouble point2, PointDouble point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }

        public bool Equals(TriangleDouble other) => 
            (((this.point1 == other.point1) && (this.point2 == other.point2)) && (this.point3 == other.point3));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<TriangleDouble, object>(this, obj);

        public static bool operator ==(TriangleDouble a, TriangleDouble b) => 
            a.Equals(b);

        public static bool operator !=(TriangleDouble a, TriangleDouble b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point1.GetHashCode(), this.point2.GetHashCode(), this.point3.GetHashCode());
    }
}

