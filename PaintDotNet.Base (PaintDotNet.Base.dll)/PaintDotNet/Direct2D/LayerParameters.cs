namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LayerParameters : IEquatable<LayerParameters>
    {
        private RectFloat contentBounds;
        private IGeometry geometricMask;
        private AntialiasMode maskAntialiasMode;
        private Matrix3x2Float maskTransform;
        private float opacity;
        private IBrush opacityBrush;
        private PaintDotNet.Direct2D.LayerOptions layerOptions;
        public static LayerParameters CreateDefault() => 
            new LayerParameters { 
                ContentBounds = RectFloat.Infinite,
                GeometricMask = null,
                MaskAntialiasMode = AntialiasMode.PerPrimitive,
                MaskTransform = Matrix3x2Float.Identity,
                Opacity = 1f,
                OpacityBrush = null,
                LayerOptions = PaintDotNet.Direct2D.LayerOptions.None
            };

        public RectFloat ContentBounds
        {
            get => 
                this.contentBounds;
            set
            {
                this.contentBounds = value;
            }
        }
        public IGeometry GeometricMask
        {
            get => 
                this.geometricMask;
            set
            {
                this.geometricMask = value;
            }
        }
        public AntialiasMode MaskAntialiasMode
        {
            get => 
                this.maskAntialiasMode;
            set
            {
                this.maskAntialiasMode = value;
            }
        }
        public Matrix3x2Float MaskTransform
        {
            get => 
                this.maskTransform;
            set
            {
                this.maskTransform = value;
            }
        }
        public float Opacity
        {
            get => 
                this.opacity;
            set
            {
                this.opacity = value;
            }
        }
        public IBrush OpacityBrush
        {
            get => 
                this.opacityBrush;
            set
            {
                this.opacityBrush = value;
            }
        }
        public PaintDotNet.Direct2D.LayerOptions LayerOptions
        {
            get => 
                this.layerOptions;
            set
            {
                this.layerOptions = value;
            }
        }
        public LayerParameters(RectFloat? contentBounds, IGeometry geometricMask, AntialiasMode maskAntialiasMode, Matrix3x2Float? maskTransform, float opacity, IBrush opacityBrush, PaintDotNet.Direct2D.LayerOptions layerOptions)
        {
            RectFloat? nullable = contentBounds;
            this.contentBounds = nullable.HasValue ? nullable.GetValueOrDefault() : RectFloat.Infinite;
            this.geometricMask = geometricMask;
            this.maskAntialiasMode = maskAntialiasMode;
            Matrix3x2Float? nullable2 = maskTransform;
            this.maskTransform = nullable2.HasValue ? nullable2.GetValueOrDefault() : Matrix3x2Float.Identity;
            this.opacity = opacity;
            this.opacityBrush = opacityBrush;
            this.layerOptions = layerOptions;
        }

        public bool Equals(LayerParameters other) => 
            (((((this.contentBounds == other.contentBounds) && (this.geometricMask == other.geometricMask)) && ((this.maskAntialiasMode == other.maskAntialiasMode) && (this.maskTransform == other.maskTransform))) && ((this.opacity == other.opacity) && (this.opacityBrush == other.opacityBrush))) && (this.layerOptions == other.layerOptions));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<LayerParameters, object>(this, obj);

        public static bool operator ==(LayerParameters a, LayerParameters b) => 
            a.Equals(b);

        public static bool operator !=(LayerParameters a, LayerParameters b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.contentBounds.GetHashCode(), this.geometricMask.GetHashCode(), (int) this.maskAntialiasMode, this.maskTransform.GetHashCode(), this.opacity.GetHashCode(), this.opacityBrush.GetHashCode(), (int) this.layerOptions);
    }
}

