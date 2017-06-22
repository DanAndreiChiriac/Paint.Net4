namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RadialGradientBrushProperties : IEquatable<RadialGradientBrushProperties>
    {
        private PointFloat center;
        private PointFloat gradientOriginOffset;
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
        public PointFloat GradientOriginOffset
        {
            get => 
                this.gradientOriginOffset;
            set
            {
                this.gradientOriginOffset = value;
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
        public RadialGradientBrushProperties(PointFloat center, PointFloat gradientOriginOffset, float radiusX, float radiusY)
        {
            this.center = center;
            this.gradientOriginOffset = gradientOriginOffset;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        public bool Equals(RadialGradientBrushProperties other) => 
            ((((this.center == other.center) && (this.gradientOriginOffset == other.gradientOriginOffset)) && (this.radiusX == other.radiusX)) && (this.radiusY == other.radiusY));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<RadialGradientBrushProperties, object>(this, obj);

        public static bool operator ==(RadialGradientBrushProperties a, RadialGradientBrushProperties b) => 
            a.Equals(b);

        public static bool operator !=(RadialGradientBrushProperties a, RadialGradientBrushProperties b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.center.GetHashCode(), this.gradientOriginOffset.GetHashCode(), this.radiusX.GetHashCode(), this.radiusY.GetHashCode());
    }
}

