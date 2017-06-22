namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct TextRangeProperty<T> : IEquatable<TextRangeProperty<T>>
    {
        private static readonly EqualityComparer<T> comparerT;
        private PaintDotNet.DirectWrite.TextRange textRange;
        private T value;
        public PaintDotNet.DirectWrite.TextRange TextRange =>
            this.textRange;
        public int StartPosition =>
            this.textRange.StartPosition;
        public int Length =>
            this.textRange.Length;
        public T Value =>
            this.value;
        public TextRangeProperty(PaintDotNet.DirectWrite.TextRange textRange, T value)
        {
            this.textRange = textRange;
            this.value = value;
        }

        public bool Equals(TextRangeProperty<T> other) => 
            ((this.textRange == other.textRange) && TextRangeProperty<T>.comparerT.Equals(this.value, other.value));

        public override unsafe bool Equals(object obj) => 
            EquatableUtil.Equals<TextRangeProperty<T>, object>(*((TextRangeProperty<T>*) this), obj);

        public static bool operator ==(TextRangeProperty<T> a, TextRangeProperty<T> b) => 
            a.Equals(b);

        public static bool operator !=(TextRangeProperty<T> a, TextRangeProperty<T> b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.textRange.GetHashCode(), this.value.GetHashCode());

        static TextRangeProperty()
        {
            TextRangeProperty<T>.comparerT = EqualityComparer<T>.Default;
        }
    }
}

