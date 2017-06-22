namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ArcDouble : IEquatable<ArcDouble>
    {
        private PointDouble point;
        private SizeDouble size;
        private double rotationAngle;
        private PaintDotNet.Rendering.SweepDirection sweepDirection;
        private PaintDotNet.Rendering.ArcSize arcSize;
        public PointDouble Point
        {
            get => 
                this.point;
            set
            {
                this.point = value;
            }
        }
        public SizeDouble Size
        {
            get => 
                this.size;
            set
            {
                this.size = value;
            }
        }
        public double RotationAngle
        {
            get => 
                this.rotationAngle;
            set
            {
                this.rotationAngle = value;
            }
        }
        public PaintDotNet.Rendering.SweepDirection SweepDirection
        {
            get => 
                this.sweepDirection;
            set
            {
                this.sweepDirection = value;
            }
        }
        public PaintDotNet.Rendering.ArcSize ArcSize
        {
            get => 
                this.arcSize;
            set
            {
                this.arcSize = value;
            }
        }
        public ArcDouble(PointDouble point, SizeDouble size, double rotationAngle, PaintDotNet.Rendering.SweepDirection sweepDirection, PaintDotNet.Rendering.ArcSize arcSize)
        {
            this.point = point;
            this.size = size;
            this.rotationAngle = rotationAngle;
            this.sweepDirection = sweepDirection;
            this.arcSize = arcSize;
        }

        public bool Equals(ArcDouble other) => 
            ((((this.point == other.point) && (this.size == other.size)) && ((this.rotationAngle == other.rotationAngle) && (this.sweepDirection == other.sweepDirection))) && (this.arcSize == other.arcSize));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ArcDouble, object>(this, obj);

        public static bool operator ==(ArcDouble a, ArcDouble b) => 
            a.Equals(b);

        public static bool operator !=(ArcDouble a, ArcDouble b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point.GetHashCode(), this.size.GetHashCode(), this.rotationAngle.GetHashCode(), (int) this.sweepDirection, (int) this.arcSize);
    }
}

