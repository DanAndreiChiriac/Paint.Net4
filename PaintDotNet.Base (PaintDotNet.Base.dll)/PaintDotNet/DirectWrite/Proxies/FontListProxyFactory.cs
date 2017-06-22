namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class FontListProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new FontListProxy((IFontList) objectRef, proxyOptions);
    }
}

