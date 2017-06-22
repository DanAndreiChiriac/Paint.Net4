namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum GifImageDescriptorProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI2 })]
        Height = 4,
        [VariantType(new VarEnum[] { VarEnum.VT_BOOL })]
        InterlaceFlag = 6,
        [VariantType(new VarEnum[] { VarEnum.VT_UI2 })]
        Left = 1,
        [VariantType(new VarEnum[] { VarEnum.VT_BOOL })]
        LocalColorTableFlag = 5,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        LocalColorTableSize = 8,
        [VariantType(new VarEnum[] { VarEnum.VT_BOOL })]
        SortFlag = 7,
        [VariantType(new VarEnum[] { VarEnum.VT_UI2 })]
        Top = 2,
        [VariantType(new VarEnum[] { VarEnum.VT_UI2 })]
        Width = 3
    }
}

