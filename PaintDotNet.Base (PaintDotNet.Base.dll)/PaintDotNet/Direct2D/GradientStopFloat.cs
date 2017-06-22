namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Imaging;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct GradientStopFloat : IEquatable<GradientStopFloat>
    {
        private float position;
        private ColorRgba128Float color;
        public float Position
        {
            get => 
                this.position;
            set
            {
                this.position = value;
            }
        }
        public ColorRgba128Float Color
        {
            get => 
                this.color;
            set
            {
                this.color = value;
            }
        }
        public GradientStopFloat(float position, ColorRgba128Float color)
        {
            this.position = position;
            this.color = color;
        }

        public bool Equals(GradientStopFloat other) => 
            ((this.position == other.position) && (this.color == other.color));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<GradientStopFloat, object>(this, obj);

        public static bool operator ==(GradientStopFloat a, GradientStopFloat b) => 
            a.Equals(b);

        public static bool operator !=(GradientStopFloat a, GradientStopFloat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.position.GetHashCode(), this.color.GetHashCode());
    }
}

