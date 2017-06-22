namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class FontListProxy : ObjectRefProxy<IFontList>, IFontList, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FontListProxy(IFontList objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IFont GetFont(int index) => 
            base.innerRefT.GetFont(index);

        public IFontCollection FontCollection =>
            base.innerRefT.FontCollection;

        public int FontCount =>
            base.innerRefT.FontCount;
    }
}

