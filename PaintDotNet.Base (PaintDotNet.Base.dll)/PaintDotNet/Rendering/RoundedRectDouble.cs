namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RoundedRectDouble : IEquatable<RoundedRectDouble>
    {
        private RectDouble rect;
        private double radiusX;
        private double radiusY;
        public RectDouble Rect
        {
            get => 
                this.rect;
            set
            {
                this.rect = value;
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
        public static implicit operator RoundedRectDouble(RoundedRectFloat roundedRectF) => 
            new RoundedRectDouble(roundedRectF.Rect, (double) roundedRectF.RadiusX, (double) roundedRectF.RadiusY);

        public RoundedRectDouble(RectDouble rect, double radius) : this(rect, radius, radius)
        {
        }

        public RoundedRectDouble(RectDouble rect, double radiusX, double radiusY)
        {
            this.rect = rect;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public RoundedRectDouble(double x, double y, double width, double height, double radius) : this(x, y, width, height, radius, radius)
        {
        }

        public RoundedRectDouble(double x, double y, double width, double height, double radiusX, double radiusY)
        {
            this.rect = new RectDouble(x, y, width, height);
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public bool Equals(RoundedRectDouble other) => 
            (((this.rect == other.rect) && (this.radiusX == other.radiusX)) && (this.radiusY == other.radiusY));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<RoundedRectDouble, object>(this, obj);

        public static bool operator ==(RoundedRectDouble a, RoundedRectDouble b) => 
            a.Equals(b);

        public static bool operator !=(RoundedRectDouble a, RoundedRectDouble b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.rect.GetHashCode(), this.radiusX.GetHashCode(), this.radiusY.GetHashCode());
    }
}

