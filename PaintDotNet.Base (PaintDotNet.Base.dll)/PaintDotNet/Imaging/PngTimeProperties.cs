namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum PngTimeProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        Day = 3,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        Hour = 4,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        Minute = 5,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        Month = 2,
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        Second = 6,
        [VariantType(new VarEnum[] { VarEnum.VT_UI2 })]
        Year = 1
    }
}

