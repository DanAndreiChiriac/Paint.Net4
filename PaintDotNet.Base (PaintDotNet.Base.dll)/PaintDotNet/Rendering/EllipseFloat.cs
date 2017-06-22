namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct EllipseFloat : IEquatable<EllipseFloat>
    {
        private PointFloat center;
        private float radiusX;
        private float radiusY;
        public PointFloat Center
        {
            get => 
                this.center;
            set
            {
                this.center = value;
            }
        }
        public float RadiusX
        {
            get => 
                this.radiusX;
            set
            {
                this.radiusX = value;
            }
        }
        public float RadiusY
        {
            get => 
                this.radiusY;
            set
            {
                this.radiusY = value;
            }
        }
        public RectFloat Bounds =>
            RectFloat.FromCenter(this.center.X, this.center.Y, this.radiusX * 2f, this.radiusY * 2f);
        public static EllipseFloat FromRect(RectFloat rect)
        {
            float radiusX = rect.Width / 2f;
            float radiusY = rect.Height / 2f;
            return new EllipseFloat(rect.X + radiusX, rect.Y + radiusY, radiusX, radiusY);
        }

        public static explicit operator EllipseFloat(EllipseDouble ellipse) => 
            new EllipseFloat((PointFloat) ellipse.Center, (float) ellipse.RadiusX, (float) ellipse.RadiusY);

        public EllipseFloat(float x, float y, float radius) : this(x, y, radius, radius)
        {
        }

        public EllipseFloat(float x, float y, float radiusX, float radiusY)
        {
            this.center = new PointFloat(x, y);
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public EllipseFloat(PointFloat center, float radius) : this(center, radius, radius)
        {
        }

        public EllipseFloat(PointFloat center, float radiusX, float radiusY)
        {
            this.center = center;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public bool Equals(EllipseFloat other) => 
            (((this.center == other.center) && (this.radiusX == other.radiusX)) && (this.radiusY == other.radiusY));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<EllipseFloat, object>(this, obj);

        public static bool operator ==(EllipseFloat a, EllipseFloat b) => 
            a.Equals(b);

        public static bool operator !=(EllipseFloat a, EllipseFloat b) => 
            !a.Equals(b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.center.GetHashCode(), this.radiusX.GetHashCode(), this.radiusY.GetHashCode());
    }
}

