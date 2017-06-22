namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class SimplifiedGeometrySinkProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new SimplifiedGeometrySinkProxy((ISimplifiedGeometrySink) objectRef, proxyOptions);
    }
}

