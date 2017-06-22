namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum PngIccpProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_VECTOR | VarEnum.VT_UI1 })]
        Data = 2,
        [VariantType(new VarEnum[] { VarEnum.VT_LPSTR })]
        Name = 1
    }
}

