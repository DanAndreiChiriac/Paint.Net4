namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct BitmapProperties : IEquatable<BitmapProperties>
    {
        private Direct2DPixelFormat pixelFormat;
        private float dpiX;
        private float dpiY;
        public static float DefaultDpiX =>
            96f;
        public static float DefaultDpiY =>
            96f;
        public Direct2DPixelFormat PixelFormat
        {
            get => 
                this.pixelFormat;
            set
            {
                this.pixelFormat = value;
            }
        }
        public float DpiX
        {
            get => 
                this.dpiX;
            set
            {
                this.dpiX = value;
            }
        }
        public float DpiY
        {
            get => 
                this.dpiY;
            set
            {
                this.dpiY = value;
            }
        }
        public BitmapProperties(Direct2DPixelFormat pixelFormat, float dpiX, float dpiY)
        {
            this.pixelFormat = pixelFormat;
            this.dpiX = dpiX;
            this.dpiY = dpiY;
        }

        public bool Equals(BitmapProperties other) => 
            (((this.pixelFormat == other.pixelFormat) && (this.dpiX == other.dpiX)) && (this.dpiY == other.dpiY));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<BitmapProperties, object>(this, obj);

        public static bool operator ==(BitmapProperties a, BitmapProperties b) => 
            a.Equals(b);

        public static bool operator !=(BitmapProperties a, BitmapProperties b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.pixelFormat.GetHashCode(), this.dpiX.GetHashCode(), this.dpiY.GetHashCode());
    }
}

