namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class TypographyProxy : ObjectRefProxy<ITypography>, ITypography, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TypographyProxy(ITypography objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddFontFeature(FontFeature fontFeature)
        {
            base.innerRefT.AddFontFeature(fontFeature);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FontFeature GetFontFeature(int fontFeatureIndex) => 
            base.innerRefT.GetFontFeature(fontFeatureIndex);

        public int FontFeatureCount =>
            base.innerRefT.FontFeatureCount;
    }
}

