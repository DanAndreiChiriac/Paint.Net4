namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum GifLogicalScreenDescriptorProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        BackgroundColorIndex = 8,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        ColorResolution = 5,
        [VariantType(new VarEnum[] { VarEnum.VT_BOOL })]
        GlobalColorTableFlag = 4,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        GlobalColorTableSize = 7,
        [VariantType(new VarEnum[] { VarEnum.VT_UI2 })]
        Height = 3,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        PixelAspectRatio = 9,
        [VariantType(new VarEnum[] { VarEnum.VT_VECTOR | VarEnum.VT_UI1 })]
        Signature = 1,
        [VariantType(new VarEnum[] { VarEnum.VT_BOOL })]
        SortFlag = 6,
        [VariantType(new VarEnum[] { VarEnum.VT_UI2 })]
        Width = 2
    }
}

