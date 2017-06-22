namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct ColorRgba128Float : INaturalPixelInfo<ColorRgba128Float>, INaturalPixelInfo, IPixelInfo, IUnsafeElementAccessor, IUnsafeElementAccessor<ColorRgba128Float>, IEquatable<ColorRgba128Float>
    {
        internal float r;
        internal float g;
        internal float b;
        internal float a;
        public static ColorRgba128Float Transparent =>
            new ColorRgba128Float(1f, 1f, 1f, 0f);
        public static ColorRgba128Float TransparentBlack =>
            new ColorRgba128Float(0f, 0f, 0f, 0f);
        public float R
        {
            get => 
                this.r;
            set
            {
                this.r = value;
            }
        }
        public float G
        {
            get => 
                this.g;
            set
            {
                this.g = value;
            }
        }
        public float B
        {
            get => 
                this.b;
            set
            {
                this.b = value;
            }
        }
        public float A
        {
            get => 
                this.a;
            set
            {
                this.a = value;
            }
        }
        public ColorRgba128Float(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public ColorRgba128Float(ColorRgba128Float color, float newA)
        {
            this.r = color.r;
            this.g = color.g;
            this.b = color.b;
            this.a = newA;
        }

        public bool Equals(ColorRgba128Float other) => 
            ((((this.r == other.r) && (this.g == other.g)) && (this.b == other.b)) && (this.a == other.a));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ColorRgba128Float, object>(this, obj);

        public static bool operator ==(ColorRgba128Float lhs, ColorRgba128Float rhs) => 
            lhs.Equals(rhs);

        public static bool operator !=(ColorRgba128Float lhs, ColorRgba128Float rhs) => 
            !lhs.Equals(rhs);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.r.GetHashCode(), this.g.GetHashCode(), this.b.GetHashCode(), this.a.GetHashCode());

        public static ColorRgba128Float Blend(ColorRgba128Float ca, ColorRgba128Float cb, float cbAlpha)
        {
            float num4;
            float num5;
            float num6;
            Validate.IsNotNegative(cbAlpha, "cbAlpha");
            Validate.IsFinite(cbAlpha, "cbAlpha");
            float num = (1f - cbAlpha) * ca.a;
            float num2 = cbAlpha * cb.a;
            float a = num + num2;
            if (a == 0f)
            {
                num4 = 0f;
                num5 = 0f;
                num6 = 0f;
            }
            else
            {
                float num7 = 1f / a;
                num4 = ((ca.r * num) + (cb.r * num2)) * num7;
                num5 = ((ca.g * num) + (cb.g * num2)) * num7;
                num6 = ((ca.b * num) + (cb.b * num2)) * num7;
            }
            return new ColorRgba128Float(num4, num5, num6, a);
        }

        public static implicit operator ColorRgba128Float(Color gdipColor) => 
            new ColorRgba128Float(ByteUtil.ToScalingFloat(gdipColor.R), ByteUtil.ToScalingFloat(gdipColor.G), ByteUtil.ToScalingFloat(gdipColor.B), ByteUtil.ToScalingFloat(gdipColor.A));

        public override string ToString() => 
            $"R:{this.r:F3} G:{this.g:F3} B:{this.b:F3} A:{this.a:F3}";

        int INaturalPixelInfo.BytesPerPixel =>
            0x10;
        int IPixelInfo.BitsPerPixel =>
            0x80;
        PixelFormat IPixelInfo.PixelFormat =>
            PixelFormats.Rgba128Float;
        Type IUnsafeElementAccessor.ElementType =>
            typeof(ColorRgba128Float);
        int IUnsafeElementAccessor.SizeOfElement =>
            0x10;
        unsafe void IUnsafeElementAccessor.WriteElement(void* pDst, void* pSrc)
        {
            pDst[0] = pSrc[0];
        }

        unsafe ColorRgba128Float IUnsafeElementAccessor<ColorRgba128Float>.ReadElement(void* pDst) => 
            *(((ColorRgba128Float*) pDst));

        unsafe void IUnsafeElementAccessor<ColorRgba128Float>.WriteElement(void* pDst, ColorRgba128Float srcValue)
        {
            pDst[0] = srcValue;
        }

        unsafe void IUnsafeElementAccessor<ColorRgba128Float>.CopyElements(ColorRgba128Float[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (ColorRgba128Float* numRef = dst)
            {
                BufferUtil.CopyElements((void*) numRef, dst.Length, dstIndex, pSrc, length, sizeof(ColorRgba128Float));
            }
        }

        unsafe void IUnsafeElementAccessor<ColorRgba128Float>.CopyElements(void* pDst, ColorRgba128Float[] src, int srcIndex, int length)
        {
            fixed (ColorRgba128Float* numRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) numRef, src.Length, srcIndex, length, sizeof(ColorRgba128Float));
            }
        }
    }
}

