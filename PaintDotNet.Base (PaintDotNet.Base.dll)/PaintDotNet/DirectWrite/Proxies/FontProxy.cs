namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class FontProxy : ObjectRefProxy<IFont>, IFont, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FontProxy(IFont objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasCharacter(uint ucs4Value) => 
            base.innerRefT.HasCharacter(ucs4Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ILocalizedStrings TryGetInformationalStrings(InformationalStringID informationalStringID) => 
            base.innerRefT.TryGetInformationalStrings(informationalStringID);

        public ILocalizedStrings FaceNames =>
            base.innerRefT.FaceNames;

        public IFontFamily FontFamily =>
            base.innerRefT.FontFamily;

        public bool IsSymbolFont =>
            base.innerRefT.IsSymbolFont;

        public FontMetrics Metrics =>
            base.innerRefT.Metrics;

        public FontSimulations Simulations =>
            base.innerRefT.Simulations;

        public FontStretch Stretch =>
            base.innerRefT.Stretch;

        public FontStyle Style =>
            base.innerRefT.Style;

        public FontWeight Weight =>
            base.innerRefT.Weight;
    }
}

