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

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<RectFloat>)), ValueSerializer(typeof(StringBasedValueSerializer<RectFloat>)), DebuggerDisplay("{x},{y},{width},{height}")]
    public struct RectFloat : IEquatable<RectFloat>, IFormattable, IParseString<RectFloat>
    {
        private static readonly object boxedZero;
        internal float x;
        internal float y;
        internal float width;
        internal float height;
        public static object BoxedZero =>
            (boxedZero ?? new RectFloat());
        public static RectFloat Empty =>
            new RectFloat { 
                x=float.PositiveInfinity,
                y=float.PositiveInfinity,
                width=float.NegativeInfinity,
                height=float.NegativeInfinity
            };
        public static RectFloat Infinite =>
            new RectFloat { 
                x=float.NegativeInfinity,
                y=float.NegativeInfinity,
                width=float.PositiveInfinity,
                height=float.PositiveInfinity
            };
        public static RectFloat Zero =>
            new RectFloat();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator RectFloat(RectDouble rect) => 
            new RectFloat((float) rect.x, (float) rect.y, (float) rect.width, (float) rect.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator RectFloat(RectInt32 rect) => 
            new RectFloat((float) rect.x, (float) rect.y, (float) rect.width, (float) rect.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Ceiling(RectFloat rect) => 
            new RectInt32((int) Math.Ceiling((double) rect.x), (int) Math.Ceiling((double) rect.y), (int) Math.Ceiling((double) rect.width), (int) Math.Ceiling((double) rect.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Floor(RectFloat rect) => 
            new RectInt32((int) Math.Floor((double) rect.x), (int) Math.Floor((double) rect.y), (int) Math.Floor((double) rect.width), (int) Math.Floor((double) rect.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Round(RectFloat rect, MidpointRounding mode = 1) => 
            new RectInt32((int) Math.Round((double) rect.x, mode), (int) Math.Round((double) rect.y, mode), (int) Math.Round((double) rect.width, mode), (int) Math.Round((double) rect.height, mode));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectInt32 Truncate(RectFloat rect) => 
            new RectInt32((int) Math.Truncate((double) rect.x), (int) Math.Truncate((double) rect.y), (int) Math.Truncate((double) rect.width), (int) Math.Truncate((double) rect.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat FromCenter(PointFloat center, SizeFloat size) => 
            FromCenter(center.x, center.y, size.width, size.height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat FromCenter(PointFloat center, float edgeLength) => 
            FromCenter(center.x, center.y, edgeLength);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat FromCenter(PointFloat center, float width, float height) => 
            FromCenter(center.x, center.y, width, height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat FromCenter(float centerX, float centerY, float edgeLength) => 
            FromCenter(centerX, centerY, edgeLength, edgeLength);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat FromCenter(float centerX, float centerY, float width, float height) => 
            new RectFloat(centerX - (width / 2f), centerY - (height / 2f), width, height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat FromCorners(PointFloat corner1, PointFloat corner2) => 
            FromEdges(corner1.x, corner1.y, corner2.x, corner2.y);

        public static RectFloat FromEdges(float left, float top, float right, float bottom)
        {
            float x = Math.Min(left, right);
            float y = Math.Min(top, bottom);
            float num3 = Math.Max(left, right);
            float num4 = Math.Max(top, bottom);
            return new RectFloat(x, y, num3 - x, num4 - y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat Inflate(RectFloat rect, float dx, float dy)
        {
            RectFloat num = rect;
            num.Inflate(dx, dy);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat Inflate(RectFloat rect, float left, float top, float right, float bottom) => 
            FromEdges(rect.Left - left, rect.Top - top, rect.Right + right, rect.Bottom + bottom);

        public static RectFloat Intersect(RectFloat a, RectFloat b)
        {
            float x = Math.Max(a.x, b.x);
            float num2 = Math.Min((float) (a.x + a.width), (float) (b.x + b.width));
            float y = Math.Max(a.y, b.y);
            float num4 = Math.Min((float) (a.y + a.height), (float) (b.y + b.height));
            if ((num2 >= x) && (num4 >= y))
            {
                return new RectFloat(x, y, num2 - x, num4 - y);
            }
            return Zero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat Offset(RectFloat rect, PointFloat offset) => 
            Offset(rect, offset.x, offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat Offset(RectFloat rect, VectorFloat offset) => 
            Offset(rect, offset.x, offset.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat Offset(RectFloat rect, float dx, float dy)
        {
            RectFloat num = rect;
            num.Offset(dx, dy);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat Scale(RectFloat rect, float scale) => 
            FromEdges(rect.Left * scale, rect.Top * scale, rect.Right * scale, rect.Bottom * scale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat Scale(RectFloat rect, float scaleX, float scaleY)
        {
            rect.Scale(scaleX, scaleY);
            return rect;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectFloat Union(RectFloat a, RectFloat b)
        {
            RectFloat num = a;
            num.Union(b);
            return num;
        }

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
        public float Width
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
        public float Height
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
        public float Left =>
            this.x;
        public float Top =>
            this.y;
        public float Right =>
            (this.x + this.width);
        public float Bottom =>
            (this.y + this.height);
        public PointFloat TopLeft =>
            new PointFloat(this.x, this.y);
        public PointFloat TopRight =>
            new PointFloat(this.x + this.width, this.y);
        public PointFloat BottomLeft =>
            new PointFloat(this.x, this.y + this.height);
        public PointFloat BottomRight =>
            new PointFloat(this.x + this.width, this.y + this.height);
        public PointFloat Center =>
            new PointFloat((this.Left + this.Right) / 2f, (this.Top + this.Bottom) / 2f);
        public PointFloat Location =>
            new PointFloat(this.x, this.y);
        public SizeFloat Size =>
            new SizeFloat { 
                width=this.width,
                height=this.height
            };
        public bool IsEmpty =>
            (this == Empty);
        public bool IsFinite =>
            (((this.x.IsFinite() && this.y.IsFinite()) && this.width.IsFinite()) && this.height.IsFinite());
        public bool IsInfinite =>
            ((float.IsPositiveInfinity(this.width) && (this.height != 0f)) || (float.IsPositiveInfinity(this.height) && !(this.width == 0f)));
        public bool IsZero =>
            (this == Zero);
        public float Area =>
            (this.width * this.height);
        public bool HasPositiveArea =>
            ((this.width > 0f) && (this.height > 0f));
        public RectInt32 Int32Bound =>
            this.GetInt32Bound(0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(float x, float y) => 
            ((((this.x <= x) && (x < (this.x + this.width))) && (this.y <= y)) && (y < (this.y + this.height)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(PointFloat pt) => 
            this.Contains(pt.X, pt.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(RectFloat rect) => 
            ((((this.x <= rect.x) && ((rect.x + rect.width) <= (this.x + this.width))) && (this.y <= rect.y)) && ((rect.y + rect.height) <= (this.y + this.height)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RectInt32 GetFiniteInt32Bound(float epsilon) => 
            RectInt32.FromEdges((int) Math.Floor((double) (this.x + epsilon)), (int) Math.Floor((double) (this.y + epsilon)), (int) Math.Ceiling((double) ((this.x + this.width) - epsilon)), (int) Math.Ceiling((double) ((this.y + this.height) - epsilon)));

        public RectInt32 GetInt32Bound(float epsilon)
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
        public void Inflate(float dx, float dy)
        {
            this.x -= dx;
            this.y -= dy;
            this.width += 2f * dx;
            this.height += 2f * dy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Intersect(RectFloat rect)
        {
            RectFloat num = Intersect(rect, this);
            this.x = num.x;
            this.y = num.y;
            this.width = num.width;
            this.height = num.height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IntersectsWith(RectFloat rect) => 
            ((((rect.x < (this.x + this.width)) && (this.x < (rect.x + rect.width))) && (rect.Y < (this.y + this.height))) && (this.y < (rect.y + rect.height)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Offset(float dx, float dy)
        {
            this.x += dx;
            this.y += dy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Offset(PointFloat dpt)
        {
            this.Offset(dpt.X, dpt.Y);
        }

        public void Scale(float scaleX, float scaleY)
        {
            this.x *= scaleX;
            this.y *= scaleY;
            this.width *= scaleX;
            this.height *= scaleY;
            if (scaleX < 0f)
            {
                this.x += this.width;
                this.width *= -1f;
            }
            if (scaleY < 0f)
            {
                this.y += this.height;
                this.height *= -1f;
            }
        }

        public void Union(RectFloat rect)
        {
            if (this.IsEmpty)
            {
                this = rect;
            }
            else if (!rect.IsEmpty)
            {
                float num = Math.Min(this.Left, rect.Left);
                float num2 = Math.Min(this.Top, rect.Top);
                if ((rect.width == float.PositiveInfinity) || (this.width == float.PositiveInfinity))
                {
                    this.width = float.PositiveInfinity;
                }
                else
                {
                    float num3 = Math.Max(this.Right, rect.Right);
                    this.width = Math.Max((float) (num3 - num), (float) 0f);
                }
                if ((rect.height == double.PositiveInfinity) || (this.height == double.PositiveInfinity))
                {
                    this.height = float.PositiveInfinity;
                }
                else
                {
                    float num4 = Math.Max(this.Bottom, rect.Bottom);
                    this.height = Math.Max((float) (num4 - num2), (float) 0f);
                }
                this.x = num;
                this.y = num2;
            }
        }

        public RectFloat(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public RectFloat(PointFloat location, SizeFloat size)
        {
            this.x = location.X;
            this.y = location.Y;
            this.width = size.Width;
            this.height = size.Height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(RectFloat other) => 
            ((((this.x == other.x) && (this.y == other.y)) && (this.width == other.width)) && (this.height == other.height));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<RectFloat, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(RectFloat lhs, RectFloat rhs) => 
            lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(RectFloat lhs, RectFloat rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.x.GetHashCode(), this.y.GetHashCode(), this.width.GetHashCode(), this.height.GetHashCode());

        public static RectFloat Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static RectFloat Parse(string source, IFormatProvider formatProvider)
        {
            RectFloat empty;
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
                float x = Convert.ToSingle(str, formatProvider);
                float y = Convert.ToSingle(str2, formatProvider);
                float width = Convert.ToSingle(str3, formatProvider);
                float height = Convert.ToSingle(helper.NextTokenRequired(), formatProvider);
                empty = new RectFloat(x, y, width, height);
            }
            helper.LastTokenRequired();
            return empty;
        }

        RectFloat IParseString<RectFloat>.Parse(string source, IFormatProvider formatProvider) => 
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

        static RectFloat()
        {
            boxedZero = new RectFloat();
        }
    }
}

