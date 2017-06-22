namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class TextRenderingParamsProxy : ObjectRefProxy<ITextRenderingParams>, ITextRenderingParams, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRenderingParamsProxy(ITextRenderingParams objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public float ClearTypeLevel =>
            base.innerRefT.ClearTypeLevel;

        public float EnhancedContrast =>
            base.innerRefT.EnhancedContrast;

        public float Gamma =>
            base.innerRefT.Gamma;

        public PaintDotNet.DirectWrite.PixelGeometry PixelGeometry =>
            base.innerRefT.PixelGeometry;

        public TextRenderingMode RenderingMode =>
            base.innerRefT.RenderingMode;
    }
}

