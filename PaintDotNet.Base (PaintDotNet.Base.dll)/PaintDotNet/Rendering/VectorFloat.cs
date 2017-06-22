namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using PaintDotNet.Markup;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Markup;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<VectorFloat>)), ValueSerializer(typeof(StringBasedValueSerializer<VectorFloat>)), DebuggerDisplay("x={x}, y={y}")]
    public struct VectorFloat : IEquatable<VectorFloat>, IFormattable, IParseString<VectorFloat>
    {
        private static readonly object boxedZero;
        internal float x;
        internal float y;
        public static object BoxedZero =>
            (boxedZero ?? new VectorFloat());
        public static VectorFloat Zero =>
            new VectorFloat(0f, 0f);
        public static explicit operator VectorFloat(PointDouble pt) => 
            new VectorFloat((float) pt.x, (float) pt.y);

        public static explicit operator VectorFloat(PointFloat pt) => 
            new VectorFloat(pt.x, pt.y);

        public static explicit operator VectorFloat(PointInt32 pt) => 
            new VectorFloat((float) pt.x, (float) pt.y);

        public static explicit operator VectorFloat(SizeDouble size) => 
            new VectorFloat((float) size.width, (float) size.height);

        public static explicit operator VectorFloat(SizeFloat size) => 
            new VectorFloat(size.width, size.height);

        public static explicit operator VectorFloat(SizeInt32 size) => 
            new VectorFloat((float) size.width, (float) size.height);

        public static explicit operator VectorFloat(VectorDouble vec) => 
            new VectorFloat((float) vec.x, (float) vec.y);

        public static implicit operator VectorFloat(VectorInt32 vec) => 
            new VectorFloat((float) vec.x, (float) vec.y);

        public static VectorInt32 Ceiling(VectorFloat vec) => 
            new VectorInt32((int) Math.Ceiling((double) vec.x), (int) Math.Ceiling((double) vec.y));

        public static VectorInt32 Floor(VectorFloat vec) => 
            new VectorInt32((int) Math.Floor((double) vec.x), (int) Math.Floor((double) vec.y));

        public static VectorInt32 Round(VectorFloat vec, MidpointRounding mode = 1) => 
            new VectorInt32((int) Math.Round((double) vec.x, mode), (int) Math.Round((double) vec.y, mode));

        public static VectorInt32 Truncate(VectorFloat vec) => 
            new VectorInt32((int) Math.Truncate((double) vec.x), (int) Math.Truncate((double) vec.y));

        public static PointFloat operator +(VectorFloat vector, PointFloat point) => 
            new PointFloat(point.x + vector.x, point.y + vector.y);

        public static VectorFloat operator +(VectorFloat vector1, VectorFloat vector2) => 
            new VectorFloat(vector1.x + vector2.x, vector1.y + vector2.y);

        public static PointFloat operator +(PointInt32 point, VectorFloat vector) => 
            new PointFloat(point.x + vector.x, point.y + vector.y);

        public static VectorFloat operator /(VectorFloat vector, float scalar) => 
            ((VectorFloat) (vector * (1f / scalar)));

        public static VectorFloat operator *(float scalar, VectorFloat vector) => 
            new VectorFloat(vector.x * scalar, vector.y * scalar);

        public static VectorFloat operator *(VectorFloat vector, float scalar) => 
            new VectorFloat(vector.x * scalar, vector.y * scalar);

        public static VectorFloat operator *(VectorFloat vector, Matrix3x2Float matrix) => 
            matrix.Transform(vector);

        public static double operator *(VectorFloat vector1, VectorFloat vector2) => 
            ((double) ((vector1.x * vector2.x) + (vector1.y * vector2.y)));

        public static VectorFloat operator -(VectorFloat vector1, VectorFloat vector2) => 
            new VectorFloat(vector1.x - vector2.x, vector1.y - vector2.y);

        public static VectorFloat operator -(VectorFloat vector) => 
            new VectorFloat(-vector.x, -vector.y);

        public static VectorFloat Abs(VectorFloat vec) => 
            new VectorFloat(Math.Abs(vec.x), Math.Abs(vec.y));

        public static float AngleBetween(VectorFloat vector1, VectorFloat vector2)
        {
            float num = (vector1.x * vector2.x) + (vector1.y * vector2.y);
            return (float) (Math.Atan2((double) ((vector1.x * vector2.y) - (vector2.x * vector1.y)), (double) num) * 57.295779513082323);
        }

        public static float CrossProduct(VectorFloat vector1, VectorFloat vector2) => 
            ((vector1.x * vector2.y) - (vector1.y * vector2.x));

        public static double Determinant(VectorFloat vector1, VectorFloat vector2) => 
            ((double) ((vector1.x * vector2.y) - (vector1.y * vector2.x)));

        public static VectorFloat Negate(VectorFloat vec) => 
            -vec;

        public static VectorFloat Normalize(VectorFloat vec)
        {
            vec = (VectorFloat) (vec / Math.Max(Math.Abs(vec.x), Math.Abs(vec.y)));
            vec = (VectorFloat) (vec / vec.Length);
            return vec;
        }

        public float X
        {
            get => 
                this.x;
            set
            {
                this.x = value;
            }
        }
        public float Y
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
            ((this.x == 0f) && (this.y == 0f));
        public float Length =>
            ((float) Math.Sqrt((double) ((this.x * this.x) + (this.y * this.y))));
        public float LengthSquared =>
            ((this.x * this.x) + (this.y * this.y));
        public VectorFloat(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(VectorFloat other) => 
            ((this.x == other.x) && (this.y == other.y));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<VectorFloat, object>(this, obj);

        public static bool operator ==(VectorFloat lhs, VectorFloat rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(VectorFloat lhs, VectorFloat rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x.GetHashCode(), this.y.GetHashCode());

        public static VectorFloat Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static VectorFloat Parse(string source, IFormatProvider formatProvider)
        {
            TokenizerHelper helper1 = new TokenizerHelper(source, formatProvider);
            string str = helper1.NextTokenRequired();
            string str2 = helper1.NextTokenRequired();
            helper1.LastTokenRequired();
            return new VectorFloat(Convert.ToSingle(str, formatProvider), Convert.ToSingle(str2, formatProvider));
        }

        VectorFloat IParseString<VectorFloat>.Parse(string source, IFormatProvider formatProvider) => 
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

        static VectorFloat()
        {
            boxedZero = new VectorFloat();
        }
    }
}

