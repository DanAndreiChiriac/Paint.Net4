namespace PaintDotNet.Rendering
{
    using PaintDotNet.Collections;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    internal interface IMatrix3x2Math<T, TRealMath, TMatrix> : IEqualityComparerByRef<TMatrix>, IEqualityComparer<TMatrix> where TRealMath: IRealMath<T> where TMatrix: IMatrix3x2<T>
    {
        void Copy(ref TMatrix m, out TMatrix result);
        void Create(T m11, T m12, T m21, T m22, T offsetX, T offsetY, out TMatrix result);
        void CreateIdentity(out TMatrix result);
        void CreateRotation(T angle, out TMatrix m);
        void CreateRotationAt(T angle, T centerX, T centerY, out TMatrix m);
        void CreateRotationAtByRadians(T radians, T centerX, T centerY, out TMatrix m);
        void CreateRotationByRadians(T radians, out TMatrix m);
        void CreateScaling(T scaleX, T scaleY, out TMatrix m);
        void CreateScalingAt(T scaleX, T scaleY, T centerX, T centerY, out TMatrix m);
        void CreateSkewing(T skewAngleX, T skewAngleY, out TMatrix m);
        void CreateSkewingAt(T skewAngleX, T skewAngleY, T centerX, T centerY, out TMatrix m);
        void CreateSkewingAtByRadians(T skewRadX, T skewRadY, T centerX, T centerY, out TMatrix m);
        void CreateSkewingByRadians(T skewRadX, T skewRadY, out TMatrix m);
        void CreateTranslation(T dx, T dy, out TMatrix m);
        void CreateZero(out TMatrix m);
        T GetDeterminant(ref TMatrix m);
        void GetInverse(ref TMatrix m, out TMatrix inverse);
        bool HasInverse(ref TMatrix m);
        bool IsFinite(ref TMatrix m);
        bool IsIdentity(ref TMatrix m);
        bool IsIntegerTranslation(ref TMatrix m);
        bool IsRectilinear(ref TMatrix m);
        bool IsTranslation(ref TMatrix m);
        void Transform(ref TMatrix a, ref TMatrix b, out TMatrix result);
        void TransformPoint(ref TMatrix a, T bX, T bY, out T bXResult, out T bYResult);
        void TransformVector(ref TMatrix a, T bX, T bY, out T bXResult, out T bYResult);
    }
}

