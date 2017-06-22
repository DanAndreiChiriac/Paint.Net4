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

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<PointDouble>)), ValueSerializer(typeof(StringBasedValueSerializer<PointDouble>)), DebuggerDisplay("{X},{Y}")]
    public struct PointDouble : IEquatable<PointDouble>, IFormattable, IParseString<PointDouble>, IConvertibleTo<PointFloat>, IConvertibleFrom<PointFloat>, IConvertibleFrom<PointInt32>
    {
        private static readonly object boxedZero;
        internal double x;
        internal double y;
        public static object BoxedZero =>
            (boxedZero ?? new PointDouble());
        public static PointDouble PositiveInfinity =>
            new PointDouble(double.PositiveInfinity, double.PositiveInfinity);
        public static PointDouble NaN =>
            new PointDouble(double.NaN, double.NaN);
        public static PointDouble Zero =>
            new PointDouble();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator PointDouble(PointFloat pt) => 
            new PointDouble((double) pt.x, (double) pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator PointDouble(PointInt32 pt) => 
            new PointDouble((double) pt.x, (double) pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointDouble(SizeDouble size) => 
            new PointDouble(size.width, size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointDouble(SizeFloat size) => 
            new PointDouble((double) size.width, (double) size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointDouble(SizeInt32 size) => 
            new PointDouble((double) size.width, (double) size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointDouble(VectorDouble vec) => 
            new PointDouble(vec.x, vec.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointDouble(VectorFloat vec) => 
            new PointDouble((double) vec.x, (double) vec.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PointDouble(VectorInt32 vec) => 
            new PointDouble((double) vec.x, (double) vec.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Ceiling(PointDouble pt) => 
            new PointInt32((int) Math.Ceiling(pt.x), (int) Math.Ceiling(pt.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Floor(PointDouble pt) => 
            new PointInt32((int) Math.Floor(pt.x), (int) Math.Floor(pt.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Round(PointDouble pt, MidpointRounding mode = 1) => 
            new PointInt32((int) Math.Round(pt.x, mode), (int) Math.Round(pt.y, mode));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInt32 Truncate(PointDouble pt) => 
            new PointInt32((int) Math.Truncate(pt.x), (int) Math.Truncate(pt.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointDouble operator +(PointDouble lhs, VectorDouble rhs) => 
            new PointDouble(lhs.x + rhs.x, lhs.y + rhs.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointDouble operator *(PointDouble point, Matrix3x2Double matrix) => 
            matrix.Transform(point);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointDouble operator -(PointDouble pt) => 
            new PointDouble(-pt.x, -pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VectorDouble operator -(PointDouble lhs, PointDouble rhs) => 
            new VectorDouble(lhs.x - rhs.x, lhs.y - rhs.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointDouble operator -(PointDouble point, VectorDouble vector) => 
            new PointDouble(point.x - vector.x, point.y - vector.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointDouble Offset(PointDouble pt, VectorDouble offset) => 
            new PointDouble(pt.x + offset.x, pt.y + offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointDouble Offset(PointDouble pt, double dx, double dy) => 
            new PointDouble(pt.x + dx, pt.y + dy);

        public double X
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
        public double Y
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
            ((this.x == 0.0) && (this.y == 0.0));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PointDouble(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(PointDouble other) => 
            ((this.x == other.x) && (this.y == other.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<PointDouble, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(PointDouble lhs, PointDouble rhs) => 
            lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(PointDouble lhs, PointDouble rhs) => 
            !lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x.GetHashCode(), this.y.GetHashCode());

        public static PointDouble Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static PointDouble Parse(string source, IFormatProvider formatProvider)
        {
            TokenizerHelper helper1 = new TokenizerHelper(source, formatProvider);
            string str = helper1.NextTokenRequired();
            string str2 = helper1.NextTokenRequired();
            helper1.LastTokenRequired();
            return new PointDouble(Convert.ToDouble(str, formatProvider), Convert.ToDouble(str2, formatProvider));
        }

        PointDouble IParseString<PointDouble>.Parse(string source, IFormatProvider formatProvider) => 
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
        PointFloat IConvertibleTo<PointFloat>.Convert() => 
            ((PointFloat) this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void IConvertibleFrom<PointFloat>.ConvertFrom(PointFloat value)
        {
            this.x = value.x;
            this.y = value.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void IConvertibleFrom<PointInt32>.ConvertFrom(PointInt32 value)
        {
            this.x = value.x;
            this.y = value.y;
        }

        static PointDouble()
        {
            boxedZero = new PointDouble();
        }
    }
}

