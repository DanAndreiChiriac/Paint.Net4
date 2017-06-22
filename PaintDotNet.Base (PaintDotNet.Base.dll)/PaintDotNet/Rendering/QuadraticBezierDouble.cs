namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QuadraticBezierDouble : IEquatable<QuadraticBezierDouble>
    {
        private PointDouble point1;
        private PointDouble point2;
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
        public QuadraticBezierDouble(PointDouble point1, PointDouble point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public bool Equals(QuadraticBezierDouble other) => 
            ((this.point1 == other.point1) && (this.point2 == other.point2));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<QuadraticBezierDouble, object>(this, obj);

        public static bool operator ==(QuadraticBezierDouble a, QuadraticBezierDouble b) => 
            a.Equals(b);

        public static bool operator !=(QuadraticBezierDouble a, QuadraticBezierDouble b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point1.GetHashCode(), this.point2.GetHashCode());
    }
}

