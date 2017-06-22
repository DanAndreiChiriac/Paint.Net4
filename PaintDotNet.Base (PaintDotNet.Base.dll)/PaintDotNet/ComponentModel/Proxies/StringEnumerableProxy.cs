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
    public class StringEnumerableProxy : ObjectRefProxy<IStringEnumerable>, IStringEnumerable, IObjectRef, IDisposable, IIsDisposed, IEnumerable<string>, IEnumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StringEnumerableProxy(IStringEnumerable objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerator<string> GetEnumerator() => 
            base.innerRefT.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual IEnumerator OnExplicitIEnumerableGetEnumerator() => 
            base.innerRefT.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.OnExplicitIEnumerableGetEnumerator();
    }
}

