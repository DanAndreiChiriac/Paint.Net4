namespace PaintDotNet.ComponentModel
{
    using PaintDotNet.Diagnostics;
    using System;

    internal sealed class DelegateObjectRefProxyFactory : ObjectRefProxyFactory
    {
        private Func<IObjectRef, ObjectRefProxyOptions, ObjectRefProxy> proxyFactory;

        public DelegateObjectRefProxyFactory(Func<IObjectRef, ObjectRefProxyOptions, ObjectRefProxy> proxyFactory)
        {
            Validate.IsNotNull<Func<IObjectRef, ObjectRefProxyOptions, ObjectRefProxy>>(proxyFactory, "proxyFactory");
            this.proxyFactory = proxyFactory;
        }

        public override ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions) => 
            this.proxyFactory(objectRef, proxyOptions);
    }
}

