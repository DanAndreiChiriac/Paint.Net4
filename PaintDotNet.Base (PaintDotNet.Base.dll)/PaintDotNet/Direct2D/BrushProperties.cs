namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct BrushProperties : IEquatable<BrushProperties>
    {
        private float opacity;
        private Matrix3x2Float transform;
        public float Opacity
        {
            get => 
                this.opacity;
            set
            {
                this.opacity = value;
            }
        }
        public Matrix3x2Float Transform
        {
            get => 
                this.transform;
            set
            {
                this.transform = value;
            }
        }
        public BrushProperties(float opacity) : this(opacity, Matrix3x2Float.Identity)
        {
        }

        public BrushProperties(float opacity, Matrix3x2Float transform)
        {
            this.opacity = opacity;
            this.transform = transform;
        }

        public bool Equals(BrushProperties other) => 
            ((this.opacity == other.opacity) && (this.transform == other.transform));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<BrushProperties, object>(this, obj);

        public static bool operator ==(BrushProperties a, BrushProperties b) => 
            a.Equals(b);

        public static bool operator !=(BrushProperties a, BrushProperties b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.opacity.GetHashCode(), this.transform.GetHashCode());
    }
}

