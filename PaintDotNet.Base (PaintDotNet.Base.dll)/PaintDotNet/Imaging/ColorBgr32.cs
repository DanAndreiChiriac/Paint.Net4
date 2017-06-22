namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Explicit)]
    public struct ColorBgr32 : INaturalPixelInfo<ColorBgr32>, INaturalPixelInfo, IPixelInfo, IUnsafeElementAccessor, IUnsafeElementAccessor<ColorBgr32>, IEquatable<ColorBgr32>
    {
        [FieldOffset(0)]
        internal byte b;
        [NonSerialized, FieldOffset(0)]
        internal uint bgrx;
        [FieldOffset(1)]
        internal byte g;
        [FieldOffset(2)]
        internal byte r;
        [FieldOffset(3)]
        internal byte x;

        public bool Equals(ColorBgr32 other) => 
            (this.bgrx == other.bgrx);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<ColorBgr32, object>(this, obj);

        public static ColorBgr32 FromBgr(byte b, byte g, byte r) => 
            new ColorBgr32 { 
                b = b,
                g = g,
                r = r,
                x = 0xff
            };

        public static ColorBgr32 FromBgrx(byte b, byte g, byte r, byte x) => 
            new ColorBgr32 { 
                b = b,
                g = g,
                r = r,
                x = x
            };

        public static ColorBgr32 FromUInt32(uint bgrx) => 
            new ColorBgr32 { bgrx = bgrx };

        public override int GetHashCode() => 
            ((int) this.bgrx);

        public static bool operator ==(ColorBgr32 a, ColorBgr32 b) => 
            a.Equals(b);

        public static implicit operator ColorRgba128Float(ColorBgr32 color) => 
            new ColorRgba128Float(ByteUtil.ToScalingFloat(color.r), ByteUtil.ToScalingFloat(color.g), ByteUtil.ToScalingFloat(color.b), ByteUtil.ToScalingFloat(color.x));

        public static bool operator !=(ColorBgr32 a, ColorBgr32 b) => 
            !(a == b);

        unsafe void IUnsafeElementAccessor.WriteElement(void* pDst, void* pSrc)
        {
            *((int*) pDst) = *((uint*) pSrc);
        }

        unsafe void IUnsafeElementAccessor<ColorBgr32>.CopyElements(ColorBgr32[] dst, int dstIndex, void* pSrc, int length)
        {
            fixed (ColorBgr32* bgrRef = dst)
            {
                BufferUtil.CopyElements((void*) bgrRef, dst.Length, dstIndex, pSrc, length, sizeof(ColorBgr32));
            }
        }

        unsafe void IUnsafeElementAccessor<ColorBgr32>.CopyElements(void* pDst, ColorBgr32[] src, int srcIndex, int length)
        {
            fixed (ColorBgr32* bgrRef = src)
            {
                BufferUtil.CopyElements(pDst, (void*) bgrRef, src.Length, srcIndex, length, sizeof(ColorBgr32));
            }
        }

        unsafe ColorBgr32 IUnsafeElementAccessor<ColorBgr32>.ReadElement(void* pDst) => 
            *(((ColorBgr32*) pDst));

        unsafe void IUnsafeElementAccessor<ColorBgr32>.WriteElement(void* pDst, ColorBgr32 srcValue)
        {
            *((int*) pDst) = srcValue.Bgrx;
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

        public uint Bgrx
        {
            get => 
                this.bgrx;
            set
            {
                this.bgrx = value;
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
            typeof(ColorBgr32);

        int IUnsafeElementAccessor.SizeOfElement =>
            4;

        int INaturalPixelInfo.BytesPerPixel =>
            4;

        int IPixelInfo.BitsPerPixel =>
            0x20;

        PixelFormat IPixelInfo.PixelFormat =>
            PixelFormats.Bgr32;

        public byte R
        {
            get => 
                this.r;
            set
            {
                this.r = value;
            }
        }

        public byte X
        {
            get => 
                this.x;
            set
            {
                this.x = value;
            }
        }
    }
}

