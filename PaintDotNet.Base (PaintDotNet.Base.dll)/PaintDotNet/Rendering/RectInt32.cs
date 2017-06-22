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

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<RectInt32>)), ValueSerializer(typeof(StringBasedValueSerializer<RectInt32>)), DebuggerDisplay("{x},{y},{width},{height}")]
    public struct RectInt32 : IEquatable<RectInt32>, IFormattable, IParseString<RectInt32>
    {
        private static readonly object boxedZero;
        internal int x;
        internal int y;
        internal int width;
        internal int height;
        public static object BoxedZero =>
            (boxedZero ?? new RectInt32());
        public static RectInt32 Empty =>
            new RectInt32 { 
                x=0x7fffffff,
                y=0x7fffffff,
                width=-2147483648,
                height=-2147483648
            };
        public static RectInt32 Zero =>
            new RectInt32();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 FromCorners(PointInt32 corner1, PointInt32 corner2) => 
            FromEdges(corner1.x, corner1.y, corner2.x, corner2.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 FromEdges(int left, int top, int right, int bottom)
        {
            int x = Math.Min(left, right);
            int y = Math.Min(top, bottom);
            int num3 = Math.Max(left, right);
            int num4 = Math.Max(top, bottom);
            return new RectInt32(x, y, num3 - x, num4 - y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Inflate(RectInt32 rect, int dx, int dy)
        {
            RectInt32 num = rect;
            num.Inflate(dx, dy);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Inflate(RectInt32 rect, int left, int top, int right, int bottom) => 
            FromEdges(rect.Left - left, rect.Top - top, rect.Right + right, rect.Bottom + bottom);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Intersect(RectInt32 a, RectInt32 b)
        {
            RectInt32 num = a;
            num.Intersect(b);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Offset(RectInt32 rect, PointInt32 offset) => 
            Offset(rect, offset.x, offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Offset(RectInt32 rect, VectorInt32 offset) => 
            Offset(rect, offset.x, offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Offset(RectInt32 rect, int dx, int dy) => 
            new RectInt32(rect.x + dx, rect.y + dy, rect.width, rect.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Scale(RectInt32 rect, int scale) => 
            Scale(rect, scale, scale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Scale(RectInt32 rect, int scaleX, int scaleY)
        {
            rect.Scale(scaleX, scaleY);
            return rect;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Union(RectInt32 a, RectInt32 b)
        {
            RectInt32 num = a;
            num.Union(b);
            return num;
        }

        public int X
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
        public int Y
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
        public int Width
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
        public int Height
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
        public int Left =>
            this.x;
        public int Top =>
            this.y;
        public int Right =>
            (this.x + this.width);
        public int Bottom =>
            (this.y + this.height);
        public PointInt32 TopLeft =>
            new PointInt32(this.x, this.y);
        public PointInt32 TopRight =>
            new PointInt32(this.x + this.width, this.y);
        public PointInt32 BottomLeft =>
            new PointInt32(this.x, this.y + this.height);
        public PointInt32 BottomRight =>
            new PointInt32(this.x + this.width, this.y + this.height);
        public PointInt32 Location =>
            new PointInt32(this.x, this.y);
        public SizeInt32 Size =>
            new SizeInt32 { 
                width=this.width,
                height=this.height
            };
        public bool IsEmpty =>
            (this == Empty);
        public bool IsZero =>
            (this == Zero);
        public long Area =>
            (this.width * this.height);
        public bool HasPositiveArea =>
            ((this.width > 0) && (this.height > 0));
        public bool HasZeroArea
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (this.width != 0)
                {
                    return (this.height == 0);
                }
                return true;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(int x, int y) => 
            ((((this.x <= x) && (x < (this.x + this.width))) && (this.y <= y)) && (y < (this.y + this.height)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(PointInt32 pt) => 
            this.Contains(pt.X, pt.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(RectInt32 rect) => 
            ((((this.x <= rect.x) && ((rect.X + rect.width) <= (this.x + this.width))) && (this.y <= rect.y)) && ((rect.Y + rect.height) <= (this.y + this.height)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(RectDouble rect)
        {
            RectDouble num = this;
            return num.Contains(rect);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Inflate(int dx, int dy)
        {
            this.x -= dx;
            this.y -= dy;
            this.width += 2 * dx;
            this.height += 2 * dy;
        }

        public void Intersect(RectInt32 rect)
        {
            int num = Math.Max(this.x, rect.x);
            int num2 = Math.Max(this.y, rect.y);
            int num3 = Math.Max(Math.Min(this.Right, rect.Right) - num, 0);
            int num4 = Math.Max(Math.Min(this.Bottom, rect.Bottom) - num2, 0);
            this.x = num;
            this.y = num2;
            this.width = num3;
            this.height = num4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IntersectsWith(RectInt32 rect)
        {
            if ((this.x >= (rect.x + rect.width)) || (rect.x >= (this.x + this.width)))
            {
                return false;
            }
            return ((this.y < (rect.y + rect.height)) && (rect.y < (this.y + this.height)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Offset(PointInt32 delta)
        {
            this.x += delta.X;
            this.y += delta.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Offset(int dx, int dy)
        {
            this.x += dx;
            this.y += dy;
        }

        public void Scale(int scaleX, int scaleY)
        {
            this.x *= scaleX;
            this.y *= scaleY;
            this.width *= scaleX;
            this.height *= scaleY;
            if (scaleX < 0)
            {
                this.x += this.width;
                this.width *= -1;
            }
            if (scaleY < 0)
            {
                this.y += this.height;
                this.height *= -1;
            }
        }

        public void Union(RectInt32 rect)
        {
            int num = Math.Min(this.Left, rect.Left);
            int num2 = Math.Min(this.Top, rect.Top);
            int num3 = Math.Max(this.Right, rect.Right);
            int num4 = Math.Max(this.Bottom, rect.Bottom);
            this.x = num;
            this.y = num2;
            this.width = num3 - num;
            this.height = num4 - num2;
        }

        public RectInt32(PointInt32 location, SizeInt32 size)
        {
            this.x = location.x;
            this.y = location.y;
            this.width = size.width;
            this.height = size.height;
        }

        public RectInt32(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(RectInt32 other) => 
            ((((this.x == other.x) && (this.y == other.y)) && (this.width == other.width)) && (this.height == other.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<RectInt32, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(RectInt32 a, RectInt32 b) => 
            a.Equals(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(RectInt32 a, RectInt32 b) => 
            !a.Equals(b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x.GetHashCode(), this.y.GetHashCode(), this.width.GetHashCode(), this.height.GetHashCode());

        public static RectInt32 Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static RectInt32 Parse(string source, IFormatProvider formatProvider)
        {
            RectInt32 empty;
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
                int x = Convert.ToInt32(str, formatProvider);
                int y = Convert.ToInt32(str2, formatProvider);
                int width = Convert.ToInt32(str3, formatProvider);
                int height = Convert.ToInt32(helper.NextTokenRequired(), formatProvider);
                empty = new RectInt32(x, y, width, height);
            }
            helper.LastTokenRequired();
            return empty;
        }

        RectInt32 IParseString<RectInt32>.Parse(string source, IFormatProvider formatProvider) => 
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

        static RectInt32()
        {
            boxedZero = new RectInt32();
        }
    }
}

