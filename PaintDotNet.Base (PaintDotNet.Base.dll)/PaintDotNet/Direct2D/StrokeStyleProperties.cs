namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct StrokeStyleProperties : IEquatable<StrokeStyleProperties>
    {
        public const CapStyle DefaultStartCap = CapStyle.Flat;
        public const CapStyle DefaultEndCap = CapStyle.Flat;
        public const CapStyle DefaultDashCap = CapStyle.Flat;
        public const PaintDotNet.Direct2D.LineJoin DefaultLineJoin = PaintDotNet.Direct2D.LineJoin.Miter;
        public const float DefaultMiterLimit = 10f;
        public const PaintDotNet.Direct2D.DashStyle DefaultDashStyle = PaintDotNet.Direct2D.DashStyle.Solid;
        public const float DefaultDashOffset = 0f;
        private CapStyle startCap;
        private CapStyle endCap;
        private CapStyle dashCap;
        private PaintDotNet.Direct2D.LineJoin lineJoin;
        private float miterLimit;
        private PaintDotNet.Direct2D.DashStyle dashStyle;
        private float dashOffset;
        public static StrokeStyleProperties Default =>
            new StrokeStyleProperties(CapStyle.Flat, CapStyle.Flat, CapStyle.Flat, PaintDotNet.Direct2D.LineJoin.Miter, 10f, PaintDotNet.Direct2D.DashStyle.Solid, 0f);
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
        public StrokeStyleProperties(CapStyle startCap, CapStyle endCap, CapStyle dashCap, PaintDotNet.Direct2D.LineJoin lineJoin, float miterLimit, PaintDotNet.Direct2D.DashStyle dashStyle, float dashOffset)
        {
            this.startCap = startCap;
            this.endCap = endCap;
            this.dashCap = dashCap;
            this.lineJoin = lineJoin;
            this.miterLimit = miterLimit;
            this.dashStyle = dashStyle;
            this.dashOffset = dashOffset;
        }

        public bool Equals(StrokeStyleProperties other) => 
            (((((this.startCap == other.startCap) && (this.endCap == other.endCap)) && ((this.dashCap == other.dashCap) && (this.lineJoin == other.lineJoin))) && ((this.miterLimit == other.miterLimit) && (this.dashStyle == other.dashStyle))) && (this.dashOffset == other.dashOffset));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<StrokeStyleProperties, object>(this, obj);

        public static bool operator ==(StrokeStyleProperties a, StrokeStyleProperties b) => 
            a.Equals(b);

        public static bool operator !=(StrokeStyleProperties a, StrokeStyleProperties b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.startCap, (int) this.endCap, (int) this.dashCap, (int) this.lineJoin, this.miterLimit.GetHashCode(), (int) this.dashStyle, this.dashOffset.GetHashCode());
    }
}

