namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class FontCollectionProxy : ObjectRefProxy<IFontCollection>, IFontCollection, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FontCollectionProxy(IFontCollection objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IFontFamily GetFontFamily(int index) => 
            base.innerRefT.GetFontFamily(index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int IndexOfFamilyName(string familyName) => 
            base.innerRefT.IndexOfFamilyName(familyName);

        public int FontFamilyCount =>
            base.innerRefT.FontFamilyCount;
    }
}

