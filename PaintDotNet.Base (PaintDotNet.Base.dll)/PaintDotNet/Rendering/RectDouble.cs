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

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<RectDouble>)), ValueSerializer(typeof(StringBasedValueSerializer<RectDouble>)), DebuggerDisplay("{x},{y},{width},{height}")]
    public struct RectDouble : IEquatable<RectDouble>, IFormattable, IParseString<RectDouble>
    {
        private static readonly object boxedZero;
        internal double x;
        internal double y;
        internal double width;
        internal double height;
        public static object BoxedZero =>
            (boxedZero ?? new RectDouble());
        public static RectDouble Empty =>
            new RectDouble { 
                x=double.PositiveInfinity,
                y=double.PositiveInfinity,
                width=double.NegativeInfinity,
                height=double.NegativeInfinity
            };
        public static RectDouble Infinite =>
            new RectDouble { 
                x=double.NegativeInfinity,
                y=double.NegativeInfinity,
                width=double.PositiveInfinity,
                height=double.PositiveInfinity
            };
        public static RectDouble Zero =>
            new RectDouble();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator RectDouble(RectFloat rect) => 
            new RectDouble((double) rect.x, (double) rect.y, (double) rect.width, (double) rect.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator RectDouble(RectInt32 rect) => 
            new RectDouble((double) rect.x, (double) rect.y, (double) rect.width, (double) rect.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Ceiling(RectDouble rect) => 
            new RectInt32((int) Math.Ceiling(rect.x), (int) Math.Ceiling(rect.y), (int) Math.Ceiling(rect.width), (int) Math.Ceiling(rect.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Floor(RectDouble rect) => 
            new RectInt32((int) Math.Floor(rect.x), (int) Math.Floor(rect.y), (int) Math.Floor(rect.width), (int) Math.Floor(rect.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Round(RectDouble rect, MidpointRounding mode = 1) => 
            new RectInt32((int) Math.Round(rect.x, mode), (int) Math.Round(rect.y, mode), (int) Math.Round(rect.width, mode), (int) Math.Round(rect.height, mode));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Truncate(RectDouble rect) => 
            new RectInt32((int) Math.Truncate(rect.x), (int) Math.Truncate(rect.y), (int) Math.Truncate(rect.width), (int) Math.Truncate(rect.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble FromCenter(PointDouble center, SizeDouble size) => 
            FromCenter(center.x, center.y, size.width, size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble FromCenter(PointDouble center, double edgeLength) => 
            FromCenter(center.x, center.y, edgeLength, edgeLength);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble FromCenter(PointDouble center, double width, double height) => 
            FromCenter(center.x, center.y, width, height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble FromCenter(double centerX, double centerY, double edgeLength) => 
            FromCenter(centerX, centerY, edgeLength, edgeLength);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble FromCenter(double centerX, double centerY, double width, double height) => 
            new RectDouble(centerX - (width / 2.0), centerY - (height / 2.0), width, height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble FromCorners(PointDouble corner1, PointDouble corner2) => 
            FromEdges(corner1.X, corner1.Y, corner2.X, corner2.Y);

        public static RectDouble FromEdges(double left, double top, double right, double bottom)
        {
            double x = Math.Min(left, right);
            double y = Math.Min(top, bottom);
            double num3 = Math.Max(left, right);
            double num4 = Math.Max(top, bottom);
            return new RectDouble(x, y, num3 - x, num4 - y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble Inflate(RectDouble rect, double dx, double dy)
        {
            RectDouble num = rect;
            num.Inflate(dx, dy);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble Inflate(RectDouble rect, double left, double top, double right, double bottom) => 
            FromEdges(rect.Left - left, rect.Top - top, rect.Right + right, rect.Bottom + bottom);

        public static RectDouble Inflate(RectDouble rect, ThicknessDouble thickness) => 
            Inflate(rect, thickness.left, thickness.top, thickness.right, thickness.bottom);

        public static RectDouble Intersect(RectDouble a, RectDouble b)
        {
            double x = Math.Max(a.X, b.X);
            double num2 = Math.Min((double) (a.X + a.width), (double) (b.X + b.width));
            double y = Math.Max(a.Y, b.Y);
            double num4 = Math.Min((double) (a.Y + a.height), (double) (b.Y + b.height));
            if ((num2 >= x) && (num4 >= y))
            {
                return new RectDouble(x, y, num2 - x, num4 - y);
            }
            return Zero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble Offset(RectDouble rect, PointDouble offset) => 
            Offset(rect, offset.x, offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble Offset(RectDouble rect, VectorDouble offset) => 
            Offset(rect, offset.x, offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble Offset(RectDouble rect, double dx, double dy)
        {
            RectDouble num = rect;
            num.Offset(dx, dy);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble Scale(RectDouble rect, double scale) => 
            FromEdges(rect.Left * scale, rect.Top * scale, rect.Right * scale, rect.Bottom * scale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble Scale(RectDouble rect, double scaleX, double scaleY)
        {
            rect.Scale(scaleX, scaleY);
            return rect;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectDouble Union(RectDouble a, RectDouble b)
        {
            RectDouble num = a;
            num.Union(b);
            return num;
        }

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
        public double Width
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.width;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.width = value;
            }
        }
        public double Height
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.height;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.height = value;
            }
        }
        public double Left =>
            this.x;
        public double Top =>
            this.y;
        public double Right =>
            (this.x + this.width);
        public double Bottom =>
            (this.y + this.height);
        public PointDouble TopLeft =>
            new PointDouble(this.x, this.y);
        public PointDouble TopRight =>
            new PointDouble(this.x + this.width, this.y);
        public PointDouble BottomLeft =>
            new PointDouble(this.x, this.y + this.height);
        public PointDouble BottomRight =>
            new PointDouble(this.x + this.width, this.y + this.height);
        public PointDouble Center =>
            new PointDouble((this.Left + this.Right) / 2.0, (this.Top + this.Bottom) / 2.0);
        public PointDouble Location =>
            new PointDouble(this.x, this.y);
        public SizeDouble Size =>
            new SizeDouble { 
                width=this.width,
                height=this.height
            };
        public bool IsEmpty =>
            (this == Empty);
        public bool IsFinite =>
            (((this.x.IsFinite() && this.y.IsFinite()) && this.width.IsFinite()) && this.height.IsFinite());
        public bool IsInfinite =>
            ((double.IsPositiveInfinity(this.width) && (this.height != 0.0)) || (double.IsPositiveInfinity(this.height) && !(this.width == 0.0)));
        public bool IsZero =>
            (this == Zero);
        public double Area =>
            (this.width * this.height);
        public bool HasPositiveArea =>
            ((this.width > 0.0) && (this.height > 0.0));
        public RectInt32 Int32Bound =>
            this.GetInt32Bound(0.0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(double x, double y) => 
            ((((this.x <= x) && (x < (this.x + this.width))) && (this.y <= y)) && (y < (this.y + this.height)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(PointDouble pt) => 
            this.Contains(pt.x, pt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(RectDouble rect) => 
            ((((this.x <= rect.x) && ((rect.x + rect.width) <= (this.x + this.width))) && (this.y <= rect.y)) && ((rect.y + rect.height) <= (this.y + this.height)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RectInt32 GetFiniteInt32Bound(double epsilon) => 
            RectInt32.FromEdges((int) Math.Floor((double) (this.x + epsilon)), (int) Math.Floor((double) (this.y + epsilon)), (int) Math.Ceiling((double) ((this.x + this.width) - epsilon)), (int) Math.Ceiling((double) ((this.y + this.height) - epsilon)));

        public RectInt32 GetInt32Bound(double epsilon)
        {
            if (this.IsFinite)
            {
                return this.GetFiniteInt32Bound(epsilon);
            }
            if (this.IsInfinite)
            {
                return new RectInt32(-1073741824, -1073741824, 0x7fffffff, 0x7fffffff);
            }
            return RectInt32.Empty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Inflate(double dx, double dy)
        {
            this.x -= dx;
            this.y -= dy;
            this.width += 2.0 * dx;
            this.height += 2.0 * dy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Intersect(RectDouble rect)
        {
            RectDouble num = Intersect(rect, this);
            this.x = num.x;
            this.y = num.y;
            this.width = num.width;
            this.height = num.height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IntersectsWith(RectDouble rect) => 
            ((((rect.x < (this.x + this.width)) && (this.x < (rect.x + rect.width))) && (rect.y < (this.y + this.height))) && (this.y < (rect.y + rect.height)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Offset(double dx, double dy)
        {
            this.x += dx;
            this.y += dy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Offset(PointDouble dpt)
        {
            this.Offset(dpt.x, dpt.y);
        }

        public void Scale(double scaleX, double scaleY)
        {
            this.x *= scaleX;
            this.y *= scaleY;
            this.width *= scaleX;
            this.height *= scaleY;
            if (scaleX < 0.0)
            {
                this.x += this.width;
                this.width *= -1.0;
            }
            if (scaleY < 0.0)
            {
                this.y += this.height;
                this.height *= -1.0;
            }
        }

        public void Union(RectDouble rect)
        {
            if (this.IsEmpty)
            {
                this = rect;
            }
            else if (!rect.IsEmpty)
            {
                double num = Math.Min(this.Left, rect.Left);
                double num2 = Math.Min(this.Top, rect.Top);
                if ((rect.width == double.PositiveInfinity) || (this.width == double.PositiveInfinity))
                {
                    this.width = double.PositiveInfinity;
                }
                else
                {
                    double num3 = Math.Max(this.Right, rect.Right);
                    this.width = Math.Max((double) (num3 - num), (double) 0.0);
                }
                if ((rect.height == double.PositiveInfinity) || (this.height == double.PositiveInfinity))
                {
                    this.height = double.PositiveInfinity;
                }
                else
                {
                    double num4 = Math.Max(this.Bottom, rect.Bottom);
                    this.height = Math.Max((double) (num4 - num2), (double) 0.0);
                }
                this.x = num;
                this.y = num2;
            }
        }

        public RectDouble(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public RectDouble(PointDouble location, SizeDouble size)
        {
            this.x = location.x;
            this.y = location.y;
            this.width = size.width;
            this.height = size.height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(RectDouble other) => 
            ((((this.x == other.x) && (this.y == other.y)) && (this.width == other.width)) && (this.height == other.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<RectDouble, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(RectDouble lhs, RectDouble rhs) => 
            lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(RectDouble lhs, RectDouble rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x.GetHashCode(), this.y.GetHashCode(), this.width.GetHashCode(), this.height.GetHashCode());

        public static RectDouble Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static RectDouble Parse(string source, IFormatProvider formatProvider)
        {
            RectDouble empty;
            TokenizerHelper helper = new TokenizerHelper(source, formatProvider);
            string str = helper.NextTokenRequired();
            if (str == "Empty")
            {
                empty = Empty;
            }
            else
            {
                string str2 = helper.NextTokenRequired();
                string str3 = helper.NextTokenRequired();
                double x = Convert.ToDouble(str, formatProvider);
                double y = Convert.ToDouble(str2, formatProvider);
                double width = Convert.ToDouble(str3, formatProvider);
                double height = Convert.ToDouble(helper.NextTokenRequired(), formatProvider);
                empty = new RectDouble(x, y, width, height);
            }
            helper.LastTokenRequired();
            return empty;
        }

        RectDouble IParseString<RectDouble>.Parse(string source, IFormatProvider formatProvider) => 
            Parse(source, formatProvider);

        public override string ToString() => 
            this.ToString(null, null);

        public string ToString(IFormatProvider provider) => 
            this.ToString(null, provider);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this.IsEmpty)
            {
                return "Empty";
            }
            object[] fieldValues = new object[] { this.x, this.y, this.width, this.height };
            return TokenizerHelper.ConvertToString(format, formatProvider, fieldValues);
        }

        static RectDouble()
        {
            boxedZero = new RectDouble();
        }
    }
}

