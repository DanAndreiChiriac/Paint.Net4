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

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<ThicknessDouble>)), ValueSerializer(typeof(StringBasedValueSerializer<ThicknessDouble>)), DebuggerDisplay("{left},{right},{top},{bottom}")]
    public struct ThicknessDouble : IEquatable<ThicknessDouble>, IFormattable, IParseString<ThicknessDouble>
    {
        private static readonly object boxedZero;
        internal double left;
        internal double top;
        internal double right;
        internal double bottom;
        public static object BoxedZero =>
            (boxedZero ?? new ThicknessDouble());
        public static ThicknessDouble Zero =>
            new ThicknessDouble();
        public double Left
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.left;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.left = value;
            }
        }
        public double Top
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.top;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.top = value;
            }
        }
        public double Right
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.right;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.right = value;
            }
        }
        public double Bottom
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.bottom;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.bottom = value;
            }
        }
        public bool IsUniform =>
            (((this.left == this.top) && (this.top == this.right)) && (this.right == this.bottom));
        public bool IsZero =>
            (this == Zero);
        public ThicknessDouble(double left, double top, double right, double bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public ThicknessDouble(double uniformLength) : this(uniformLength, uniformLength, uniformLength, uniformLength)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ThicknessDouble other) => 
            ((((this.left == other.left) && (this.top == other.top)) && (this.right == other.right)) && (this.bottom == other.bottom));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ThicknessDouble, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ThicknessDouble lhs, ThicknessDouble rhs) => 
            lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ThicknessDouble lhs, ThicknessDouble rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.left.GetHashCode(), this.top.GetHashCode(), this.right.GetHashCode(), this.bottom.GetHashCode());

        public static ThicknessDouble Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static ThicknessDouble Parse(string source, IFormatProvider formatProvider)
        {
            TokenizerHelper helper1 = new TokenizerHelper(source, formatProvider);
            string str = helper1.NextTokenRequired();
            string str2 = helper1.NextTokenRequired();
            string str3 = helper1.NextTokenRequired();
            string str4 = helper1.NextTokenRequired();
            helper1.LastTokenRequired();
            double top = Convert.ToDouble(str2, formatProvider);
            double right = Convert.ToDouble(str3, formatProvider);
            return new ThicknessDouble(Convert.ToDouble(str, formatProvider), top, right, Convert.ToDouble(str4, formatProvider));
        }

        ThicknessDouble IParseString<ThicknessDouble>.Parse(string source, IFormatProvider formatProvider) => 
            Parse(source, formatProvider);

        public override string ToString() => 
            this.ToString(null, null);

        public string ToString(IFormatProvider provider) => 
            this.ToString(null, provider);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            object[] fieldValues = new object[] { this.left, this.top, this.right, this.bottom };
            return TokenizerHelper.ConvertToString(format, formatProvider, fieldValues);
        }

        static ThicknessDouble()
        {
            boxedZero = new ThicknessDouble();
        }
    }
}

