namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum GifApplicationExtensionProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_VECTOR | VarEnum.VT_UI1 })]
        Application = 1,
        [VariantType(new VarEnum[] { VarEnum.VT_VECTOR | VarEnum.VT_UI1 })]
        Data = 2
    }
}

