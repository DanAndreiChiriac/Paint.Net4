namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct EllipseDouble : IEquatable<EllipseDouble>
    {
        private PointDouble center;
        private double radiusX;
        private double radiusY;
        public PointDouble Center
        {
            get => 
                this.center;
            set
            {
                this.center = value;
            }
        }
        public double RadiusX
        {
            get => 
                this.radiusX;
            set
            {
                this.radiusX = value;
            }
        }
        public double RadiusY
        {
            get => 
                this.radiusY;
            set
            {
                this.radiusY = value;
            }
        }
        public RectDouble Bounds =>
            RectDouble.FromCenter(this.center.X, this.center.Y, this.radiusX * 2.0, this.radiusY * 2.0);
        public static EllipseDouble FromRect(RectDouble rect)
        {
            double radiusX = rect.Width / 2.0;
            double radiusY = rect.Height / 2.0;
            return new EllipseDouble(rect.X + radiusX, rect.Y + radiusY, radiusX, radiusY);
        }

        public static implicit operator EllipseDouble(EllipseFloat ellipse) => 
            new EllipseDouble(ellipse.Center, (double) ellipse.RadiusX, (double) ellipse.RadiusY);

        public EllipseDouble(double x, double y, double radius) : this(x, y, radius, radius)
        {
        }

        public EllipseDouble(double x, double y, double radiusX, double radiusY)
        {
            this.center = new PointDouble(x, y);
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public EllipseDouble(PointDouble center, double radius) : this(center, radius, radius)
        {
        }

        public EllipseDouble(PointDouble center, double radiusX, double radiusY)
        {
            this.center = center;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public bool Equals(EllipseDouble other) => 
            (((this.center == other.center) && (this.radiusX == other.radiusX)) && (this.radiusY == other.radiusY));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<EllipseDouble, object>(this, obj);

        public static bool operator ==(EllipseDouble a, EllipseDouble b) => 
            a.Equals(b);

        public static bool operator !=(EllipseDouble a, EllipseDouble b) => 
            !a.Equals(b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.center.GetHashCode(), this.radiusX.GetHashCode(), this.radiusY.GetHashCode());
    }
}

