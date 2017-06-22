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

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(StringBasedTypeConverter<Matrix3x2Double>)), ValueSerializer(typeof(StringBasedValueSerializer<Matrix3x2Double>)), DebuggerDisplay("{m11},{m12}, {m21},{m22}, {offsetX},{offsetY}")]
    public struct Matrix3x2Double : IMatrix3x2<double>, IEquatable<Matrix3x2Double>, IFormattable, IParseString<Matrix3x2Double>
    {
        private static readonly object boxedIdentity;
        internal double m11;
        internal double m12;
        internal double m21;
        internal double m22;
        internal double offsetX;
        internal double offsetY;
        public static object BoxedIdentity =>
            (boxedIdentity ?? Identity);
        public static Matrix3x2Double Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Matrix3x2Double num;
                Matrix3x2DoubleMath.Instance.CreateIdentity(out num);
                return num;
            }
        }
        public static Matrix3x2Double NaN
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Matrix3x2Double num;
                Matrix3x2DoubleMath.Instance.Create(double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, out num);
                return num;
            }
        }
        public double M11
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
        public double M12
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
        public double M21
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
        public double M22
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
        public double OffsetX
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
        public double OffsetY
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
            Matrix3x2DoubleMath.Instance.IsRectilinear(ref this);
        public bool IsTranslation =>
            Matrix3x2DoubleMath.Instance.IsTranslation(ref this);
        public bool IsIntegerTranslation =>
            Matrix3x2DoubleMath.Instance.IsIntegerTranslation(ref this);
        public double Determinant =>
            Matrix3x2DoubleMath.Instance.GetDeterminant(ref this);
        public bool HasInverse =>
            Matrix3x2DoubleMath.Instance.HasInverse(ref this);
        public Matrix3x2Double Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Matrix3x2Double num;
                Matrix3x2DoubleMath.Instance.GetInverse(ref this, out num);
                return num;
            }
        }
        public bool IsFinite =>
            Matrix3x2DoubleMath.Instance.IsFinite(ref this);
        public bool IsIdentity =>
            Matrix3x2DoubleMath.Instance.IsIdentity(ref this);
        public Matrix3x2Double(double m11, double m12, double m21, double m22, double offsetX, double offsetY)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m21 = m21;
            this.m22 = m22;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Matrix3x2Double other) => 
            Matrix3x2DoubleMath.Instance.Equals(ref this, ref other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<Matrix3x2Double, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix3x2Double a, Matrix3x2Double b) => 
            a.Equals(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Matrix3x2Double a, Matrix3x2Double b) => 
            !a.Equals(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => 
            Matrix3x2DoubleMath.Instance.GetHashCode(ref this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Matrix3x2Double(Matrix3x2Float matrix)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.Create((double) matrix.M11, (double) matrix.M12, (double) matrix.M21, (double) matrix.M22, (double) matrix.OffsetX, (double) matrix.OffsetY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double operator *(Matrix3x2Double a, Matrix3x2Double b) => 
            Multiply(a, b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Matrix3x2Double matrix)
        {
            this *= matrix;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invert()
        {
            this = this.Inverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double Multiply(Matrix3x2Double a, Matrix3x2Double b)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.Transform(ref a, ref b, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Prepend(Matrix3x2Double matrix)
        {
            this = matrix * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Rotate(double angle)
        {
            this *= Rotation(angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateAt(double angle, double centerX, double centerY)
        {
            this *= RotationAt(angle, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateAtByRadians(double radians, double centerX, double centerY)
        {
            this *= RotationAtByRadians(radians, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateByRadians(double radians)
        {
            this *= RotationByRadians(radians);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotatePrepend(double angle)
        {
            this = Rotation(angle) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateAtPrepend(double angle, double centerX, double centerY)
        {
            this = RotationAt(angle, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateAtByRadiansPrepend(double radians, double centerX, double centerY)
        {
            this = RotationAtByRadians(radians, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RotateByRadiansPrepend(double radians)
        {
            this = RotationByRadians(radians) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double Rotation(double angle)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateRotation(angle, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double RotationByRadians(double radians)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateRotationByRadians(radians, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double RotationAt(double angle, PointDouble centerPt) => 
            RotationAt(angle, centerPt.x, centerPt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double RotationAt(double angle, double centerX, double centerY)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateRotationAt(angle, centerX, centerY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double RotationAtByRadians(double radians, PointDouble centerPt) => 
            RotationAtByRadians(radians, centerPt.x, centerPt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double RotationAtByRadians(double radians, double centerX, double centerY)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateRotationAtByRadians(radians, centerX, centerY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(double scaleX, double scaleY)
        {
            this *= Scaling(scaleX, scaleY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ScaleAt(double scaleX, double scaleY, double centerX, double centerY)
        {
            this *= ScalingAt(scaleX, scaleY, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ScaleAtPrepend(double scaleX, double scaleY, double centerX, double centerY)
        {
            this = ScalingAt(scaleX, scaleY, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ScalePrepend(double scaleX, double scaleY)
        {
            this = Scaling(scaleX, scaleY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double Scaling(double scaleX, double scaleY)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateScaling(scaleX, scaleY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double ScalingAt(double scaleX, double scaleY, PointDouble centerPt) => 
            ScalingAt(scaleX, scaleY, centerPt.x, centerPt.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double ScalingAt(double scaleX, double scaleY, double centerX, double centerY)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateScalingAt(scaleX, scaleY, centerX, centerY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Skew(double skewAngleX, double skewAngleY)
        {
            this *= Skewing(skewAngleX, skewAngleY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewAt(double skewAngleX, double skewAngleY, double centerX, double centerY)
        {
            this *= SkewingAt(skewAngleX, skewAngleY, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewAtByRadians(double skewRadX, double skewRadY, double centerX, double centerY)
        {
            this *= SkewingAtByRadians(skewRadX, skewRadY, centerX, centerY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewByRadians(double skewRadX, double skewRadY)
        {
            this *= SkewingByRadians(skewRadX, skewRadY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewPrepend(double skewAngleX, double skewAngleY)
        {
            this = Skewing(skewAngleX, skewAngleY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewAtPrepend(double skewAngleX, double skewAngleY, double centerX, double centerY)
        {
            this = SkewingAt(skewAngleX, skewAngleY, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewAtByRadiansPrepend(double skewRadX, double skewRadY, double centerX, double centerY)
        {
            this = SkewingAtByRadians(skewRadX, skewRadY, centerX, centerY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkewByRadiansPrepend(double skewRadX, double skewRadY)
        {
            this = SkewingByRadians(skewRadX, skewRadY) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double Skewing(double skewAngleX, double skewAngleY)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateSkewing(skewAngleX, skewAngleY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double SkewingAt(double skewAngleX, double skewAngleY, double centerX, double centerY)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateSkewingAt(skewAngleX, skewAngleY, centerX, centerY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double SkewingByRadians(double skewRadX, double skewRadY)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateSkewingByRadians(skewRadX, skewRadY, out num);
            return num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double SkewingAtByRadians(double skewRadX, double skewRadY, double centerX, double centerY)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateSkewingAt(skewRadX, skewRadY, centerX, centerY, out num);
            return num;
        }

        public RectDouble Transform(RectDouble rect)
        {
            PointDouble num = this.Transform(rect.TopLeft);
            PointDouble num2 = this.Transform(rect.TopRight);
            PointDouble num3 = this.Transform(rect.BottomLeft);
            PointDouble num4 = this.Transform(rect.BottomRight);
            double x = Math.Min(num.X, Math.Min(num2.X, Math.Min(num3.X, num4.X)));
            double y = Math.Min(num.Y, Math.Min(num2.Y, Math.Min(num3.Y, num4.Y)));
            double num7 = Math.Max(num.X, Math.Max(num2.X, Math.Max(num3.X, num4.X)));
            double width = num7 - x;
            return new RectDouble(x, y, width, Math.Max(num.Y, Math.Max(num2.Y, Math.Max(num3.Y, num4.Y))) - y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PointDouble Transform(PointDouble pt) => 
            this.Transform(pt.X, pt.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public VectorDouble Transform(VectorDouble vec)
        {
            double num;
            double num2;
            Matrix3x2DoubleMath.Instance.TransformVector(ref this, vec.X, vec.Y, out num, out num2);
            return new VectorDouble(num, num2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PointDouble Transform(double x, double y)
        {
            double num;
            double num2;
            Matrix3x2DoubleMath.Instance.TransformPoint(ref this, x, y, out num, out num2);
            return new PointDouble(num, num2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Translate(double dx, double dy)
        {
            this *= Translation(dx, dy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TranslatePrepend(double dx, double dy)
        {
            this = Translation(dx, dy) * this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3x2Double Translation(double dx, double dy)
        {
            Matrix3x2Double num;
            Matrix3x2DoubleMath.Instance.CreateTranslation(dx, dy, out num);
            return num;
        }

        public static Matrix3x2Double Parse(string source) => 
            Parse(source, PaintDotNet.Markup.TypeConverterHelper.InvariantEnglishUS);

        public static Matrix3x2Double Parse(string source, IFormatProvider formatProvider)
        {
            Matrix3x2Double identity;
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
                double num2 = Convert.ToDouble(str, formatProvider);
                double num3 = Convert.ToDouble(str2, formatProvider);
                double num4 = Convert.ToDouble(str3, formatProvider);
                double num5 = Convert.ToDouble(str4, formatProvider);
                double offsetX = Convert.ToDouble(str5, formatProvider);
                double offsetY = Convert.ToDouble(helper.NextTokenRequired(), formatProvider);
                identity = new Matrix3x2Double(num2, num3, num4, num5, offsetX, offsetY);
            }
            helper.LastTokenRequired();
            return identity;
        }

        Matrix3x2Double IParseString<Matrix3x2Double>.Parse(string source, IFormatProvider formatProvider) => 
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

        static Matrix3x2Double()
        {
            boxedIdentity = Identity;
        }
        private static class Matrix3x2DoubleMath
        {
            public static Matrix3x2Math<double, DoubleMath, Matrix3x2Double> Instance;
        }
    }
}

