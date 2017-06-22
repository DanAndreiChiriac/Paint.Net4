namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct QuadraticBezierFloat : IEquatable<QuadraticBezierFloat>
    {
        private PointFloat point1;
        private PointFloat point2;
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
        public QuadraticBezierFloat(PointFloat point1, PointFloat point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public bool Equals(QuadraticBezierFloat other) => 
            ((this.point1 == other.point1) && (this.point2 == other.point2));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<QuadraticBezierFloat, object>(this, obj);

        public static bool operator ==(QuadraticBezierFloat a, QuadraticBezierFloat b) => 
            a.Equals(b);

        public static bool operator !=(QuadraticBezierFloat a, QuadraticBezierFloat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point1.GetHashCode(), this.point2.GetHashCode());
    }
}

