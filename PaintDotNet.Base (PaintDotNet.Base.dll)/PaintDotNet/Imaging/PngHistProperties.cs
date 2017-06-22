namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum PngHistProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_VECTOR | VarEnum.VT_UI2 })]
        Frequencies = 1
    }
}

