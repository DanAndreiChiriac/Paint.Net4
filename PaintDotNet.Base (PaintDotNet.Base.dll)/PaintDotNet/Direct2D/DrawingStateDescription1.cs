namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DrawingStateDescription1 : IEquatable<DrawingStateDescription1>
    {
        private PaintDotNet.Direct2D.AntialiasMode antialiasMode;
        private PaintDotNet.Direct2D.TextAntialiasMode textAntialiasMode;
        private Tag tag1;
        private Tag tag2;
        private Matrix3x2Float transform;
        private PaintDotNet.Direct2D.PrimitiveBlend primitiveBlend;
        private PaintDotNet.Direct2D.UnitMode unitMode;
        public PaintDotNet.Direct2D.AntialiasMode AntialiasMode
        {
            get => 
                this.antialiasMode;
            set
            {
                this.antialiasMode = value;
            }
        }
        public PaintDotNet.Direct2D.TextAntialiasMode TextAntialiasMode
        {
            get => 
                this.textAntialiasMode;
            set
            {
                this.textAntialiasMode = value;
            }
        }
        public Tag Tag1
        {
            get => 
                this.tag1;
            set
            {
                this.tag1 = value;
            }
        }
        public Tag Tag2
        {
            get => 
                this.tag2;
            set
            {
                this.tag2 = value;
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
        public PaintDotNet.Direct2D.PrimitiveBlend PrimitiveBlend
        {
            get => 
                this.primitiveBlend;
            set
            {
                this.primitiveBlend = value;
            }
        }
        public PaintDotNet.Direct2D.UnitMode UnitMode
        {
            get => 
                this.unitMode;
            set
            {
                this.unitMode = value;
            }
        }
        public PaintDotNet.Direct2D.DrawingStateDescription DrawingStateDescription
        {
            get
            {
                fixed (DrawingStateDescription1* descriptionRef = ((DrawingStateDescription1*) this))
                {
                    return (PaintDotNet.Direct2D.DrawingStateDescription) descriptionRef;
                }
            }
            set
            {
                fixed (DrawingStateDescription1* descriptionRef = ((DrawingStateDescription1*) this))
                {
                    descriptionRef = (DrawingStateDescription1*) value;
                }
            }
        }
        public DrawingStateDescription1(PaintDotNet.Direct2D.AntialiasMode antialiasMode, PaintDotNet.Direct2D.TextAntialiasMode textAntialiasMode, Tag tag1, Tag tag2, Matrix3x2Float transform, PaintDotNet.Direct2D.PrimitiveBlend primitiveBlend, PaintDotNet.Direct2D.UnitMode unitMode)
        {
            this.antialiasMode = antialiasMode;
            this.textAntialiasMode = textAntialiasMode;
            this.tag1 = tag1;
            this.tag2 = tag2;
            this.transform = transform;
            this.primitiveBlend = primitiveBlend;
            this.unitMode = unitMode;
        }

        public DrawingStateDescription1(PaintDotNet.Direct2D.DrawingStateDescription drawingStateDescription, PaintDotNet.Direct2D.PrimitiveBlend primitiveBlend, PaintDotNet.Direct2D.UnitMode unitMode) : this(drawingStateDescription.AntialiasMode, drawingStateDescription.TextAntialiasMode, drawingStateDescription.Tag1, drawingStateDescription.Tag2, drawingStateDescription.Transform, primitiveBlend, unitMode)
        {
        }

        public bool Equals(DrawingStateDescription1 other) => 
            (((((this.antialiasMode == other.antialiasMode) && (this.textAntialiasMode == other.textAntialiasMode)) && ((this.tag1 == other.tag1) && (this.tag2 == other.tag2))) && ((this.transform == other.transform) && (this.primitiveBlend == other.primitiveBlend))) && (this.unitMode == other.unitMode));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<DrawingStateDescription1, object>(this, obj);

        public static bool operator ==(DrawingStateDescription1 a, DrawingStateDescription1 b) => 
            a.Equals(b);

        public static bool operator !=(DrawingStateDescription1 a, DrawingStateDescription1 b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.antialiasMode, (int) this.textAntialiasMode, this.tag1.GetHashCode(), this.tag2.GetHashCode(), this.transform.GetHashCode(), (int) this.primitiveBlend, (int) this.unitMode);
    }
}

