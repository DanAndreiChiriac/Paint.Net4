namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using PaintDotNet.Markup;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Markup;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<PointInt32>)), ValueSerializer(typeof(StringBasedValueSerializer<PointInt32>)), DebuggerDisplay("{X},{Y}")]
    public struct PointInt32 : IEquatable<PointInt32>, IFormattable, IParseString<PointInt32>
    {
        private static readonly object boxedZero;
        internal int x;
        internal int y;
        public static object BoxedZero =>
            (boxedZero ?? new PointInt32());
        public static PointInt32 Zero =>
            new PointInt32(0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointInt32(SizeInt32 size) => 
            new PointInt32(size.width, size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointInt32(VectorInt32 vec) => 
            new PointInt32(vec.x, vec.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 operator +(PointInt32 lhs, VectorInt32 rhs) => 
            new PointInt32(lhs.x + rhs.x, lhs.y + rhs.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 operator -(PointInt32 pt) => 
            new PointInt32(-pt.x, -pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VectorInt32 operator -(PointInt32 lhs, PointInt32 rhs) => 
            new VectorInt32(lhs.x - rhs.x, lhs.y - rhs.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Offset(PointInt32 pt, VectorInt32 offset) => 
            Offset(pt, offset.x, offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Offset(PointInt32 pt, int dx, int dy) => 
            new PointInt32(pt.x + dx, pt.y + dy);

        public int X
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.x = value;
            }
        }
        public int Y
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.y = value;
            }
        }
        public bool IsZero =>
            ((this.x == 0) && (this.y == 0));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PointInt32(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PointInt32 other) => 
            ((this.x == other.x) && (this.y == other.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<PointInt32, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(PointInt32 lhs, PointInt32 rhs) => 
            lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(PointInt32 lhs, PointInt32 rhs) => 
            !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x, this.y);

        public static PointInt32 Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static PointInt32 Parse(string source, IFormatProvider formatProvider)
        {
            TokenizerHelper helper1 = new TokenizerHelper(source, formatProvider);
            string str = helper1.NextTokenRequired();
            string str2 = helper1.NextTokenRequired();
            helper1.LastTokenRequired();
            return new PointInt32(Convert.ToInt32(str, formatProvider), Convert.ToInt32(str2, formatProvider));
        }

        PointInt32 IParseString<PointInt32>.Parse(string source, IFormatProvider formatProvider) => 
            Parse(source, formatProvider);

        public override string ToString() => 
            this.ToString(null, null);

        public string ToString(IFormatProvider formatProvider) => 
            this.ToString(null, formatProvider);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            object[] fieldValues = new object[] { this.x, this.y };
            return TokenizerHelper.ConvertToString(format, formatProvider, fieldValues);
        }

        static PointInt32()
        {
            boxedZero = new PointInt32();
        }
    }
}

