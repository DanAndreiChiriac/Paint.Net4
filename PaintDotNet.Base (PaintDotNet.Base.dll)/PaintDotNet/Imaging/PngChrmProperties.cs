namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum PngChrmProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        BlueX = 7,
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        BlueY = 8,
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        GreenX = 5,
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        GreenY = 6,
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        RedX = 3,
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        RedY = 4,
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        WhitePointX = 1,
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        WhitePointY = 2
    }
}

