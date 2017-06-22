namespace PaintDotNet.DirectWrite
{
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    public static class DirectWriteObjectRefExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDirectWriteFactory CreateRef(this IDirectWriteFactory objectRef) => 
            ((IDirectWriteFactory) objectRef.CreateRef(typeof(IDirectWriteFactory)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDirectWriteGdiInterop CreateRef(this IDirectWriteGdiInterop objectRef) => 
            ((IDirectWriteGdiInterop) objectRef.CreateRef(typeof(IDirectWriteGdiInterop)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IDirectWriteObject CreateRef(this IDirectWriteObject objectRef) => 
            ((IDirectWriteObject) objectRef.CreateRef(typeof(IDirectWriteObject)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IFont CreateRef(this IFont objectRef) => 
            ((IFont) objectRef.CreateRef(typeof(IFont)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IFontCollection CreateRef(this IFontCollection objectRef) => 
            ((IFontCollection) objectRef.CreateRef(typeof(IFontCollection)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IFontFamily CreateRef(this IFontFamily objectRef) => 
            ((IFontFamily) objectRef.CreateRef(typeof(IFontFamily)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IFontList CreateRef(this IFontList objectRef) => 
            ((IFontList) objectRef.CreateRef(typeof(IFontList)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static IInlineObject CreateRef(this IInlineObject objectRef) => 
            ((IInlineObject) objectRef.CreateRef(typeof(IInlineObject)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static ILocalizedStrings CreateRef(this ILocalizedStrings objectRef) => 
            ((ILocalizedStrings) objectRef.CreateRef(typeof(ILocalizedStrings)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static ITextFormat CreateRef(this ITextFormat objectRef) => 
            ((ITextFormat) objectRef.CreateRef(typeof(ITextFormat)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static ITextLayout CreateRef(this ITextLayout objectRef) => 
            ((ITextLayout) objectRef.CreateRef(typeof(ITextLayout)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static ITextRenderingParams CreateRef(this ITextRenderingParams objectRef) => 
            ((ITextRenderingParams) objectRef.CreateRef(typeof(ITextRenderingParams)));

        [MethodImpl(MethodImplOptions.AggressiveInlining), GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
        public static ITypography CreateRef(this ITypography objectRef) => 
            ((ITypography) objectRef.CreateRef(typeof(ITypography)));
    }
}

