namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class PaletteProxy : ObjectRefProxy<IPalette>, IPalette, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PaletteProxy(IPalette objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public IList<ColorBgra32> Colors =>
            base.innerRefT.Colors;

        public bool HasAlpha =>
            base.innerRefT.HasAlpha;

        public bool IsBlackWhite =>
            base.innerRefT.IsBlackWhite;

        public bool IsGrayscale =>
            base.innerRefT.IsGrayscale;

        public BitmapPaletteType PaletteType =>
            base.innerRefT.PaletteType;
    }
}

