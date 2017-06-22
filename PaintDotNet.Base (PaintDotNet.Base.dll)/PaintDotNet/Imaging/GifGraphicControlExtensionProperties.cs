namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum GifGraphicControlExtensionProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI2 })]
        Delay = 4,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        Disposal = 1,
        [VariantType(new VarEnum[] { VarEnum.VT_BOOL })]
        TransparencyFlag = 3,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        TransparentColorIndex = 5,
        [VariantType(new VarEnum[] { VarEnum.VT_BOOL })]
        UserInputFlag = 2
    }
}

