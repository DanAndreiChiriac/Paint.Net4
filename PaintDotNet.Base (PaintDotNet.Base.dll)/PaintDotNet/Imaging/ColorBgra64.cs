namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Explicit)]
    public struct ColorBgra64 : INaturalPixelInfo<ColorBgra64>, INaturalPixelInfo, IPixelInfo, IUnsafeElementAccessor, IUnsafeElementAccessor<ColorBgra64>, IEquatable<ColorBgra64>
    {
        [FieldOffset(6)]
        internal ushort a;
        [FieldOffset(0)]
        internal ushort b;
        [NonSerialized, FieldOffset(0)]
        internal ulong bgra;
        [FieldOffset(2)]
        internal ushort g;
        [FieldOffset(4)]
        internal ushort r;

        public bool Equals(ColorBgra64 other) => 
            (this.bgra == other.bgra);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ColorBgra64, object>(this, obj);

        public static ColorBgra64 FromBgra(ushort b, ushort g, ushort r, ushort a) => 
            new ColorBgra64 { 
                b = b,
                g = g,
                r = r,
                a = a
            };

        public static ColorBgra64 FromUInt64(ulong bgra) => 
            new ColorBgra64 { bgra = bgra };

        public override int GetHashCode() => 
            this.bgra.GetHashCode();

        public static bool operator ==(ColorBgra64 a, ColorBgra64 b) => 
            a.Equals(b);

        public static bool operator !=(ColorBgra64 a, ColorBgra64 b) => 
            !(a == b);

        unsafe void IUnsafeElementAccessor.WriteElement(void* pDst, void* pSrc)
        {
            *((long*) pDst) = *((long*) pSrc);
        }

        unsafe void IUnsafeElementAccessor<ColorBgra64>.CopyElements(ColorBgra64[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (ColorBgra64* bgraRef = dst)
            {
                BufferUtil.CopyElements((void*) bgraRef, dst.Length, dstIndex, pSrc, length, sizeof(ColorBgra64));
            }
        }

        unsafe void IUnsafeElementAccessor<ColorBgra64>.CopyElements(void* pDst, ColorBgra64[] src, int srcIndex, int length)
        {
            fixed (ColorBgra64* bgraRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) bgraRef, src.Length, srcIndex, length, sizeof(ColorBgra64));
            }
        }

        unsafe ColorBgra64 IUnsafeElementAccessor<ColorBgra64>.ReadElement(void* pDst) => 
            *(((ColorBgra64*) pDst));

        unsafe void IUnsafeElementAccessor<ColorBgra64>.WriteElement(void* pDst, ColorBgra64 srcValue)
        {
            pDst.bgra = srcValue.bgra;
        }

        public ushort A
        {
            get => 
                this.a;
            set
            {
                this.a = value;
            }
        }

        public ushort B
        {
            get => 
                this.b;
            set
            {
                this.b = value;
            }
        }

        public ulong Bgra
        {
            get => 
                this.bgra;
            set
            {
                this.bgra = value;
            }
        }

        public ushort G
        {
            get => 
                this.g;
            set
            {
                this.g = value;
            }
        }

        Type IUnsafeElementAccessor.ElementType =>
            typeof(ColorBgra64);

        int IUnsafeElementAccessor.SizeOfElement =>
            8;

        int INaturalPixelInfo.BytesPerPixel =>
            8;

        int IPixelInfo.BitsPerPixel =>
            0x40;

        PixelFormat IPixelInfo.PixelFormat =>
            PixelFormats.Bgra64;

        public ushort R
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

