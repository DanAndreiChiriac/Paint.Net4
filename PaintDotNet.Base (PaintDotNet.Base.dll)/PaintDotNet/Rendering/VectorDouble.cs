namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using PaintDotNet.Markup;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Markup;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<VectorDouble>)), ValueSerializer(typeof(StringBasedValueSerializer<VectorDouble>)), DebuggerDisplay("x={x}, y={y}")]
    public struct VectorDouble : IEquatable<VectorDouble>, IFormattable, IParseString<VectorDouble>
    {
        private static readonly object boxedZero;
        internal double x;
        internal double y;
        public static object BoxedZero =>
            (boxedZero ?? new VectorDouble());
        public static VectorDouble Zero =>
            new VectorDouble();
        public static explicit operator VectorDouble(PointDouble pt) => 
            new VectorDouble(pt.x, pt.y);

        public static explicit operator VectorDouble(PointFloat pt) => 
            new VectorDouble((double) pt.x, (double) pt.y);

        public static explicit operator VectorDouble(PointInt32 pt) => 
            new VectorDouble((double) pt.x, (double) pt.y);

        public static explicit operator VectorDouble(SizeDouble size) => 
            new VectorDouble(size.width, size.height);

        public static explicit operator VectorDouble(SizeFloat size) => 
            new VectorDouble((double) size.width, (double) size.height);

        public static explicit operator VectorDouble(SizeInt32 size) => 
            new VectorDouble((double) size.width, (double) size.height);

        public static implicit operator VectorDouble(VectorFloat vec) => 
            new VectorDouble((double) vec.x, (double) vec.y);

        public static implicit operator VectorDouble(VectorInt32 vec) => 
            new VectorDouble((double) vec.x, (double) vec.y);

        public static VectorInt32 Ceiling(VectorDouble vec) => 
            new VectorInt32((int) Math.Ceiling(vec.x), (int) Math.Ceiling(vec.y));

        public static VectorInt32 Floor(VectorDouble vec) => 
            new VectorInt32((int) Math.Floor(vec.x), (int) Math.Floor(vec.y));

        public static VectorInt32 Round(VectorDouble vec, MidpointRounding mode = 1) => 
            new VectorInt32((int) Math.Round(vec.x, mode), (int) Math.Round(vec.y, mode));

        public static VectorInt32 Truncate(VectorDouble vec) => 
            new VectorInt32((int) Math.Truncate(vec.x), (int) Math.Truncate(vec.y));

        public static PointDouble operator +(VectorDouble vector, PointDouble point) => 
            new PointDouble(point.x + vector.x, point.y + vector.y);

        public static VectorDouble operator +(VectorDouble vector1, VectorDouble vector2) => 
            new VectorDouble(vector1.x + vector2.x, vector1.y + vector2.y);

        public static PointDouble operator +(PointInt32 point, VectorDouble vector) => 
            new PointDouble(point.x + vector.x, point.y + vector.y);

        public static VectorDouble operator /(VectorDouble vector, double scalar) => 
            ((VectorDouble) (vector * (1.0 / scalar)));

        public static VectorDouble operator *(double scalar, VectorDouble vector) => 
            new VectorDouble(vector.x * scalar, vector.y * scalar);

        public static VectorDouble operator *(VectorDouble vector, double scalar) => 
            new VectorDouble(vector.x * scalar, vector.y * scalar);

        public static VectorDouble operator *(VectorDouble vector, Matrix3x2Double matrix) => 
            matrix.Transform(vector);

        public static double operator *(VectorDouble vector1, VectorDouble vector2) => 
            ((vector1.x * vector2.x) + (vector1.y * vector2.y));

        public static VectorDouble operator -(VectorDouble vector1, VectorDouble vector2) => 
            new VectorDouble(vector1.x - vector2.x, vector1.y - vector2.y);

        public static VectorDouble operator -(VectorDouble vector) => 
            new VectorDouble(-vector.x, -vector.y);

        public static VectorDouble Abs(VectorDouble vec) => 
            new VectorDouble(Math.Abs(vec.x), Math.Abs(vec.y));

        public static double AngleBetween(VectorDouble vector1, VectorDouble vector2)
        {
            double x = (vector1.x * vector2.x) + (vector1.y * vector2.y);
            return (Math.Atan2((vector1.x * vector2.y) - (vector2.x * vector1.y), x) * 57.295779513082323);
        }

        public static double CrossProduct(VectorDouble vector1, VectorDouble vector2) => 
            ((vector1.x * vector2.y) - (vector1.y * vector2.x));

        public static double Determinant(VectorDouble vector1, VectorDouble vector2) => 
            ((vector1.x * vector2.y) - (vector1.y * vector2.x));

        public static VectorDouble Negate(VectorDouble vec) => 
            -vec;

        public static VectorDouble Normalize(VectorDouble vec)
        {
            vec = (VectorDouble) (vec / Math.Max(Math.Abs(vec.x), Math.Abs(vec.y)));
            vec = (VectorDouble) (vec / vec.Length);
            return vec;
        }

        public double X
        {
            get => 
                this.x;
            set
            {
                this.x = value;
            }
        }
        public double Y
        {
            get => 
                this.y;
            set
            {
                this.y = value;
            }
        }
        public bool IsFinite =>
            (this.x.IsFinite() && this.y.IsFinite());
        public bool IsZero =>
            ((this.x == 0.0) && (this.y == 0.0));
        public double Length =>
            Math.Sqrt((this.x * this.x) + (this.y * this.y));
        public double LengthSquared =>
            ((this.x * this.x) + (this.y * this.y));
        public VectorDouble(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(VectorDouble other) => 
            ((this.x == other.x) && (this.y == other.y));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<VectorDouble, object>(this, obj);

        public static bool operator ==(VectorDouble lhs, VectorDouble rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(VectorDouble lhs, VectorDouble rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x.GetHashCode(), this.y.GetHashCode());

        public static VectorDouble Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static VectorDouble Parse(string source, IFormatProvider formatProvider)
        {
            TokenizerHelper helper1 = new TokenizerHelper(source, formatProvider);
            string str = helper1.NextTokenRequired();
            string str2 = helper1.NextTokenRequired();
            helper1.LastTokenRequired();
            return new VectorDouble(Convert.ToDouble(str, formatProvider), Convert.ToDouble(str2, formatProvider));
        }

        VectorDouble IParseString<VectorDouble>.Parse(string source, IFormatProvider formatProvider) => 
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

        static VectorDouble()
        {
            boxedZero = new VectorDouble();
        }
    }
}

