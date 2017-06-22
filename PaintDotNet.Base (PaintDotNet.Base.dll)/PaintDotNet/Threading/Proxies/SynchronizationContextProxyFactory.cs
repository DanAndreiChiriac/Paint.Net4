namespace PaintDotNet.Threading.Proxies
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Threading;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    internal sealed class SynchronizationContextProxyFactory : ObjectRefProxyFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            new SynchronizationContextProxy((ISynchronizationContext) objectRef, proxyOptions);
    }
}

