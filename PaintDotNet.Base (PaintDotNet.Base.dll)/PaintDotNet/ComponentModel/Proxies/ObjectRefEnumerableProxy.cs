namespace PaintDotNet.ComponentModel.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class ObjectRefEnumerableProxy : ObjectRefProxy<IObjectRefEnumerable>, IObjectRefEnumerable, IObjectRef, IDisposable, IIsDisposed, IEnumerable<IObjectRef>, IEnumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ObjectRefEnumerableProxy(IObjectRefEnumerable objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerator<IObjectRef> GetEnumerator() => 
            base.innerRefT.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual IEnumerator OnExplicitIEnumerableGetEnumerator() => 
            base.innerRefT.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.OnExplicitIEnumerableGetEnumerator();
    }
}

