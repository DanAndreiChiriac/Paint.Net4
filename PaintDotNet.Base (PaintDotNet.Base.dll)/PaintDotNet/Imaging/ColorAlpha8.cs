namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ColorAlpha8 : INaturalPixelInfo<ColorAlpha8>, INaturalPixelInfo, IPixelInfo, IUnsafeElementAccessor, IUnsafeElementAccessor<ColorAlpha8>, IEquatable<ColorAlpha8>
    {
        internal byte a;
        public static int SizeOf =>
            1;
        public byte A
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                this.a;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.a = value;
            }
        }
        int INaturalPixelInfo.BytesPerPixel =>
            1;
        int IPixelInfo.BitsPerPixel =>
            8;
        PixelFormat IPixelInfo.PixelFormat =>
            PixelFormats.Alpha8;
        Type IUnsafeElementAccessor.ElementType =>
            typeof(ColorAlpha8);
        int IUnsafeElementAccessor.SizeOfElement =>
            1;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe void IUnsafeElementAccessor.WriteElement(void* pDst, void* pSrc)
        {
            *((sbyte*) pDst) = *((byte*) pSrc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe ColorAlpha8 IUnsafeElementAccessor<ColorAlpha8>.ReadElement(void* pDst) => 
            *(((ColorAlpha8*) pDst));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe void IUnsafeElementAccessor<ColorAlpha8>.WriteElement(void* pDst, ColorAlpha8 srcValue)
        {
            *((sbyte*) pDst) = srcValue.a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe void IUnsafeElementAccessor<ColorAlpha8>.CopyElements(ColorAlpha8[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (ColorAlpha8* alphaRef = dst)
            {
                BufferUtil.CopyElements((void*) alphaRef, dst.Length, dstIndex, pSrc, length, sizeof(ColorAlpha8));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe void IUnsafeElementAccessor<ColorAlpha8>.CopyElements(void* pDst, ColorAlpha8[] src, int srcIndex, int length)
        {
            fixed (ColorAlpha8* alphaRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) alphaRef, src.Length, srcIndex, length, sizeof(ColorAlpha8));
            }
        }

        public static ColorAlpha8 Transparent =>
            new ColorAlpha8(0);
        public static ColorAlpha8 Opaque =>
            new ColorAlpha8(0xff);
        public static ColorAlpha8 Zero =>
            new ColorAlpha8(0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ColorAlpha8(byte a)
        {
            this.a = a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ColorAlpha8 other) => 
            (this.a == other.a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ColorAlpha8, object>(this, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ColorAlpha8 a, ColorAlpha8 b) => 
            a.Equals(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ColorAlpha8 a, ColorAlpha8 b) => 
            !(a == b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => 
            this.a.GetHashCode();

        public static ColorAlpha8 Blend4W16IP(ColorAlpha8 a1, uint w1, ColorAlpha8 a2, uint w2, ColorAlpha8 a3, uint w3, ColorAlpha8 a4, uint w4) => 
            new ColorAlpha8(DoubleUtil.ClampToByte((double) ((((((a1.A * w1) + (a2.A * w2)) + (a3.A * w3)) + (a4.A * w4)) + 0x8000) >> 0x10)));
    }
}

