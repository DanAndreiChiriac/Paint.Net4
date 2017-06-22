namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Markup;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Markup;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<SizeFloat>)), ValueSerializer(typeof(StringBasedValueSerializer<SizeFloat>)), DebuggerDisplay("{width},{height}")]
    public struct SizeFloat : IEquatable<SizeFloat>, IFormattable, IParseString<SizeFloat>
    {
        private static readonly object boxedZero;
        internal float width;
        internal float height;
        public static object BoxedZero =>
            (boxedZero ?? new SizeFloat());
        public static SizeFloat Empty =>
            new SizeFloat { 
                width=float.NegativeInfinity,
                height=float.NegativeInfinity
            };
        public static SizeFloat PositiveInfinity =>
            new SizeFloat(float.PositiveInfinity, float.PositiveInfinity);
        public static SizeFloat Zero =>
            new SizeFloat(0f, 0f);
        public static explicit operator SizeFloat(PointDouble pt) => 
            new SizeFloat((float) pt.x, (float) pt.y);

        public static explicit operator SizeFloat(PointFloat pt) => 
            new SizeFloat(pt.x, pt.y);

        public static explicit operator SizeFloat(PointInt32 pt) => 
            new SizeFloat((float) pt.x, (float) pt.y);

        public static explicit operator SizeFloat(SizeDouble size) => 
            new SizeFloat((float) size.width, (float) size.height);

        public static implicit operator SizeFloat(SizeInt32 size) => 
            new SizeFloat((float) size.width, (float) size.height);

        public static explicit operator SizeFloat(VectorDouble vec) => 
            new SizeFloat((float) vec.x, (float) vec.y);

        public static explicit operator SizeFloat(VectorFloat vec) => 
            new SizeFloat(vec.x, vec.y);

        public static explicit operator SizeFloat(VectorInt32 vec) => 
            new SizeFloat((float) vec.x, (float) vec.y);

        public static SizeInt32 Ceiling(SizeFloat size) => 
            new SizeInt32((int) Math.Ceiling((double) size.width), (int) Math.Ceiling((double) size.height));

        public static SizeInt32 Floor(SizeFloat size) => 
            new SizeInt32((int) Math.Floor((double) size.width), (int) Math.Floor((double) size.height));

        public static SizeInt32 Round(SizeFloat size, MidpointRounding mode = 1) => 
            new SizeInt32((int) Math.Round((double) size.width, mode), (int) Math.Round((double) size.height, mode));

        public static SizeInt32 Truncate(SizeFloat size) => 
            new SizeInt32((int) Math.Truncate((double) size.width), (int) Math.Truncate((double) size.height));

        public float Width
        {
            get => 
                this.width;
            set
            {
                Validate.IsNotNegative(value, "value");
                this.width = value;
            }
        }
        public float Height
        {
            get => 
                this.height;
            set
            {
                Validate.IsNotNegative(value, "value");
                this.height = value;
            }
        }
        public float Area =>
            (this.width * this.height);
        public bool HasPositiveArea =>
            ((this.width > 0f) && (this.height > 0f));
        public bool HasZeroArea
        {
            get
            {
                if (this.width != 0f)
                {
                    return (this.height == 0f);
                }
                return true;
            }
        }
        public bool IsEmpty =>
            (this == Empty);
        public bool IsZero =>
            (this == Zero);
        public SizeFloat(float width, float height)
        {
            Validate.Begin().IsNotNegative(width, "width").IsNotNegative(height, "height").Check();
            this.width = width;
            this.height = height;
        }

        public bool Equals(SizeFloat other) => 
            ((this.width == other.width) && (this.height == other.height));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<SizeFloat, object>(this, obj);

        public static bool operator ==(SizeFloat lhs, SizeFloat rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(SizeFloat lhs, SizeFloat rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.width.GetHashCode(), this.height.GetHashCode());

        public static SizeFloat Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static SizeFloat Parse(string source, IFormatProvider formatProvider)
        {
            SizeFloat empty;
            TokenizerHelper helper = new TokenizerHelper(source, formatProvider);
            string str = helper.NextTokenRequired();
            if (str == "Empty")
            {
                empty = Empty;
            }
            else
            {
                float width = Convert.ToSingle(str, formatProvider);
                float height = Convert.ToSingle(helper.NextTokenRequired(), formatProvider);
                empty = new SizeFloat(width, height);
            }
            helper.LastTokenRequired();
            return empty;
        }

        SizeFloat IParseString<SizeFloat>.Parse(string source, IFormatProvider formatProvider) => 
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

        static SizeFloat()
        {
            boxedZero = new SizeFloat();
        }
    }
}

