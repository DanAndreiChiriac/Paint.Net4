namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum PngGamaProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI4 })]
        Gamma = 1
    }
}

