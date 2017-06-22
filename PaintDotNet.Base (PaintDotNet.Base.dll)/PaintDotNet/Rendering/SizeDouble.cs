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

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<SizeDouble>)), ValueSerializer(typeof(StringBasedValueSerializer<SizeDouble>)), DebuggerDisplay("{width},{height}")]
    public struct SizeDouble : IEquatable<SizeDouble>, IFormattable, IParseString<SizeDouble>
    {
        private static readonly object boxedZero;
        internal double width;
        internal double height;
        public static object BoxedZero =>
            (boxedZero ?? new SizeDouble());
        public static SizeDouble Empty =>
            new SizeDouble { 
                width=double.NegativeInfinity,
                height=double.NegativeInfinity
            };
        public static SizeDouble PositiveInfinity =>
            new SizeDouble(double.PositiveInfinity, double.PositiveInfinity);
        public static SizeDouble Zero =>
            new SizeDouble();
        public static explicit operator SizeDouble(PointDouble pt) => 
            new SizeDouble(pt.x, pt.y);

        public static explicit operator SizeDouble(PointFloat pt) => 
            new SizeDouble((double) pt.x, (double) pt.y);

        public static explicit operator SizeDouble(PointInt32 pt) => 
            new SizeDouble((double) pt.x, (double) pt.y);

        public static implicit operator SizeDouble(SizeFloat size) => 
            new SizeDouble((double) size.width, (double) size.height);

        public static implicit operator SizeDouble(SizeInt32 size) => 
            new SizeDouble((double) size.width, (double) size.height);

        public static explicit operator SizeDouble(VectorDouble vec) => 
            new SizeDouble(vec.x, vec.y);

        public static explicit operator SizeDouble(VectorFloat vec) => 
            new SizeDouble((double) vec.x, (double) vec.y);

        public static explicit operator SizeDouble(VectorInt32 vec) => 
            new SizeDouble((double) vec.x, (double) vec.y);

        public static SizeInt32 Ceiling(SizeDouble size) => 
            new SizeInt32((int) Math.Ceiling(size.width), (int) Math.Ceiling(size.height));

        public static SizeInt32 Floor(SizeDouble size) => 
            new SizeInt32((int) Math.Floor(size.width), (int) Math.Floor(size.height));

        public static SizeInt32 Round(SizeDouble size, MidpointRounding mode = 1) => 
            new SizeInt32((int) Math.Round(size.width, mode), (int) Math.Round(size.height, mode));

        public static SizeInt32 Truncate(SizeDouble size) => 
            new SizeInt32((int) Math.Truncate(size.width), (int) Math.Truncate(size.height));

        public double Width
        {
            get => 
                this.width;
            set
            {
                Validate.IsNotNegative(value, "value");
                this.width = value;
            }
        }
        public double Height
        {
            get => 
                this.height;
            set
            {
                Validate.IsNotNegative(value, "value");
                this.height = value;
            }
        }
        public double Area =>
            (this.width * this.height);
        public bool HasPositiveArea =>
            ((this.width > 0.0) && (this.height > 0.0));
        public bool HasZeroArea
        {
            get
            {
                if (this.width != 0.0)
                {
                    return (this.height == 0.0);
                }
                return true;
            }
        }
        public bool IsEmpty =>
            (this == Empty);
        public bool IsZero =>
            (this == Zero);
        public SizeDouble(double width, double height)
        {
            Validate.Begin().IsNotNegative(width, "width").IsNotNegative(height, "height").Check();
            this.width = width;
            this.height = height;
        }

        public bool Equals(SizeDouble other) => 
            ((this.width == other.width) && (this.height == other.height));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<SizeDouble, object>(this, obj);

        public static bool operator ==(SizeDouble lhs, SizeDouble rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(SizeDouble lhs, SizeDouble rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.width.GetHashCode(), this.height.GetHashCode());

        public static SizeDouble Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static SizeDouble Parse(string source, IFormatProvider formatProvider)
        {
            SizeDouble empty;
            TokenizerHelper helper = new TokenizerHelper(source, formatProvider);
            string str = helper.NextTokenRequired();
            if (str == "Empty")
            {
                empty = Empty;
            }
            else
            {
                double width = Convert.ToDouble(str, formatProvider);
                double height = Convert.ToDouble(helper.NextTokenRequired(), formatProvider);
                empty = new SizeDouble(width, height);
            }
            helper.LastTokenRequired();
            return empty;
        }

        SizeDouble IParseString<SizeDouble>.Parse(string source, IFormatProvider formatProvider) => 
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

        static SizeDouble()
        {
            boxedZero = new SizeDouble();
        }
    }
}

