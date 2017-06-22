namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ClusterMetrics : IEquatable<ClusterMetrics>
    {
        private const int canWrapLineAfterBit = 0;
        private const int isWhitespaceBit = 1;
        private const int isNewlineBit = 2;
        private const int isSoftHyphenBit = 3;
        private const int isRightToLeftBit = 4;
        private float width;
        private short length;
        private BitVector8 bits0;
        private BitVector8 bits1;
        public float Width
        {
            get => 
                this.width;
            private set
            {
                this.width = value;
            }
        }
        public short Length
        {
            get => 
                this.length;
            private set
            {
                this.length = value;
            }
        }
        public bool CanWrapLineAfter
        {
            get => 
                this.bits0.GetBool(0);
            private set
            {
                this.bits0.SetBool(0, value);
            }
        }
        public bool IsWhitespace
        {
            get => 
                this.bits0.GetBool(1);
            private set
            {
                this.bits0.SetBool(1, value);
            }
        }
        public bool IsNewline
        {
            get => 
                this.bits0.GetBool(2);
            private set
            {
                this.bits0.SetBool(2, value);
            }
        }
        public bool IsSoftHyphen
        {
            get => 
                this.bits0.GetBool(3);
            private set
            {
                this.bits0.SetBool(3, value);
            }
        }
        public bool IsRightToLeft
        {
            get => 
                this.bits0.GetBool(4);
            private set
            {
                this.bits0.SetBool(4, value);
            }
        }
        private BitVector8 Bits1 =>
            this.bits1;
        public ClusterMetrics(float width, short length, bool canWrapLineAfter, bool isWhitespace, bool isNewline, bool isSoftHyphen, bool isRightToLeft)
        {
            this.width = width;
            this.length = length;
            this.bits0 = new BitVector8();
            this.bits1 = new BitVector8();
            this.CanWrapLineAfter = canWrapLineAfter;
            this.IsWhitespace = isWhitespace;
            this.IsNewline = isNewline;
            this.IsSoftHyphen = isSoftHyphen;
            this.IsRightToLeft = isRightToLeft;
        }

        public bool Equals(ClusterMetrics other) => 
            ((((this.width == other.width) && (this.length == other.length)) && (this.bits0 == other.bits0)) && (this.bits1 == other.bits1));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ClusterMetrics, object>(this, obj);

        public static bool operator ==(ClusterMetrics a, ClusterMetrics b) => 
            a.Equals(b);

        public static bool operator !=(ClusterMetrics a, ClusterMetrics b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.width.GetHashCode(), this.length.GetHashCode(), this.bits0.GetHashCode(), this.bits1.GetHashCode());
    }
}

