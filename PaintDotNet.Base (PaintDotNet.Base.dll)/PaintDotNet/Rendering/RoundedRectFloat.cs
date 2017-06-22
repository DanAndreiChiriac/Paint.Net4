namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RoundedRectFloat : IEquatable<RoundedRectFloat>
    {
        private RectFloat rect;
        private float radiusX;
        private float radiusY;
        public RectFloat Rect
        {
            get => 
                this.rect;
            set
            {
                this.rect = value;
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
        public static explicit operator RoundedRectFloat(RoundedRectDouble roundedRect) => 
            new RoundedRectFloat((RectFloat) roundedRect.Rect, (float) roundedRect.RadiusX, (float) roundedRect.RadiusY);

        public RoundedRectFloat(RectFloat rect, float radius) : this(rect, radius, radius)
        {
        }

        public RoundedRectFloat(RectFloat rect, float radiusX, float radiusY)
        {
            this.rect = rect;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public RoundedRectFloat(float x, float y, float width, float height, float radius) : this(x, y, width, height, radius, radius)
        {
        }

        public RoundedRectFloat(float x, float y, float width, float height, float radiusX, float radiusY)
        {
            this.rect = new RectFloat(x, y, width, height);
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public bool Equals(RoundedRectFloat other) => 
            (((this.rect == other.rect) && (this.radiusX == other.radiusX)) && (this.radiusY == other.radiusY));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<RoundedRectFloat, object>(this, obj);

        public static bool operator ==(RoundedRectFloat a, RoundedRectFloat b) => 
            a.Equals(b);

        public static bool operator !=(RoundedRectFloat a, RoundedRectFloat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.rect.GetHashCode(), this.radiusX.GetHashCode(), this.radiusY.GetHashCode());
    }
}

