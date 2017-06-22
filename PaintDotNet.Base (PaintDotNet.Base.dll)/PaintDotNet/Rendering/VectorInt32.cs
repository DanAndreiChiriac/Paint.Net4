namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using PaintDotNet.Markup;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Markup;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<VectorInt32>)), ValueSerializer(typeof(StringBasedValueSerializer<VectorInt32>)), DebuggerDisplay("x={x}, y={y}")]
    public struct VectorInt32 : IEquatable<VectorInt32>, IFormattable, IParseString<VectorInt32>
    {
        private static readonly object boxedZero;
        internal int x;
        internal int y;
        public static object BoxedZero =>
            (boxedZero ?? new VectorInt32());
        public static VectorInt32 Zero =>
            new VectorInt32();
        public static explicit operator VectorInt32(PointInt32 pt) => 
            new VectorInt32(pt.x, pt.y);

        public static explicit operator VectorInt32(SizeInt32 size) => 
            new VectorInt32(size.width, size.height);

        public static PointInt32 operator +(VectorInt32 vector, PointInt32 point) => 
            new PointInt32(point.x + vector.x, point.y + vector.y);

        public static VectorInt32 operator +(VectorInt32 vector1, VectorInt32 vector2) => 
            new VectorInt32(vector1.x + vector2.x, vector1.y + vector2.y);

        public static VectorInt32 operator *(int scalar, VectorInt32 vector) => 
            new VectorInt32(vector.x * scalar, vector.y * scalar);

        public static VectorInt32 operator *(VectorInt32 vector, int scalar) => 
            new VectorInt32(vector.x * scalar, vector.y * scalar);

        public static VectorInt32 operator -(VectorInt32 vector1, VectorInt32 vector2) => 
            new VectorInt32(vector1.x - vector2.x, vector1.y - vector2.y);

        public static VectorInt32 operator -(VectorInt32 vector) => 
            new VectorInt32(-vector.x, -vector.y);

        public static VectorInt32 Abs(VectorInt32 vec) => 
            new VectorInt32(Math.Abs(vec.x), Math.Abs(vec.y));

        public static VectorInt32 Negate(VectorInt32 vec) => 
            -vec;

        public int X
        {
            get => 
                this.x;
            set
            {
                this.x = value;
            }
        }
        public int Y
        {
            get => 
                this.y;
            set
            {
                this.y = value;
            }
        }
        public bool IsZero =>
            ((this.x == 0) && (this.y == 0));
        public long LengthSquared =>
            ((long) ((this.x * this.x) + (this.y * this.y)));
        public VectorInt32(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(VectorInt32 other) => 
            ((this.x == other.x) && (this.y == other.y));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<VectorInt32, object>(this, obj);

        public static bool operator ==(VectorInt32 lhs, VectorInt32 rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(VectorInt32 lhs, VectorInt32 rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x.GetHashCode(), this.y.GetHashCode());

        public static VectorInt32 Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static VectorInt32 Parse(string source, IFormatProvider formatProvider)
        {
            TokenizerHelper helper1 = new TokenizerHelper(source, formatProvider);
            string str = helper1.NextTokenRequired();
            string str2 = helper1.NextTokenRequired();
            helper1.LastTokenRequired();
            return new VectorInt32(Convert.ToInt32(str, formatProvider), Convert.ToInt32(str2, formatProvider));
        }

        VectorInt32 IParseString<VectorInt32>.Parse(string source, IFormatProvider formatProvider) => 
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

        static VectorInt32()
        {
            boxedZero = new VectorInt32();
        }
    }
}

