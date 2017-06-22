namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TextRange : IEquatable<TextRange>
    {
        private int startPosition;
        private int length;
        public static TextRange All =>
            new TextRange(0, -1);
        public int StartPosition
        {
            get => 
                this.startPosition;
            set
            {
                this.startPosition = value;
            }
        }
        public int Length
        {
            get => 
                this.length;
            set
            {
                this.length = value;
            }
        }
        public TextRange(int startPosition, int length)
        {
            this.startPosition = startPosition;
            this.length = length;
        }

        public bool Equals(TextRange other) => 
            ((this.startPosition == other.startPosition) && (this.length == other.length));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<TextRange, object>(this, obj);

        public static bool operator ==(TextRange a, TextRange b) => 
            a.Equals(b);

        public static bool operator !=(TextRange a, TextRange b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.startPosition.GetHashCode(), this.length.GetHashCode());
    }
}

