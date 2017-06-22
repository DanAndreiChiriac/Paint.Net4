namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DirectWriteGdiInteropProxy : ObjectRefProxy<IDirectWriteGdiInterop>, IDirectWriteGdiInterop, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DirectWriteGdiInteropProxy(IDirectWriteGdiInterop objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IFont CreateFontFromGdiFontFaceName(string gdiFontFaceName) => 
            base.innerRefT.CreateFontFromGdiFontFaceName(gdiFontFaceName);
    }
}

