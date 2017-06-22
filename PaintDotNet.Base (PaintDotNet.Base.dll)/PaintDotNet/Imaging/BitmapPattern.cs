namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct BitmapPattern : IEquatable<BitmapPattern>
    {
        private long position;
        private byte[] pattern;
        private ReadOnlyCollection<byte> patternRO;
        private byte[] mask;
        private ReadOnlyCollection<byte> maskRO;
        private bool endOfStream;
        public long Position =>
            this.position;
        public IList<byte> Pattern =>
            this.patternRO;
        public IList<byte> Mask =>
            this.mask;
        public bool EndOfStream =>
            this.endOfStream;
        public BitmapPattern(long position, IList<byte> pattern, IList<byte> mask, bool endOfStream)
        {
            Validate.Begin().IsNotNull<IList<byte>>(pattern, "pattern").IsNotNull<IList<byte>>(mask, "mask").Check().IsNotNegative(position, "position").Check();
            if (pattern.Count != mask.Count)
            {
                throw new ArgumentException("pattern.Count must equal mask.Count");
            }
            this.position = position;
            this.pattern = pattern.ToArrayEx<byte>();
            this.patternRO = new ReadOnlyCollection<byte>(this.pattern);
            this.mask = mask.ToArrayEx<byte>();
            this.maskRO = new ReadOnlyCollection<byte>(this.mask);
            this.endOfStream = endOfStream;
        }

        public bool Equals(BitmapPattern other) => 
            ((((this.position == other.position) && ArrayUtil.Equals(this.pattern, other.pattern)) && ArrayUtil.Equals(this.mask, other.mask)) && (this.endOfStream == other.endOfStream));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<BitmapPattern, object>(this, obj);

        public static bool operator ==(BitmapPattern a, BitmapPattern b) => 
            a.Equals(b);

        public static bool operator !=(BitmapPattern a, BitmapPattern b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.position.GetHashCode(), HashCodeUtil.CreateHashCode<byte>(this.pattern), HashCodeUtil.CreateHashCode<byte>(this.mask), this.endOfStream.GetHashCode());
    }
}

