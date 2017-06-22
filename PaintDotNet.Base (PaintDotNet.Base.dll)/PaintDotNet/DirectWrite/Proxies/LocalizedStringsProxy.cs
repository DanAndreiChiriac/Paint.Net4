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
    public class LocalizedStringsProxy : ObjectRefProxy<ILocalizedStrings>, ILocalizedStrings, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LocalizedStringsProxy(ILocalizedStrings objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CultureInfo GetLocale(int index) => 
            base.innerRefT.GetLocale(index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetString(int index) => 
            base.innerRefT.GetString(index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int IndexOfLocale(CultureInfo locale) => 
            base.innerRefT.IndexOfLocale(locale);

        public int Count =>
            base.innerRefT.Count;
    }
}

