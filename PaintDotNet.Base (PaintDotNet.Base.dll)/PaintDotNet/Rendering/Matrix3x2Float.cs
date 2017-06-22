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

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<Matrix3x2Float>)), ValueSerializer(typeof(StringBasedValueSerializer<Matrix3x2Float>)), DebuggerDisplay("{m11},{m12}, {m21},{m22}, {offsetX},{offsetY}")]
    public struct Matrix3x2Float : IMatrix3x2<float>, IEquatable<Matrix3x2Float>, IFormattable, IParseString<Matrix3x2Float>
    {
        private static readonly object boxedIdentity;
        internal float m11;
        internal float m12;
        internal float m21;
        internal float m22;
        internal float offsetX;
        internal float offsetY;
        public static object BoxedIdentity =>
            (boxedIdentity ?? Identity);
        public static Matrix3x2Float Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Matrix3x2Float num;
                Matrix3x2FloatMath.Instance.CreateIdentity(out num);
                return num;
            }
        }
        public static Matrix3x2Float NaN
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Matrix3x2Float num;
                Matrix3x2FloatMath.Instance.Create(float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, out num);
                return num;
            }
        }
        public float M11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.m11;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.m11 = value;
            }
        }
        public float M12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.m12;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.m12 = value;
            }
        }
        public float M21
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.m21;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.m21 = value;
            }
        }
        public float M22
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.m22;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.m22 = value;
            }
        }
        public float OffsetX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.offsetX;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.offsetX = value;
            }
        }
        public float OffsetY
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.offsetY;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.offsetY = value;
            }
        }
        public bool IsRectilinear =>
            Matrix3x2FloatMath.Instance.IsRectilinear(ref this);
        public bool IsTranslation =>
            Matrix3x2FloatMath.Instance.IsTranslation(ref this);
        public bool IsIntegerTranslation =>
            Matrix3x2FloatMath.Instance.IsIntegerTranslation(ref this);
        public float Determinant =>
            Matrix3x2FloatMath.Instance.GetDeterminant(ref this);
        public bool HasInverse =>
            Matrix3x2FloatMath.Instance.HasInverse(ref this);
        public Matrix3x2Float Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Matrix3x2Float num;
                Matrix3x2FloatMath.Instance.GetInverse(ref this, out num);
                return num;
            }
        }
        public bool IsFinite =>
            Matrix3x2FloatMath.Instance.IsFinite(ref this);
        public bool IsIdentity =>
            Matrix3x2FloatMath.Instance.IsIdentity(ref this);
        public Matrix3x2Float(float m11, float m12, float m21, float m22, float offsetX, float offsetY)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m21 = m21;
            this.m22 = m22;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Matrix3x2Float other) => 
            Matrix3x2FloatMath.Instance.Equals(ref this, ref other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<Matrix3x2Float, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix3x2Float a, Matrix3x2Float b) => 
            a.Equals(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Matrix3x2Float a, Matrix3x2Float b) => 
            !a.Equals(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => 
            Matrix3x2FloatMath.Instance.GetHashCode(ref this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Matrix3x2Float(Matrix3x2Double matrix)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.Create((float) matrix.M11, (float) matrix.M12, (float) matrix.M21, (float) matrix.M22, (float) matrix.OffsetX, (float) matrix.OffsetY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float operator *(Matrix3x2Float a, Matrix3x2Float b) => 
            Multiply(a, b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Matrix3x2Float matrix)
        {
            this *= matrix;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invert()
        {
            this = this.Inverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float Multiply(Matrix3x2Float a, Matrix3x2Float b)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.Transform(ref a, ref b, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Prepend(Matrix3x2Float matrix)
        {
            this = matrix * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Rotate(float angle)
        {
            this *= Rotation(angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateAt(float angle, float centerX, float centerY)
        {
            this *= RotationAt(angle, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateAtByRadians(float radians, float centerX, float centerY)
        {
            this *= RotationAtByRadians(radians, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateByRadians(float radians)
        {
            this *= RotationByRadians(radians);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotatePrepend(float angle)
        {
            this = Rotation(angle) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateAtPrepend(float angle, float centerX, float centerY)
        {
            this = RotationAt(angle, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateAtByRadiansPrepend(float radians, float centerX, float centerY)
        {
            this = RotationAtByRadians(radians, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateByRadiansPrepend(float radians)
        {
            this = RotationByRadians(radians) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float Rotation(float angle)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateRotation(angle, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float RotationByRadians(float radians)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateRotationByRadians(radians, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float RotationAt(float angle, PointFloat centerPt) => 
            RotationAt(angle, centerPt.x, centerPt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float RotationAt(float angle, float centerX, float centerY)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateRotationAt(angle, centerX, centerY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float RotationAtByRadians(float radians, PointFloat centerPt) => 
            RotationAtByRadians(radians, centerPt.x, centerPt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float RotationAtByRadians(float radians, float centerX, float centerY)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateRotationAtByRadians(radians, centerX, centerY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(float scaleX, float scaleY)
        {
            this *= Scaling(scaleX, scaleY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ScaleAt(float scaleX, float scaleY, float centerX, float centerY)
        {
            this *= ScalingAt(scaleX, scaleY, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ScaleAtPrepend(float scaleX, float scaleY, float centerX, float centerY)
        {
            this = ScalingAt(scaleX, scaleY, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ScalePrepend(float scaleX, float scaleY)
        {
            this = Scaling(scaleX, scaleY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float Scaling(float scaleX, float scaleY)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateScaling(scaleX, scaleY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float ScalingAt(float scaleX, float scaleY, PointFloat centerPt) => 
            ScalingAt(scaleX, scaleY, centerPt.x, centerPt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float ScalingAt(float scaleX, float scaleY, float centerX, float centerY)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateScalingAt(scaleX, scaleY, centerX, centerY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Skew(float skewAngleX, float skewAngleY)
        {
            this *= Skewing(skewAngleX, skewAngleY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewAt(float skewAngleX, float skewAngleY, float centerX, float centerY)
        {
            this *= SkewingAt(skewAngleX, skewAngleY, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewAtByRadians(float skewRadX, float skewRadY, float centerX, float centerY)
        {
            this *= SkewingAtByRadians(skewRadX, skewRadY, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewByRadians(float skewRadX, float skewRadY)
        {
            this *= SkewingByRadians(skewRadX, skewRadY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewPrepend(float skewAngleX, float skewAngleY)
        {
            this = Skewing(skewAngleX, skewAngleY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewAtPrepend(float skewAngleX, float skewAngleY, float centerX, float centerY)
        {
            this = SkewingAt(skewAngleX, skewAngleY, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewAtByRadiansPrepend(float skewRadX, float skewRadY, float centerX, float centerY)
        {
            this = SkewingAtByRadians(skewRadX, skewRadY, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewByRadiansPrepend(float skewRadX, float skewRadY)
        {
            this = SkewingByRadians(skewRadX, skewRadY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float Skewing(float skewAngleX, float skewAngleY)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateSkewing(skewAngleX, skewAngleY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float SkewingAt(float skewAngleX, float skewAngleY, float centerX, float centerY)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateSkewingAt(skewAngleX, skewAngleY, centerX, centerY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float SkewingByRadians(float skewRadX, float skewRadY)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateSkewingByRadians(skewRadX, skewRadY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float SkewingAtByRadians(float skewRadX, float skewRadY, float centerX, float centerY)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateSkewingAt(skewRadX, skewRadY, centerX, centerY, out num);
            return num;
        }

        public RectFloat Transform(RectFloat rect)
        {
            PointFloat num = this.Transform(rect.TopLeft);
            PointFloat num2 = this.Transform(rect.TopRight);
            PointFloat num3 = this.Transform(rect.BottomLeft);
            PointFloat num4 = this.Transform(rect.BottomRight);
            float x = Math.Min(num.X, Math.Min(num2.X, Math.Min(num3.X, num4.X)));
            float y = Math.Min(num.Y, Math.Min(num2.Y, Math.Min(num3.Y, num4.Y)));
            float num7 = Math.Max(num.X, Math.Max(num2.X, Math.Max(num3.X, num4.X)));
            float width = num7 - x;
            return new RectFloat(x, y, width, Math.Max(num.Y, Math.Max(num2.Y, Math.Max(num3.Y, num4.Y))) - y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PointFloat Transform(PointFloat pt) => 
            this.Transform(pt.X, pt.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public VectorFloat Transform(VectorFloat vec)
        {
            float num;
            float num2;
            Matrix3x2FloatMath.Instance.TransformVector(ref this, vec.X, vec.Y, out num, out num2);
            return new VectorFloat(num, num2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PointFloat Transform(float x, float y)
        {
            float num;
            float num2;
            Matrix3x2FloatMath.Instance.TransformPoint(ref this, x, y, out num, out num2);
            return new PointFloat(num, num2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Translate(float dx, float dy)
        {
            this *= Translation(dx, dy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TranslatePrepend(float dx, float dy)
        {
            this = Translation(dx, dy) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Float Translation(float dx, float dy)
        {
            Matrix3x2Float num;
            Matrix3x2FloatMath.Instance.CreateTranslation(dx, dy, out num);
            return num;
        }

        public static Matrix3x2Float Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static Matrix3x2Float Parse(string source, IFormatProvider formatProvider)
        {
            Matrix3x2Float identity;
            TokenizerHelper helper = new TokenizerHelper(source, formatProvider);
            string str = helper.NextTokenRequired();
            if (str == "Identity")
            {
                identity = Identity;
            }
            else
            {
                string str2 = helper.NextTokenRequired();
                string str3 = helper.NextTokenRequired();
                string str4 = helper.NextTokenRequired();
                string str5 = helper.NextTokenRequired();
                float num2 = Convert.ToSingle(str, formatProvider);
                float num3 = Convert.ToSingle(str2, formatProvider);
                float num4 = Convert.ToSingle(str3, formatProvider);
                float num5 = Convert.ToSingle(str4, formatProvider);
                float offsetX = Convert.ToSingle(str5, formatProvider);
                float offsetY = Convert.ToSingle(helper.NextTokenRequired(), formatProvider);
                identity = new Matrix3x2Float(num2, num3, num4, num5, offsetX, offsetY);
            }
            helper.LastTokenRequired();
            return identity;
        }

        Matrix3x2Float IParseString<Matrix3x2Float>.Parse(string source, IFormatProvider formatProvider) => 
            Parse(source, formatProvider);

        public override string ToString() => 
            this.ToString(null, null);

        public string ToString(IFormatProvider provider) => 
            this.ToString(null, provider);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this.IsIdentity)
            {
                return "Identity";
            }
            object[] fieldValues = new object[] { this.m11, this.m12, this.m21, this.m22, this.offsetX, this.offsetY };
            return TokenizerHelper.ConvertToString(format, formatProvider, fieldValues);
        }

        static Matrix3x2Float()
        {
            boxedIdentity = Identity;
        }
        private static class Matrix3x2FloatMath
        {
            public static Matrix3x2Math<float, FloatMath, Matrix3x2Float> Instance;
        }
    }
}

