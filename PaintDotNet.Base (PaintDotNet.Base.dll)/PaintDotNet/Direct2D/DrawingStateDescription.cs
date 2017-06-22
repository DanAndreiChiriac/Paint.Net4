namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct DrawingStateDescription : IEquatable<DrawingStateDescription>
    {
        private PaintDotNet.Direct2D.AntialiasMode antialiasMode;
        private PaintDotNet.Direct2D.TextAntialiasMode textAntialiasMode;
        private Tag tag1;
        private Tag tag2;
        private Matrix3x2Float transform;
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
        public DrawingStateDescription(PaintDotNet.Direct2D.AntialiasMode antialiasMode, PaintDotNet.Direct2D.TextAntialiasMode textAntialiasMode, Tag tag1, Tag tag2, Matrix3x2Float transform)
        {
            this.antialiasMode = antialiasMode;
            this.textAntialiasMode = textAntialiasMode;
            this.tag1 = tag1;
            this.tag2 = tag2;
            this.transform = transform;
        }

        public bool Equals(DrawingStateDescription other) => 
            ((((this.antialiasMode == other.antialiasMode) && (this.textAntialiasMode == other.textAntialiasMode)) && ((this.tag1 == other.tag1) && (this.tag2 == other.tag2))) && (this.transform == other.transform));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<DrawingStateDescription, object>(this, obj);

        public static bool operator ==(DrawingStateDescription a, DrawingStateDescription b) => 
            a.Equals(b);

        public static bool operator !=(DrawingStateDescription a, DrawingStateDescription b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.antialiasMode, (int) this.textAntialiasMode, this.tag1.GetHashCode(), this.tag2.GetHashCode(), this.transform.GetHashCode());
    }
}

