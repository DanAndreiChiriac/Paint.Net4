namespace PaintDotNet.Imaging
{
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    public enum PngItxtProperties
    {
        [VariantType(new VarEnum[] { VarEnum.VT_UI1 })]
        CompressionFlag = 2,
        [VariantType(new VarEnum[] { VarEnum.VT_LPSTR })]
        Keyword = 1,
        [VariantType(new VarEnum[] { VarEnum.VT_LPSTR })]
        LanguageTag = 3,
        [VariantType(new VarEnum[] { VarEnum.VT_LPWSTR })]
        Text = 5,
        [VariantType(new VarEnum[] { VarEnum.VT_LPWSTR })]
        TranslatedKeyword = 4
    }
}

