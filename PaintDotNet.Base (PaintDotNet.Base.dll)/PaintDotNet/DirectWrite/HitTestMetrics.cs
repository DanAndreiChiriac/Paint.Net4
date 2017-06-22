namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct HitTestMetrics : IEquatable<HitTestMetrics>
    {
        private int textPosition;
        private int length;
        private float left;
        private float top;
        private float width;
        private float height;
        private int bidiLevel;
        private int isText;
        private int isTrimmed;
        public int TextPosition =>
            this.textPosition;
        public int Length =>
            this.length;
        public float Left =>
            this.left;
        public float Top =>
            this.top;
        public float Width =>
            this.width;
        public float Height =>
            this.height;
        public int BidiLevel =>
            this.bidiLevel;
        public RectFloat Rect =>
            new RectFloat(this.left, this.top, this.width, this.height);
        public bool IsText =>
            (this.isText > 0);
        public bool IsTrimmed =>
            (this.isTrimmed > 0);
        public HitTestMetrics(int textPosition, int length, float left, float top, float width, float height, int bidiLevel, bool isText, bool isTrimmed)
        {
            this.textPosition = textPosition;
            this.length = length;
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
            this.bidiLevel = bidiLevel;
            this.isText = isText ? 1 : 0;
            this.isTrimmed = isTrimmed ? 1 : 0;
        }

        public bool Equals(HitTestMetrics other) => 
            (((((this.textPosition == other.textPosition) && (this.length == other.length)) && ((this.left == other.left) && (this.top == other.top))) && (((this.width == other.width) && (this.height == other.height)) && ((this.bidiLevel == other.bidiLevel) && (this.isText == other.isText)))) && (this.isTrimmed == other.isTrimmed));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<HitTestMetrics, object>(this, obj);

        public static bool operator ==(HitTestMetrics a, HitTestMetrics b) => 
            a.Equals(b);

        public static bool operator !=(HitTestMetrics a, HitTestMetrics b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.textPosition.GetHashCode(), this.length.GetHashCode(), this.left.GetHashCode(), this.top.GetHashCode(), this.width.GetHashCode(), this.height.GetHashCode(), this.bidiLevel.GetHashCode(), this.isText.GetHashCode(), this.isTrimmed.GetHashCode());
    }
}

