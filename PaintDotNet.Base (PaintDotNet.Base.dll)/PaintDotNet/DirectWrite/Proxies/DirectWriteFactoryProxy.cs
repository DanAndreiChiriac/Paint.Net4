namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DirectWriteFactoryProxy : ObjectRefProxy<IDirectWriteFactory>, IDirectWriteFactory, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DirectWriteFactoryProxy(IDirectWriteFactory objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITextRenderingParams CreateCustomTextRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, PixelGeometry pixelGeometry, TextRenderingMode renderingMode) => 
            base.innerRefT.CreateCustomTextRenderingParams(gamma, enhancedContrast, clearTypeLevel, pixelGeometry, renderingMode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IInlineObject CreateEllipsisTrimmingSign(ITextFormat textFormat) => 
            base.innerRefT.CreateEllipsisTrimmingSign(textFormat);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITextLayout CreateGdiCompatibleTextLayout(string text, ITextFormat textFormat, float layoutWidth, float layoutHeight, float pixelsPerDip, Matrix3x2Float? transform, bool useGdiNatural) => 
            base.innerRefT.CreateGdiCompatibleTextLayout(text, textFormat, layoutWidth, layoutHeight, pixelsPerDip, transform, useGdiNatural);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITextRenderingParams CreateMonitorTextRenderingParams(IntPtr hMonitor) => 
            base.innerRefT.CreateMonitorTextRenderingParams(hMonitor);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITextFormat CreateTextFormat(string fontFamilyName, IFontCollection fontCollection, FontWeight fontWeight, FontStyle fontStyle, FontStretch fontStretch, float fontSize, CultureInfo locale) => 
            base.innerRefT.CreateTextFormat(fontFamilyName, fontCollection, fontWeight, fontStyle, fontStretch, fontSize, locale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITextLayout CreateTextLayout(string text, ITextFormat textFormat, float maxWidth, float maxHeight) => 
            base.innerRefT.CreateTextLayout(text, textFormat, maxWidth, maxHeight);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITextRenderingParams CreateTextRenderingParams() => 
            base.innerRefT.CreateTextRenderingParams();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITypography CreateTypography() => 
            base.innerRefT.CreateTypography();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDirectWriteGdiInterop GetGdiInterop() => 
            base.innerRefT.GetGdiInterop();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IFontCollection GetSystemFontCollection(bool checkForUpdates) => 
            base.innerRefT.GetSystemFontCollection(checkForUpdates);
    }
}

