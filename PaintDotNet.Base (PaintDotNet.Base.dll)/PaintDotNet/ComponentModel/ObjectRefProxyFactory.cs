namespace PaintDotNet.ComponentModel
{
    using System;

    public abstract class ObjectRefProxyFactory
    {
        protected ObjectRefProxyFactory()
        {
        }

        public abstract ObjectRefProxy CreateProxy(IObjectRef objectRef, ObjectRefProxyOptions proxyOptions);
    }
}

