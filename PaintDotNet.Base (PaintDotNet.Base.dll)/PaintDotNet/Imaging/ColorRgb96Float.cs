namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct ColorRgb96Float : IEquatable<ColorRgb96Float>
    {
        internal float r;
        internal float g;
        internal float b;
        public float R
        {
            get => 
                this.r;
            set
            {
                this.r = value;
            }
        }
        public float G
        {
            get => 
                this.g;
            set
            {
                this.g = value;
            }
        }
        public float B
        {
            get => 
                this.b;
            set
            {
                this.b = value;
            }
        }
        public ColorRgb96Float(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public bool Equals(ColorRgb96Float other) => 
            (((this.r == other.r) && (this.g == other.g)) && (this.b == other.b));

        public override bool Equals(object obj) => 
            (((obj != null) && (obj is ColorRgb96Float)) && this.Equals((ColorRgb96Float) obj));

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.r.GetHashCode(), this.g.GetHashCode(), this.b.GetHashCode());

        public static bool operator ==(ColorRgb96Float lhs, ColorRgb96Float rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(ColorRgb96Float lhs, ColorRgb96Float rhs) => 
            !lhs.Equals(rhs);
    }
}

