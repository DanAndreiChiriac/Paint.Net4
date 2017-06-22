namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Explicit)]
    public struct ColorPbgra32 : INaturalPixelInfo<ColorPbgra32>, INaturalPixelInfo, IPixelInfo, IUnsafeElementAccessor, IUnsafeElementAccessor<ColorPbgra32>, IEquatable<ColorPbgra32>
    {
        [FieldOffset(3)]
        internal byte a;
        [FieldOffset(0)]
        internal byte b;
        [NonSerialized, FieldOffset(0)]
        internal uint bgra;
        [FieldOffset(1)]
        internal byte g;
        [FieldOffset(2)]
        internal byte r;

        public bool Equals(ColorPbgra32 other) => 
            (this.bgra == other.bgra);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ColorPbgra32, object>(this, obj);

        public static ColorPbgra32 FromBgra(byte b, byte g, byte r, byte a) => 
            new ColorPbgra32 { 
                b = b,
                g = g,
                r = r,
                a = a
            };

        public static ColorPbgra32 FromUInt32(uint bgra) => 
            new ColorPbgra32 { bgra = bgra };

        public override int GetHashCode() => 
            ((int) this.bgra);

        public static bool operator ==(ColorPbgra32 a, ColorPbgra32 b) => 
            a.Equals(b);

        public static bool operator !=(ColorPbgra32 a, ColorPbgra32 b) => 
            !(a == b);

        unsafe void IUnsafeElementAccessor.WriteElement(void* pDst, void* pSrc)
        {
            *((int*) pDst) = *((uint*) pSrc);
        }

        unsafe void IUnsafeElementAccessor<ColorPbgra32>.CopyElements(ColorPbgra32[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (ColorPbgra32* pbgraRef = dst)
            {
                BufferUtil.CopyElements((void*) pbgraRef, dst.Length, dstIndex, pSrc, length, sizeof(ColorPbgra32));
            }
        }

        unsafe void IUnsafeElementAccessor<ColorPbgra32>.CopyElements(void* pDst, ColorPbgra32[] src, int srcIndex, int length)
        {
            fixed (ColorPbgra32* pbgraRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) pbgraRef, src.Length, srcIndex, length, sizeof(ColorPbgra32));
            }
        }

        unsafe ColorPbgra32 IUnsafeElementAccessor<ColorPbgra32>.ReadElement(void* pDst) => 
            *(((ColorPbgra32*) pDst));

        unsafe void IUnsafeElementAccessor<ColorPbgra32>.WriteElement(void* pDst, ColorPbgra32 srcValue)
        {
            *((int*) pDst) = srcValue.bgra;
        }

        public byte A
        {
            get => 
                this.a;
            set
            {
                this.a = value;
            }
        }

        public byte B
        {
            get => 
                this.b;
            set
            {
                this.b = value;
            }
        }

        public uint Bgra
        {
            get => 
                this.bgra;
            set
            {
                this.bgra = value;
            }
        }

        public byte G
        {
            get => 
                this.g;
            set
            {
                this.g = value;
            }
        }

        Type IUnsafeElementAccessor.ElementType =>
            typeof(ColorPbgra32);

        int IUnsafeElementAccessor.SizeOfElement =>
            4;

        int INaturalPixelInfo.BytesPerPixel =>
            4;

        int IPixelInfo.BitsPerPixel =>
            0x20;

        PixelFormat IPixelInfo.PixelFormat =>
            PixelFormats.Pbgra32;

        public byte R
        {
            get => 
                this.r;
            set
            {
                this.r = value;
            }
        }
    }
}

