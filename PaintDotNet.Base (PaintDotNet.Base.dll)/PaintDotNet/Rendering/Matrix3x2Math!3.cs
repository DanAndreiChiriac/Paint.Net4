namespace PaintDotNet.Rendering
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    internal struct Matrix3x2Math<T, TRealMath, TMatrix> : IMatrix3x2Math<T, TRealMath, TMatrix>, IEqualityComparerByRef<TMatrix>, IEqualityComparer<TMatrix> where TRealMath: struct, IRealMath<T> where TMatrix: struct, IMatrix3x2<T>
    {
        private static TRealMath math;
        private static T zero;
        private static T one;
        static Matrix3x2Math()
        {
            Matrix3x2Math<T, TRealMath, TMatrix>.math = Activator.CreateInstance<TRealMath>();
            Matrix3x2Math<T, TRealMath, TMatrix>.zero = Matrix3x2Math<T, TRealMath, TMatrix>.math.Zero;
            Matrix3x2Math<T, TRealMath, TMatrix>.one = Matrix3x2Math<T, TRealMath, TMatrix>.math.One;
        }

        public void Copy(ref TMatrix m, out TMatrix result)
        {
            this.CreateZero(out result);
            result.M11 = m.M11;
            result.M12 = m.M12;
            result.M21 = m.M21;
            result.M22 = m.M22;
            result.OffsetX = m.OffsetX;
            result.OffsetY = m.OffsetY;
        }

        public void Create(T m11, T m12, T m21, T m22, T offsetX, T offsetY, out TMatrix m)
        {
            this.CreateZero(out m);
            m.M11 = m11;
            m.M12 = m12;
            m.M21 = m21;
            m.M22 = m22;
            m.OffsetX = offsetX;
            m.OffsetY = offsetY;
        }

        public void CreateIdentity(out TMatrix m)
        {
            this.Create(Matrix3x2Math<T, TRealMath, TMatrix>.one, Matrix3x2Math<T, TRealMath, TMatrix>.zero, Matrix3x2Math<T, TRealMath, TMatrix>.zero, Matrix3x2Math<T, TRealMath, TMatrix>.one, Matrix3x2Math<T, TRealMath, TMatrix>.zero, Matrix3x2Math<T, TRealMath, TMatrix>.zero, out m);
        }

        public void CreateRotation(T angle, out TMatrix m)
        {
            if (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(angle, Matrix3x2Math<T, TRealMath, TMatrix>.zero))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                T radians = Matrix3x2Math<T, TRealMath, TMatrix>.math.DegreesToRadians<T, TRealMath>(angle);
                this.CreateRotationByRadians(radians, out m);
            }
        }

        public void CreateRotationByRadians(T radians, out TMatrix m)
        {
            if (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(radians, Matrix3x2Math<T, TRealMath, TMatrix>.zero))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                T local = Matrix3x2Math<T, TRealMath, TMatrix>.math.Sin(radians);
                T local2 = Matrix3x2Math<T, TRealMath, TMatrix>.math.Cos(radians);
                this.Create(local2, local, Matrix3x2Math<T, TRealMath, TMatrix>.math.Negate(local), local2, Matrix3x2Math<T, TRealMath, TMatrix>.zero, Matrix3x2Math<T, TRealMath, TMatrix>.zero, out m);
            }
        }

        public void CreateRotationAt(T angle, T centerX, T centerY, out TMatrix m)
        {
            if ((Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(angle, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerX, Matrix3x2Math<T, TRealMath, TMatrix>.zero)) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerY, Matrix3x2Math<T, TRealMath, TMatrix>.zero))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                T radians = Matrix3x2Math<T, TRealMath, TMatrix>.math.DegreesToRadians<T, TRealMath>(angle);
                this.CreateRotationAtByRadians(radians, centerX, centerY, out m);
            }
        }

        public void CreateRotationAtByRadians(T radians, T centerX, T centerY, out TMatrix m)
        {
            if ((Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(radians, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerX, Matrix3x2Math<T, TRealMath, TMatrix>.zero)) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerY, Matrix3x2Math<T, TRealMath, TMatrix>.zero))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                T b = Matrix3x2Math<T, TRealMath, TMatrix>.math.Sin(radians);
                T local2 = Matrix3x2Math<T, TRealMath, TMatrix>.math.Cos(radians);
                T local3 = Matrix3x2Math<T, TRealMath, TMatrix>.math.Subtract(Matrix3x2Math<T, TRealMath, TMatrix>.one, local2);
                T offsetX = Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(centerX, local3), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(centerY, b));
                T offsetY = Matrix3x2Math<T, TRealMath, TMatrix>.math.Subtract(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(centerY, local3), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(centerX, b));
                this.Create(local2, b, Matrix3x2Math<T, TRealMath, TMatrix>.math.Negate(b), local2, offsetX, offsetY, out m);
            }
        }

        public void CreateScaling(T scaleX, T scaleY, out TMatrix m)
        {
            if (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(scaleX, Matrix3x2Math<T, TRealMath, TMatrix>.one) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(scaleY, Matrix3x2Math<T, TRealMath, TMatrix>.one))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                this.CreateScalingAt(scaleX, scaleY, Matrix3x2Math<T, TRealMath, TMatrix>.zero, Matrix3x2Math<T, TRealMath, TMatrix>.zero, out m);
            }
        }

        public void CreateScalingAt(T scaleX, T scaleY, T centerX, T centerY, out TMatrix m)
        {
            if ((Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(scaleX, Matrix3x2Math<T, TRealMath, TMatrix>.one) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(scaleY, Matrix3x2Math<T, TRealMath, TMatrix>.one)) && (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerX, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerY, Matrix3x2Math<T, TRealMath, TMatrix>.zero)))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                this.Create(scaleX, Matrix3x2Math<T, TRealMath, TMatrix>.zero, Matrix3x2Math<T, TRealMath, TMatrix>.zero, scaleY, Matrix3x2Math<T, TRealMath, TMatrix>.math.Subtract(centerX, Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(scaleX, centerX)), Matrix3x2Math<T, TRealMath, TMatrix>.math.Subtract(centerY, Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(scaleY, centerY)), out m);
            }
        }

        public void CreateSkewing(T skewAngleX, T skewAngleY, out TMatrix m)
        {
            if (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(skewAngleX, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(skewAngleY, Matrix3x2Math<T, TRealMath, TMatrix>.zero))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                T skewRadX = Matrix3x2Math<T, TRealMath, TMatrix>.math.DegreesToRadians<T, TRealMath>(skewAngleX);
                T skewRadY = Matrix3x2Math<T, TRealMath, TMatrix>.math.DegreesToRadians<T, TRealMath>(skewAngleY);
                this.CreateSkewingByRadians(skewRadX, skewRadY, out m);
            }
        }

        public void CreateSkewingAt(T skewAngleX, T skewAngleY, T centerX, T centerY, out TMatrix m)
        {
            if ((Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(skewAngleX, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(skewAngleY, Matrix3x2Math<T, TRealMath, TMatrix>.zero)) && (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerX, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerY, Matrix3x2Math<T, TRealMath, TMatrix>.zero)))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                T skewRadX = Matrix3x2Math<T, TRealMath, TMatrix>.math.DegreesToRadians<T, TRealMath>(skewAngleX);
                T skewRadY = Matrix3x2Math<T, TRealMath, TMatrix>.math.DegreesToRadians<T, TRealMath>(skewAngleY);
                this.CreateSkewingAtByRadians(skewRadX, skewRadY, centerX, centerY, out m);
            }
        }

        public void CreateSkewingByRadians(T skewRadX, T skewRadY, out TMatrix m)
        {
            if (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(skewRadX, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(skewRadY, Matrix3x2Math<T, TRealMath, TMatrix>.zero))
            {
                this.CreateIdentity(out m);
            }
            else
            {
                T local = Matrix3x2Math<T, TRealMath, TMatrix>.math.Tan(skewRadX);
                T local2 = Matrix3x2Math<T, TRealMath, TMatrix>.math.Tan(skewRadY);
                this.Create(Matrix3x2Math<T, TRealMath, TMatrix>.one, local2, local, Matrix3x2Math<T, TRealMath, TMatrix>.one, Matrix3x2Math<T, TRealMath, TMatrix>.zero, Matrix3x2Math<T, TRealMath, TMatrix>.zero, out m);
            }
        }

        public void CreateSkewingAtByRadians(T skewRadX, T skewRadY, T centerX, T centerY, out TMatrix m)
        {
            if ((Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(skewRadX, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(skewRadY, Matrix3x2Math<T, TRealMath, TMatrix>.zero)) && (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerX, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(centerY, Matrix3x2Math<T, TRealMath, TMatrix>.zero)))
            {
                this.CreateSkewingByRadians(skewRadX, skewRadY, out m);
            }
            else
            {
                TMatrix local;
                TMatrix local2;
                this.CreateTranslation(Matrix3x2Math<T, TRealMath, TMatrix>.math.Negate(centerX), Matrix3x2Math<T, TRealMath, TMatrix>.math.Negate(centerY), out local);
                this.CreateSkewingByRadians(skewRadY, skewRadY, out local2);
                this.Transform(ref local, ref local2, out m);
                m.OffsetX = Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(m.OffsetX, centerX);
                m.OffsetY = Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(m.OffsetY, centerY);
            }
        }

        public void CreateTranslation(T dx, T dy, out TMatrix m)
        {
            this.CreateIdentity(out m);
            m.OffsetX = dx;
            m.OffsetY = dy;
        }

        public void CreateZero(out TMatrix result)
        {
            result = default(TMatrix);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(TMatrix a, TMatrix b) => 
            this.Equals(ref a, ref b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ref TMatrix a, ref TMatrix b) => 
            ((((Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(a.M11, b.M11) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(a.M12, b.M12)) && (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(a.M21, b.M21) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(a.M22, b.M22))) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(a.OffsetX, b.OffsetX)) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(a.OffsetY, b.OffsetY));

        public T GetDeterminant(ref TMatrix m) => 
            Matrix3x2Math<T, TRealMath, TMatrix>.math.Subtract(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(m.M11, m.M22), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(m.M12, m.M21));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(TMatrix m) => 
            this.GetHashCode(ref m);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(ref TMatrix m) => 
            HashCodeUtil.CombineHashCodes(m.M11.GetHashCode(), m.M12.GetHashCode(), m.M21.GetHashCode(), m.M22.GetHashCode(), m.OffsetX.GetHashCode(), m.OffsetY.GetHashCode());

        public void GetInverse(ref TMatrix m, out TMatrix inverse)
        {
            T determinant = this.GetDeterminant(ref m);
            if (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(determinant, Matrix3x2Math<T, TRealMath, TMatrix>.zero))
            {
                ExceptionUtil.ThrowInvalidOperationException("This matrix is not invertible");
            }
            T b = Matrix3x2Math<T, TRealMath, TMatrix>.math.Divide(Matrix3x2Math<T, TRealMath, TMatrix>.one, determinant);
            this.Create(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(m.M22, b), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(Matrix3x2Math<T, TRealMath, TMatrix>.math.Negate(m.M12), b), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(Matrix3x2Math<T, TRealMath, TMatrix>.math.Negate(m.M21), b), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(m.M11, b), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(Matrix3x2Math<T, TRealMath, TMatrix>.math.Subtract(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(m.M21, m.OffsetY), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(m.OffsetX, m.M22)), b), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(Matrix3x2Math<T, TRealMath, TMatrix>.math.Subtract(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(m.OffsetX, m.M12), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(m.M11, m.OffsetY)), b), out inverse);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasInverse(ref TMatrix m)
        {
            if (!this.IsIdentity(ref m))
            {
                return !Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(this.GetDeterminant(ref m), Matrix3x2Math<T, TRealMath, TMatrix>.zero);
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsFinite(ref TMatrix m) => 
            (this.IsIdentity(ref m) || ((((Matrix3x2Math<T, TRealMath, TMatrix>.math.IsFinite<T, TRealMath>(m.M11) && Matrix3x2Math<T, TRealMath, TMatrix>.math.IsFinite<T, TRealMath>(m.M12)) && (Matrix3x2Math<T, TRealMath, TMatrix>.math.IsFinite<T, TRealMath>(m.M21) && Matrix3x2Math<T, TRealMath, TMatrix>.math.IsFinite<T, TRealMath>(m.M22))) && Matrix3x2Math<T, TRealMath, TMatrix>.math.IsFinite<T, TRealMath>(m.OffsetX)) && Matrix3x2Math<T, TRealMath, TMatrix>.math.IsFinite<T, TRealMath>(m.OffsetY)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsIdentity(ref TMatrix m) => 
            ((((Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M11, Matrix3x2Math<T, TRealMath, TMatrix>.one) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M12, Matrix3x2Math<T, TRealMath, TMatrix>.zero)) && (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M21, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M22, Matrix3x2Math<T, TRealMath, TMatrix>.one))) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.OffsetX, Matrix3x2Math<T, TRealMath, TMatrix>.zero)) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.OffsetY, Matrix3x2Math<T, TRealMath, TMatrix>.zero));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsIntegerTranslation(ref TMatrix m) => 
            ((this.IsTranslation(ref m) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.OffsetX, Matrix3x2Math<T, TRealMath, TMatrix>.math.Truncate(m.OffsetX))) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.OffsetY, Matrix3x2Math<T, TRealMath, TMatrix>.math.Truncate(m.OffsetY)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsRectilinear(ref TMatrix m) => 
            (Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M12, Matrix3x2Math<T, TRealMath, TMatrix>.zero) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M21, Matrix3x2Math<T, TRealMath, TMatrix>.zero));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsTranslation(ref TMatrix m) => 
            (((Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M11, Matrix3x2Math<T, TRealMath, TMatrix>.one) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M12, Matrix3x2Math<T, TRealMath, TMatrix>.zero)) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M21, Matrix3x2Math<T, TRealMath, TMatrix>.zero)) && Matrix3x2Math<T, TRealMath, TMatrix>.math.Equals(m.M22, Matrix3x2Math<T, TRealMath, TMatrix>.one));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Transform(ref TMatrix a, ref TMatrix b, out TMatrix result)
        {
            this.Create(Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.M11, b.M11), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.M12, b.M21)), Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.M11, b.M12), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.M12, b.M22)), Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.M21, b.M11), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.M22, b.M21)), Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.M21, b.M12), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.M22, b.M22)), Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.OffsetX, b.M11), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.OffsetY, b.M21)), b.OffsetX), Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.OffsetX, b.M12), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(a.OffsetY, b.M22)), b.OffsetY), out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TransformPoint(ref TMatrix a, T bX, T bY, out T bXResult, out T bYResult)
        {
            bXResult = Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(bX, a.M11), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(bY, a.M21)), a.OffsetX);
            bYResult = Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(bX, a.M12), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(bY, a.M22)), a.OffsetY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TransformVector(ref TMatrix a, T bX, T bY, out T bXResult, out T bYResult)
        {
            bXResult = Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(bX, a.M11), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(bY, a.M21));
            bYResult = Matrix3x2Math<T, TRealMath, TMatrix>.math.Add(Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(bX, a.M12), Matrix3x2Math<T, TRealMath, TMatrix>.math.Multiply(bY, a.M22));
        }
    }
}

