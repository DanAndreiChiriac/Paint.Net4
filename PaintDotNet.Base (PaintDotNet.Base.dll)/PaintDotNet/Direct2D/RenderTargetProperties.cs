namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RenderTargetProperties : IEquatable<RenderTargetProperties>
    {
        private RenderTargetType type;
        private Direct2DPixelFormat pixelFormat;
        private float dpiX;
        private float dpiY;
        private RenderTargetUsage usage;
        private FeatureLevel minLevel;
        public RenderTargetType Type
        {
            get => 
                this.type;
            set
            {
                this.type = value;
            }
        }
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
        public RenderTargetUsage Usage
        {
            get => 
                this.usage;
            set
            {
                this.usage = value;
            }
        }
        public FeatureLevel MinLevel
        {
            get => 
                this.minLevel;
            set
            {
                this.minLevel = value;
            }
        }
        public RenderTargetProperties(RenderTargetType type, Direct2DPixelFormat pixelFormat, float dpiX, float dpiY, RenderTargetUsage usage, FeatureLevel minLevel)
        {
            this.type = type;
            this.pixelFormat = pixelFormat;
            this.dpiX = dpiX;
            this.dpiY = dpiY;
            this.usage = usage;
            this.minLevel = minLevel;
        }

        public bool Equals(RenderTargetProperties other) => 
            (((((this.type == other.type) && (this.pixelFormat == other.pixelFormat)) && ((this.dpiX == other.dpiX) && (this.dpiY == other.dpiY))) && (this.usage == other.usage)) && (this.minLevel == other.minLevel));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<RenderTargetProperties, object>(this, obj);

        public static bool operator ==(RenderTargetProperties a, RenderTargetProperties b) => 
            a.Equals(b);

        public static bool operator !=(RenderTargetProperties a, RenderTargetProperties b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.type, this.pixelFormat.GetHashCode(), this.dpiX.GetHashCode(), this.dpiY.GetHashCode(), (int) this.usage, (int) this.minLevel);
    }
}

