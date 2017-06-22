namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class FontFamilyProxy : ObjectRefProxy<IFontFamily>, IFontFamily, IFontList, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FontFamilyProxy(IFontFamily objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IFont GetFirstMatchingFont(FontWeight weight, FontStretch stretch, FontStyle style) => 
            base.innerRefT.GetFirstMatchingFont(weight, stretch, style);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IFont GetFont(int index) => 
            base.innerRefT.GetFont(index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IFontList GetMatchingFonts(FontWeight weight, FontStretch stretch, FontStyle style) => 
            base.innerRefT.GetMatchingFonts(weight, stretch, style);

        public ILocalizedStrings FamilyNames =>
            base.innerRefT.FamilyNames;

        public IFontCollection FontCollection =>
            base.innerRefT.FontCollection;

        public int FontCount =>
            base.innerRefT.FontCount;
    }
}

