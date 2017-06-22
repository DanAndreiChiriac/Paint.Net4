namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ColorHsv96Float : IEquatable<ColorHsv96Float>
    {
        public const float HueMinValue = 0f;
        public const float HueMaxValue = 360f;
        public const float SaturationMinValue = 0f;
        public const float SaturationMaxValue = 100f;
        public const float ValueMinValue = 0f;
        public const float ValueMaxValue = 100f;
        private static readonly FloatIsClampedValidator hueValidator;
        private static readonly FloatIsClampedValidator saturationValidator;
        private static readonly FloatIsClampedValidator valueValidator;
        private float hue;
        private float saturation;
        private float value;
        public float Hue
        {
            get => 
                this.hue;
            set
            {
                Validate.IsValid<float, FloatIsClampedValidator>(hueValidator, value, "value");
                this.hue = value;
            }
        }
        public float Saturation
        {
            get => 
                this.saturation;
            set
            {
                Validate.IsValid<float, FloatIsClampedValidator>(saturationValidator, value, "value");
                this.saturation = value;
            }
        }
        public float Value
        {
            get => 
                this.value;
            set
            {
                Validate.IsValid<float, FloatIsClampedValidator>(valueValidator, value, "value");
                this.value = value;
            }
        }
        public static bool operator ==(ColorHsv96Float lhs, ColorHsv96Float rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(ColorHsv96Float lhs, ColorHsv96Float rhs) => 
            !(lhs == rhs);

        public bool Equals(ColorHsv96Float other) => 
            (((this.hue == other.hue) && (this.saturation == other.saturation)) && (this.value == other.value));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ColorHsv96Float, object>(this, obj);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.hue.GetHashCode(), this.saturation.GetHashCode(), this.value.GetHashCode());

        public ColorHsv96Float(float hue, float saturation, float value)
        {
            Validate.Begin().IsValid<float, FloatIsClampedValidator>(hueValidator, hue, "hue").IsValid<float, FloatIsClampedValidator>(saturationValidator, saturation, "saturation").IsValid<float, FloatIsClampedValidator>(valueValidator, value, "value").Check();
            this.hue = hue;
            this.saturation = saturation;
            this.value = value;
        }

        public ColorRgb96Float ToRgb()
        {
            float num4;
            float num5;
            float num6;
            ColorRgb96Float num12;
            float num = (this.hue == 360f) ? 0f : this.hue;
            float num2 = this.saturation / 100f;
            float num3 = this.value / 100f;
            if (num2 == 0f)
            {
                num4 = num3;
                num5 = num3;
                num6 = num3;
            }
            else
            {
                float single1 = num / 60f;
                int num7 = (int) Math.Floor((double) single1);
                float num8 = single1 - num7;
                float num9 = num3 * (1f - num2);
                float num10 = num3 * (1f - (num2 * num8));
                float num11 = num3 * (1f - (num2 * (1f - num8)));
                switch (num7)
                {
                    case 0:
                        num4 = num3;
                        num5 = num11;
                        num6 = num9;
                        goto Label_00FD;

                    case 1:
                        num4 = num10;
                        num5 = num3;
                        num6 = num9;
                        goto Label_00FD;

                    case 2:
                        num4 = num9;
                        num5 = num3;
                        num6 = num11;
                        goto Label_00FD;

                    case 3:
                        num4 = num9;
                        num5 = num10;
                        num6 = num3;
                        goto Label_00FD;

                    case 4:
                        num4 = num11;
                        num5 = num9;
                        num6 = num3;
                        goto Label_00FD;

                    case 5:
                        num4 = num3;
                        num5 = num9;
                        num6 = num10;
                        goto Label_00FD;
                }
                throw new PaintDotNet.Imaging.InternalErrorException();
            }
        Label_00FD:;
            try
            {
                num12 = new ColorRgb96Float(num4, num5, num6);
            }
            catch (Exception exception1)
            {
                HandleConversionException(exception1, this.hue, this.saturation, this.value, num4, num5, num6);
                throw new UnreachableCodeException();
            }
            return num12;
        }

        private static unsafe void HandleConversionException(Exception ex, float h, float s, float v, float r, float g, float b)
        {
            uint num = *((uint*) &h);
            uint num2 = *((uint*) &s);
            uint num3 = *((uint*) &v);
            uint num4 = *((uint*) &r);
            uint num5 = *((uint*) &g);
            uint num6 = *((uint*) &b);
            throw new PaintDotNet.Imaging.InternalErrorException($"caught an exception while converting to RGB. this.H/S/V = {h} / {s} / {v}, r/g/b = {r} / {g} / {b}, IEEE: h/s/v = 0x{num.ToString("X")} / 0x{num2.ToString("X")} / 0x{num3.ToString("X")}, r/g/b = 0x{num4.ToString("X")} / 0x{num5.ToString("X")} / 0x{num6.ToString("X")}", ex);
        }

        public override string ToString() => 
            $"(H={this.Hue}, S={this.Saturation}, V={this.Value})";

        static ColorHsv96Float()
        {
            hueValidator = new FloatIsClampedValidator(0f, 360f);
            saturationValidator = new FloatIsClampedValidator(0f, 100f);
            valueValidator = new FloatIsClampedValidator(0f, 100f);
        }
    }
}

