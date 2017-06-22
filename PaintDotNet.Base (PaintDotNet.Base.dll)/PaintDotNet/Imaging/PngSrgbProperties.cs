namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum PngSrgbProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        RenderingIntent = 1
    }
}

