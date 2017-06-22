namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ArcFloat : IEquatable<ArcFloat>
    {
        private PointFloat point;
        private SizeFloat size;
        private float rotationAngle;
        private PaintDotNet.Rendering.SweepDirection sweepDirection;
        private PaintDotNet.Rendering.ArcSize arcSize;
        public PointFloat Point
        {
            get => 
                this.point;
            set
            {
                this.point = value;
            }
        }
        public SizeFloat Size
        {
            get => 
                this.size;
            set
            {
                this.size = value;
            }
        }
        public float RotationAngle
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
        public ArcFloat(PointFloat point, SizeFloat size, float rotationAngle, PaintDotNet.Rendering.SweepDirection sweepDirection, PaintDotNet.Rendering.ArcSize arcSize)
        {
            this.point = point;
            this.size = size;
            this.rotationAngle = rotationAngle;
            this.sweepDirection = sweepDirection;
            this.arcSize = arcSize;
        }

        public bool Equals(ArcFloat other) => 
            ((((this.point == other.point) && (this.size == other.size)) && ((this.rotationAngle == other.rotationAngle) && (this.sweepDirection == other.sweepDirection))) && (this.arcSize == other.arcSize));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ArcFloat, object>(this, obj);

        public static bool operator ==(ArcFloat a, ArcFloat b) => 
            a.Equals(b);

        public static bool operator !=(ArcFloat a, ArcFloat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.point.GetHashCode(), this.size.GetHashCode(), this.rotationAngle.GetHashCode(), (int) this.sweepDirection, (int) this.arcSize);
    }
}

