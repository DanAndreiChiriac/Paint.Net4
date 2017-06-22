namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LinearGradientBrushProperties : IEquatable<LinearGradientBrushProperties>
    {
        private PointFloat startPoint;
        private PointFloat endPoint;
        public PointFloat StartPoint
        {
            get => 
                this.startPoint;
            set
            {
                this.startPoint = value;
            }
        }
        public PointFloat EndPoint
        {
            get => 
                this.endPoint;
            set
            {
                this.endPoint = value;
            }
        }
        public LinearGradientBrushProperties(PointFloat startPoint, PointFloat endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public bool Equals(LinearGradientBrushProperties other) => 
            ((this.startPoint == other.startPoint) && (this.endPoint == other.endPoint));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<LinearGradientBrushProperties, object>(this, obj);

        public static bool operator ==(LinearGradientBrushProperties a, LinearGradientBrushProperties b) => 
            a.Equals(b);

        public static bool operator !=(LinearGradientBrushProperties a, LinearGradientBrushProperties b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.startPoint.GetHashCode(), this.endPoint.GetHashCode());
    }
}

