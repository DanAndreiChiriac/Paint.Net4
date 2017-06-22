namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Explicit)]
    public struct ColorBgra32 : INaturalPixelInfo<ColorBgra32>, INaturalPixelInfo, IPixelInfo, IUnsafeElementAccessor, IUnsafeElementAccessor<ColorBgra32>, IEquatable<ColorBgra32>
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

        public bool Equals(ColorBgra32 other) => 
            (this.bgra == other.bgra);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ColorBgra32, object>(this, obj);

        public static ColorBgra32 FromBgra(byte b, byte g, byte r, byte a) => 
            new ColorBgra32 { 
                b = b,
                g = g,
                r = r,
                a = a
            };

        public static ColorBgra32 FromUInt32(uint bgra) => 
            new ColorBgra32 { bgra = bgra };

        public override int GetHashCode() => 
            ((int) this.bgra);

        public static bool operator ==(ColorBgra32 a, ColorBgra32 b) => 
            a.Equals(b);

        public static implicit operator ColorRgba128Float(ColorBgra32 color) => 
            new ColorRgba128Float(ByteUtil.ToScalingFloat(color.r), ByteUtil.ToScalingFloat(color.g), ByteUtil.ToScalingFloat(color.b), ByteUtil.ToScalingFloat(color.a));

        public static bool operator !=(ColorBgra32 a, ColorBgra32 b) => 
            !(a == b);

        unsafe void IUnsafeElementAccessor.WriteElement(void* pDst, void* pSrc)
        {
            *((int*) pDst) = *((uint*) pSrc);
        }

        unsafe void IUnsafeElementAccessor<ColorBgra32>.CopyElements(ColorBgra32[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (ColorBgra32* bgraRef = dst)
            {
                BufferUtil.CopyElements((void*) bgraRef, dst.Length, dstIndex, pSrc, length, sizeof(ColorBgra32));
            }
        }

        unsafe void IUnsafeElementAccessor<ColorBgra32>.CopyElements(void* pDst, ColorBgra32[] src, int srcIndex, int length)
        {
            fixed (ColorBgra32* bgraRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) bgraRef, src.Length, srcIndex, length, sizeof(ColorBgra32));
            }
        }

        unsafe ColorBgra32 IUnsafeElementAccessor<ColorBgra32>.ReadElement(void* pDst) => 
            *(((ColorBgra32*) pDst));

        unsafe void IUnsafeElementAccessor<ColorBgra32>.WriteElement(void* pDst, ColorBgra32 srcValue)
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
            typeof(ColorBgra32);

        int IUnsafeElementAccessor.SizeOfElement =>
            4;

        int INaturalPixelInfo.BytesPerPixel =>
            4;

        int IPixelInfo.BitsPerPixel =>
            0x20;

        PixelFormat IPixelInfo.PixelFormat =>
            PixelFormats.Bgra32;

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

