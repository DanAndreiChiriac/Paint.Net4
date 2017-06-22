namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum JpegLuminanceProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_VECTOR | VarEnum.VT_UI2 })]
        LuminanceTable = 1
    }
}

