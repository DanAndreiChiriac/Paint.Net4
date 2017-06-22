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
    public class StringEnumeratorProxy : ObjectRefProxy<IStringEnumerator>, IStringEnumerator, IObjectRef, IDisposable, IIsDisposed, IEnumerator<string>, IEnumerator, ICloneable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StringEnumeratorProxy(IStringEnumerator objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Clone() => 
            base.innerRefT.Clone();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext() => 
            base.innerRefT.MoveNext();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            base.innerRefT.Reset();
        }

        public string Current =>
            base.innerRefT.Current;

        object IEnumerator.Current =>
            base.innerRefT.Current;
    }
}

