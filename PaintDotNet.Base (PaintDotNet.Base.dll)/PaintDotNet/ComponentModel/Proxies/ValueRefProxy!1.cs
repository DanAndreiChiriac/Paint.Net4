namespace PaintDotNet.ComponentModel.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class ValueRefProxy<T> : ObjectRefProxy<IValueRef<T>>, IValueRef<T>, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueRefProxy(IValueRef<T> objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public T Value =>
            base.innerRefT.Value;
    }
}

