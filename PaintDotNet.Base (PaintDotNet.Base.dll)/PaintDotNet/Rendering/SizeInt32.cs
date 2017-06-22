namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Markup;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Markup;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<SizeInt32>)), ValueSerializer(typeof(StringBasedValueSerializer<SizeInt32>)), DebuggerDisplay("{width},{height}")]
    public struct SizeInt32 : IEquatable<SizeInt32>, IFormattable, IParseString<SizeInt32>
    {
        private static readonly object boxedZero;
        internal int width;
        internal int height;
        public static object BoxedZero =>
            (boxedZero ?? new SizeInt32());
        public static SizeInt32 Empty =>
            new SizeInt32 { 
                width=-2147483648,
                height=0x7fffffff
            };
        public static SizeInt32 Max =>
            new SizeInt32(0x7fffffff, 0x7fffffff);
        public static SizeInt32 Zero =>
            new SizeInt32(0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator SizeInt32(PointInt32 pt) => 
            new SizeInt32(pt.x, pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator SizeInt32(VectorInt32 vec) => 
            new SizeInt32(vec.x, vec.y);

        public int Width
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.width;
            set
            {
                Validate.IsNotNegative(value, "value");
                this.width = value;
            }
        }
        public int Height
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.height;
            set
            {
                Validate.IsNotNegative(value, "value");
                this.height = value;
            }
        }
        public int Area =>
            (this.width * this.height);
        public bool HasPositiveArea =>
            ((this.width > 0) && (this.height > 0));
        public bool HasZeroArea =>
            ((this.width == 0) && (this.height == 0));
        public bool IsEmpty =>
            (this == Empty);
        public bool IsZero =>
            (this == Zero);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SizeInt32(int width, int height)
        {
            Validate.Begin().IsNotNegative(width, "width").IsNotNegative(height, "height").Check();
            this.width = width;
            this.height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(SizeInt32 other) => 
            ((this.width == other.width) && (this.height == other.height));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<SizeInt32, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SizeInt32 lhs, SizeInt32 rhs) => 
            lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SizeInt32 lhs, SizeInt32 rhs) => 
            !(lhs == rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.width, this.height);

        public static SizeInt32 Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static SizeInt32 Parse(string source, IFormatProvider formatProvider)
        {
            SizeInt32 empty;
            TokenizerHelper helper = new TokenizerHelper(source, formatProvider);
            string str = helper.NextTokenRequired();
            if (str == "Empty")
            {
                empty = Empty;
            }
            else
            {
                int width = Convert.ToInt32(str, formatProvider);
                int height = Convert.ToInt32(helper.NextTokenRequired(), formatProvider);
                empty = new SizeInt32(width, height);
            }
            helper.LastTokenRequired();
            return empty;
        }

        SizeInt32 IParseString<SizeInt32>.Parse(string source, IFormatProvider formatProvider) => 
            Parse(source, formatProvider);

        public override string ToString() => 
            this.ToString(null, null);

        public string ToString(IFormatProvider formatProvider) => 
            this.ToString(null, formatProvider);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this.IsEmpty)
            {
                return "Empty";
            }
            object[] fieldValues = new object[] { this.width, this.height };
            return TokenizerHelper.ConvertToString(format, formatProvider, fieldValues);
        }

        static SizeInt32()
        {
            boxedZero = new SizeInt32();
        }
    }
}

