namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.Dxgi;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Direct2DPixelFormat : IEquatable<Direct2DPixelFormat>
    {
        private DxgiFormat format;
        private PaintDotNet.Direct2D.AlphaMode alphaMode;
        public DxgiFormat Format
        {
            get => 
                this.format;
            set
            {
                this.format = value;
            }
        }
        public PaintDotNet.Direct2D.AlphaMode AlphaMode
        {
            get => 
                this.alphaMode;
            set
            {
                this.alphaMode = value;
            }
        }
        public Direct2DPixelFormat(DxgiFormat format, PaintDotNet.Direct2D.AlphaMode alphaMode)
        {
            this.format = format;
            this.alphaMode = alphaMode;
        }

        public bool Equals(Direct2DPixelFormat other) => 
            ((this.format == other.format) && (this.alphaMode == other.alphaMode));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<Direct2DPixelFormat, object>(this, obj);

        public static bool operator ==(Direct2DPixelFormat a, Direct2DPixelFormat b) => 
            a.Equals(b);

        public static bool operator !=(Direct2DPixelFormat a, Direct2DPixelFormat b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes((int) this.format, (int) this.alphaMode);

        public bool TryGetBitsPerPixel(out int bpp)
        {
            bool flag = true;
            switch (this.format)
            {
                case DxgiFormat.R32G32B32A32_Typeless:
                case DxgiFormat.R32G32B32A32_Float:
                case DxgiFormat.R32G32B32A32_UInt:
                case DxgiFormat.R32G32B32A32_SInt:
                    bpp = 0x80;
                    break;

                case DxgiFormat.R32G32B32_Typeless:
                case DxgiFormat.R32G32B32_Float:
                case DxgiFormat.R32G32B32_UInt:
                case DxgiFormat.R32G32B32_SInt:
                    bpp = 0x60;
                    break;

                case DxgiFormat.R16G16B16A16_Typeless:
                case DxgiFormat.R16G16B16A16_Float:
                case DxgiFormat.R16G16B16A16_UNorm:
                case DxgiFormat.R16G16B16A16_UInt:
                case DxgiFormat.R16G16B16A16_SNorm:
                case DxgiFormat.R16G16B16A16_SInt:
                case DxgiFormat.R32G32_Typeless:
                case DxgiFormat.R32G32_Float:
                case DxgiFormat.R32G32_UInt:
                case DxgiFormat.R32G32_SInt:
                case DxgiFormat.R32G8X24_Typeless:
                case DxgiFormat.D32_Float_S8X24_UInt:
                case DxgiFormat.R32_Float_X8X24_Typeless:
                case DxgiFormat.X32_Typeless_G8X24_UInt:
                    bpp = 0x40;
                    break;

                case DxgiFormat.R10G10B10A2_Typeless:
                case DxgiFormat.R10G10B10A2_UNorm:
                case DxgiFormat.R10G10B10A2_UInt:
                case DxgiFormat.R11G11B10_Float:
                case DxgiFormat.R8G8B8A8_Typeless:
                case DxgiFormat.R8G8B8A8_UNorm:
                case DxgiFormat.R8G8B8A8_UNorm_SRgb:
                case DxgiFormat.R8G8B8A8_UInt:
                case DxgiFormat.R8G8B8A8_SNorm:
                case DxgiFormat.R8G8B8A8_SInt:
                case DxgiFormat.R16G16_Typeless:
                case DxgiFormat.R16G16_Float:
                case DxgiFormat.R16G16_UNorm:
                case DxgiFormat.R16G16_UInt:
                case DxgiFormat.R16G16_SNorm:
                case DxgiFormat.R16G16_SInt:
                case DxgiFormat.R32_Typeless:
                case DxgiFormat.D32_Float:
                case DxgiFormat.R32_Float:
                case DxgiFormat.R32_UInt:
                case DxgiFormat.R32_SInt:
                case DxgiFormat.R24G8_Typeless:
                case DxgiFormat.D24_UNorm_S8_UInt:
                case DxgiFormat.R24_UNorm_X8_Typeless:
                case DxgiFormat.X24_Typeless_G8_UInt:
                case DxgiFormat.R9G9B9E5_SharedExp:
                case DxgiFormat.R8G8_B8G8_UNorm:
                case DxgiFormat.G8R8_G8B8_UNorm:
                case DxgiFormat.R10G10B10_XR_BIAS_A2_UNorm:
                case DxgiFormat.B8G8R8A8_Typeless:
                case DxgiFormat.B8G8R8A8_UNorm_SRgb:
                case DxgiFormat.B8G8R8X8_Typeless:
                case DxgiFormat.B8G8R8X8_UNorm_SRgb:
                    bpp = 0x20;
                    break;

                case DxgiFormat.R8G8_Typeless:
                case DxgiFormat.R8G8_UNorm:
                case DxgiFormat.R8G8_UInt:
                case DxgiFormat.R8G8_SNorm:
                case DxgiFormat.R8G8_SInt:
                case DxgiFormat.R16_Typeless:
                case DxgiFormat.R16_Float:
                case DxgiFormat.D16_UNorm:
                case DxgiFormat.R16_UNorm:
                case DxgiFormat.R16_UInt:
                case DxgiFormat.R16_SNorm:
                case DxgiFormat.R16_SInt:
                case DxgiFormat.B5G6R5_UNorm:
                case DxgiFormat.B5G5R5A1_UNorm:
                    bpp = 0x10;
                    break;

                case DxgiFormat.R8_Typeless:
                case DxgiFormat.R8_UNorm:
                case DxgiFormat.R8_UInt:
                case DxgiFormat.R8_SNorm:
                case DxgiFormat.R8_SInt:
                case DxgiFormat.A8_UNorm:
                    bpp = 8;
                    break;

                case DxgiFormat.R1_UNorm:
                    bpp = 1;
                    break;

                case DxgiFormat.B8G8R8A8_UNorm:
                case DxgiFormat.B8G8R8X8_UNorm:
                    bpp = 0x18;
                    break;

                default:
                    bpp = -1;
                    break;
            }
            if (bpp == -1)
            {
                flag = false;
            }
            return flag;
        }
    }
}

