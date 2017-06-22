namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TextMetrics : IEquatable<TextMetrics>
    {
        private float left;
        private float top;
        private float width;
        private float widthIncludingTrailingWhitespace;
        private float height;
        private float layoutWidth;
        private float layoutHeight;
        private int maxBidiReorderingDepth;
        public float Left =>
            this.left;
        public float Top =>
            this.top;
        public float Width =>
            this.width;
        public float WidthIncludingTrailingWhitespace =>
            this.widthIncludingTrailingWhitespace;
        public float WidthMax =>
            Math.Max(this.Width, this.WidthIncludingTrailingWhitespace);
        public float Height =>
            this.height;
        public float LayoutWidth =>
            this.layoutWidth;
        public float LayoutHeight =>
            this.layoutHeight;
        public int MaxBidiReorderingDepth =>
            this.maxBidiReorderingDepth;
        public TextMetrics(float left, float top, float width, float widthIncludingTrailingWhitespace, float height, float layoutWidth, float layoutHeight, int maxBidiReorderingDepth)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.widthIncludingTrailingWhitespace = widthIncludingTrailingWhitespace;
            this.height = height;
            this.layoutWidth = layoutWidth;
            this.layoutHeight = layoutHeight;
            this.maxBidiReorderingDepth = maxBidiReorderingDepth;
        }

        public bool Equals(TextMetrics other) => 
            (((((this.left == other.left) && (this.top == other.top)) && ((this.width == other.Width) && (this.widthIncludingTrailingWhitespace == other.widthIncludingTrailingWhitespace))) && (((this.height == other.height) && (this.layoutWidth == other.layoutWidth)) && (this.layoutHeight == other.layoutHeight))) && (this.maxBidiReorderingDepth == other.maxBidiReorderingDepth));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<TextMetrics, object>(this, obj);

        public static bool operator ==(TextMetrics a, TextMetrics b) => 
            a.Equals(b);

        public static bool operator !=(TextMetrics a, TextMetrics b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.left.GetHashCode(), this.top.GetHashCode(), this.width.GetHashCode(), this.widthIncludingTrailingWhitespace.GetHashCode(), this.height.GetHashCode(), this.layoutWidth.GetHashCode(), this.layoutHeight.GetHashCode());
    }
}

