namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum PngBkgdProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI1, VarEnum.VT_UI2, VarEnum.VT_VECTOR | VarEnum.VT_UI2 })]
        BackgroundColor = 1
    }
}

