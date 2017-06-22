namespace PaintDotNet.ComponentModel.Proxies
{
    using PaintDotNet.ComponentModel;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class ObjectRefEnumeratorProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new ObjectRefEnumeratorProxy((IObjectRefEnumerator) objectRef, proxyOptions);
    }
}

