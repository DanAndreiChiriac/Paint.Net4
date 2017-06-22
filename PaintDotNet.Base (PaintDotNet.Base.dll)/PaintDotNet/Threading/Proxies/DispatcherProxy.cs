namespace PaintDotNet.Threading.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Concurrency;
    using PaintDotNet.Threading;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DispatcherProxy : ObjectRefProxy<IDispatcher>, IDispatcher, IObjectRef, IDisposable, IIsDisposed, IAsyncWorkQueue, IThreadAffinitizedObject
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DispatcherProxy(IDispatcher objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAsync BeginTry(Action callback) => 
            base.innerRefT.BeginTry(callback);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckAccess() => 
            base.innerRefT.CheckAccess();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void VerifyAccess()
        {
            base.innerRefT.VerifyAccess();
        }
    }
}

