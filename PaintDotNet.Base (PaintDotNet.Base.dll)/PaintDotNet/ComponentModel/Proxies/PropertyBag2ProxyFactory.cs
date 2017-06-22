namespace PaintDotNet.ComponentModel.Proxies
{
    using PaintDotNet.ComponentModel;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class PropertyBag2ProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new PropertyBag2Proxy((IPropertyBag2) objectRef, proxyOptions);
    }
}

