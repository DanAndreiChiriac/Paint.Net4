namespace PaintDotNet.Rendering
{
    using System;

    internal interface IMatrix3x2<T>
    {
        void Invert();
        void Rotate(T angle);
        void RotateAt(T angle, T centerX, T centerY);
        void RotateAtByRadians(T radians, T centerX, T centerY);
        void RotateAtByRadiansPrepend(T radians, T centerX, T centerY);
        void RotateAtPrepend(T angle, T centerX, T centerY);
        void RotateByRadians(T radians);
        void RotateByRadiansPrepend(T radians);
        void RotatePrepend(T angle);
        void Scale(T scaleX, T scaleY);
        void ScaleAt(T scaleX, T scaleY, T centerX, T centerY);
        void ScaleAtPrepend(T scaleX, T scaleY, T centerX, T centerY);
        void ScalePrepend(T scaleX, T scaleY);
        void Skew(T skewAngleX, T skewAngleY);
        void SkewByRadians(T skewRadX, T skewRadY);
        void SkewByRadiansPrepend(T skewRadX, T skewRadY);
        void SkewPrepend(T skewAngleX, T skewAngleY);
        void Translate(T dx, T dy);
        void TranslatePrepend(T dx, T dy);

        T Determinant { get; }

        bool HasInverse { get; }

        bool IsFinite { get; }

        bool IsIdentity { get; }

        bool IsIntegerTranslation { get; }

        bool IsRectilinear { get; }

        bool IsTranslation { get; }

        T M11 { get; set; }

        T M12 { get; set; }

        T M21 { get; set; }

        T M22 { get; set; }

        T OffsetX { get; set; }

        T OffsetY { get; set; }
    }
}

