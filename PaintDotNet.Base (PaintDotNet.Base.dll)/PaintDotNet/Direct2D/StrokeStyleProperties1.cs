namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct StrokeStyleProperties1 : IEquatable<StrokeStyleProperties1>
    {
        public const CapStyle DefaultStartCap = CapStyle.Flat;
        public const CapStyle DefaultEndCap = CapStyle.Flat;
        public const CapStyle DefaultDashCap = CapStyle.Flat;
        public const PaintDotNet.Direct2D.LineJoin DefaultLineJoin = PaintDotNet.Direct2D.LineJoin.Miter;
        public const float DefaultMiterLimit = 10f;
        public const PaintDotNet.Direct2D.DashStyle DefaultDashStyle = PaintDotNet.Direct2D.DashStyle.Solid;
        public const float DefaultDashOffset = 0f;
        public const StrokeTransformType DefaultTransformType = StrokeTransformType.Normal;
        private CapStyle startCap;
        private CapStyle endCap;
        private CapStyle dashCap;
        private PaintDotNet.Direct2D.LineJoin lineJoin;
        private float miterLimit;
        private PaintDotNet.Direct2D.DashStyle dashStyle;
        private float dashOffset;
        private StrokeTransformType transformType;
        public static StrokeStyleProperties1 Default =>
            new StrokeStyleProperties1(CapStyle.Flat, CapStyle.Flat, CapStyle.Flat, PaintDotNet.Direct2D.LineJoin.Miter, 10f, PaintDotNet.Direct2D.DashStyle.Solid, 0f, StrokeTransformType.Normal);
        public CapStyle StartCap
        {
            get => 
                this.startCap;
            set
            {
                this.startCap = value;
            }
        }
        public CapStyle EndCap
        {
            get => 
                this.endCap;
            set
            {
                this.endCap = value;
            }
        }
        public CapStyle DashCap
        {
            get => 
                this.dashCap;
            set
            {
                this.dashCap = value;
            }
        }
        public PaintDotNet.Direct2D.LineJoin LineJoin
        {
            get => 
                this.lineJoin;
            set
            {
                this.lineJoin = value;
            }
        }
        public float MiterLimit
        {
            get => 
                this.miterLimit;
            set
            {
                this.miterLimit = value;
            }
        }
        public PaintDotNet.Direct2D.DashStyle DashStyle
        {
            get => 
                this.dashStyle;
            set
            {
                this.dashStyle = value;
            }
        }
        public float DashOffset
        {
            get => 
                this.dashOffset;
            set
            {
                this.dashOffset = value;
            }
        }
        public StrokeTransformType TransformType
        {
            get => 
                this.transformType;
            set
            {
                this.transformType = value;
            }
        }
        public PaintDotNet.Direct2D.StrokeStyleProperties StrokeStyleProperties
        {
            get
            {
                fixed (StrokeStyleProperties1* propertiesRef = ((StrokeStyleProperties1*) this))
                {
                    return (PaintDotNet.Direct2D.StrokeStyleProperties) propertiesRef;
                }
            }
            set
            {
                fixed (StrokeStyleProperties1* propertiesRef = ((StrokeStyleProperties1*) this))
                {
                    propertiesRef = (StrokeStyleProperties1*) value;
                }
            }
        }
        public StrokeStyleProperties1(CapStyle startCap, CapStyle endCap, CapStyle dashCap, PaintDotNet.Direct2D.LineJoin lineJoin, float miterLimit, PaintDotNet.Direct2D.DashStyle dashStyle, float dashOffset, StrokeTransformType transformType)
        {
            this.startCap = startCap;
            this.endCap = endCap;
            this.dashCap = dashCap;
            this.lineJoin = lineJoin;
            this.miterLimit = miterLimit;
            this.dashStyle = dashStyle;
            this.dashOffset = dashOffset;
            this.transformType = transformType;
        }

        public StrokeStyleProperties1(PaintDotNet.Direct2D.StrokeStyleProperties strokeStyleProperties, StrokeTransformType transformType) : this(strokeStyleProperties.StartCap, strokeStyleProperties.EndCap, strokeStyleProperties.DashCap, strokeStyleProperties.LineJoin, strokeStyleProperties.MiterLimit, strokeStyleProperties.DashStyle, strokeStyleProperties.DashOffset, transformType)
        {
        }

        public bool Equals(StrokeStyleProperties1 other) => 
            (((((this.startCap == other.startCap) && (this.endCap == other.endCap)) && ((this.dashCap == other.dashCap) && (this.lineJoin == other.lineJoin))) && (((this.miterLimit == other.miterLimit) && (this.dashStyle == other.dashStyle)) && (this.dashOffset == other.dashOffset))) && (this.transformType == other.transformType));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<StrokeStyleProperties1, object>(this, obj);

        public static bool operator ==(StrokeStyleProperties1 a, StrokeStyleProperties1 b) => 
            a.Equals(b);

        public static bool operator !=(StrokeStyleProperties1 a, StrokeStyleProperties1 b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.startCap, (int) this.endCap, (int) this.dashCap, (int) this.lineJoin, this.miterLimit.GetHashCode(), (int) this.dashStyle, this.dashOffset.GetHashCode(), (int) this.transformType);
    }
}

