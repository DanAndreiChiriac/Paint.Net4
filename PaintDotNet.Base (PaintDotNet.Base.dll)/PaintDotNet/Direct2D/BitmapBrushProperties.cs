namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Imaging;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct BitmapBrushProperties : IEquatable<BitmapBrushProperties>
    {
        private ExtendMode extendModeX;
        private ExtendMode extendModeY;
        private BitmapInterpolationMode interpolationMode;
        public ExtendMode ExtendModeX
        {
            get => 
                this.extendModeX;
            set
            {
                this.extendModeX = value;
            }
        }
        public ExtendMode ExtendModeY
        {
            get => 
                this.extendModeY;
            set
            {
                this.extendModeY = value;
            }
        }
        public BitmapInterpolationMode InterpolationMode
        {
            get => 
                this.interpolationMode;
            set
            {
                this.interpolationMode = value;
            }
        }
        public BitmapBrushProperties(ExtendMode extendModeX, ExtendMode extendModeY, BitmapInterpolationMode interpolationMode)
        {
            this.extendModeX = extendModeX;
            this.extendModeY = extendModeY;
            this.interpolationMode = interpolationMode;
        }

        public bool Equals(BitmapBrushProperties other) => 
            (((this.extendModeX == other.extendModeX) && (this.extendModeY == other.extendModeY)) && (this.interpolationMode == other.interpolationMode));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<BitmapBrushProperties, object>(this, obj);

        public static bool operator ==(BitmapBrushProperties a, BitmapBrushProperties b) => 
            a.Equals(b);

        public static bool operator !=(BitmapBrushProperties a, BitmapBrushProperties b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.extendModeX, (int) this.extendModeY, (int) this.interpolationMode);
    }
}

