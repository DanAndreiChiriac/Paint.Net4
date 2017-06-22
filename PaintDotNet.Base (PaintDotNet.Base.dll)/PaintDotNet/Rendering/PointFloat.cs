namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Markup;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Markup;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<PointFloat>)), ValueSerializer(typeof(StringBasedValueSerializer<PointFloat>)), DebuggerDisplay("{X},{Y}")]
    public struct PointFloat : IEquatable<PointFloat>, IFormattable, IParseString<PointFloat>, IConvertibleTo<PointDouble>, IConvertibleFrom<PointDouble>, IConvertibleFrom<PointInt32>
    {
        private static readonly object boxedZero;
        internal float x;
        internal float y;
        public static object BoxedZero =>
            (boxedZero ?? new PointFloat());
        public static PointFloat PositiveInfinity =>
            new PointFloat(float.PositiveInfinity, float.PositiveInfinity);
        public static PointFloat NaN =>
            new PointFloat(float.NaN, float.NaN);
        public static PointFloat Zero =>
            new PointFloat();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointFloat(PointDouble pt) => 
            new PointFloat((float) pt.x, (float) pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator PointFloat(PointInt32 pt) => 
            new PointFloat((float) pt.x, (float) pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointFloat(SizeDouble size) => 
            new PointFloat((float) size.width, (float) size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointFloat(SizeFloat size) => 
            new PointFloat(size.width, size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointFloat(SizeInt32 size) => 
            new PointFloat((float) size.width, (float) size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointFloat(VectorDouble vec) => 
            new PointFloat((float) vec.x, (float) vec.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointFloat(VectorFloat vec) => 
            new PointFloat(vec.x, vec.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointFloat(VectorInt32 vec) => 
            new PointFloat((float) vec.x, (float) vec.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Floor(PointFloat pt) => 
            new PointInt32((int) Math.Floor((double) pt.x), (int) Math.Floor((double) pt.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Ceiling(PointFloat pt) => 
            new PointInt32((int) Math.Ceiling((double) pt.x), (int) Math.Ceiling((double) pt.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Round(PointFloat pt, MidpointRounding mode = 1) => 
            new PointInt32((int) Math.Round((double) pt.x, mode), (int) Math.Round((double) pt.y, mode));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Truncate(PointFloat pt) => 
            new PointInt32((int) Math.Truncate((double) pt.x), (int) Math.Truncate((double) pt.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointFloat operator +(PointFloat lhs, VectorFloat rhs) => 
            new PointFloat(lhs.x + rhs.x, lhs.y + rhs.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointFloat operator *(PointFloat point, Matrix3x2Float matrix) => 
            matrix.Transform(point);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VectorFloat operator -(PointFloat lhs, PointFloat rhs) => 
            new VectorFloat(lhs.x - rhs.x, lhs.y - rhs.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointFloat operator -(PointFloat point, VectorFloat vector) => 
            new PointFloat(point.x - vector.x, point.y - vector.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointFloat operator -(PointFloat pt) => 
            new PointFloat(-pt.x, -pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointFloat Offset(PointFloat pt, VectorFloat offset) => 
            new PointFloat(pt.x + offset.x, pt.y + offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointFloat Offset(PointFloat pt, float dx, float dy) => 
            new PointFloat(pt.x + dx, pt.y + dy);

        public float X
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
        public float Y
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
        public bool IsFinite =>
            (this.x.IsFinite() && this.y.IsFinite());
        public bool IsZero =>
            ((this.x == 0f) && (this.y == 0f));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PointFloat(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PointFloat other) => 
            ((this.x == other.x) && (this.y == other.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<PointFloat, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(PointFloat lhs, PointFloat rhs) => 
            lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(PointFloat lhs, PointFloat rhs) => 
            !lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x.GetHashCode(), this.y.GetHashCode());

        public static PointFloat Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static PointFloat Parse(string source, IFormatProvider formatProvider)
        {
            TokenizerHelper helper1 = new TokenizerHelper(source, formatProvider);
            string str = helper1.NextTokenRequired();
            string str2 = helper1.NextTokenRequired();
            helper1.LastTokenRequired();
            return new PointFloat(Convert.ToSingle(str, formatProvider), Convert.ToSingle(str2, formatProvider));
        }

        PointFloat IParseString<PointFloat>.Parse(string source, IFormatProvider formatProvider) => 
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        PointDouble IConvertibleTo<PointDouble>.Convert() => 
            new PointDouble((double) this.x, (double) this.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void IConvertibleFrom<PointDouble>.ConvertFrom(PointDouble value)
        {
            this.x = (float) value.x;
            this.y = (float) value.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void IConvertibleFrom<PointInt32>.ConvertFrom(PointInt32 value)
        {
            this.x = value.x;
            this.y = value.y;
        }

        static PointFloat()
        {
            boxedZero = new PointFloat();
        }
    }
}

