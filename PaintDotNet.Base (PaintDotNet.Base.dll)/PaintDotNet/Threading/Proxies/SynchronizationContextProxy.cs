namespace PaintDotNet.Threading.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Concurrency;
    using PaintDotNet.Threading;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class SynchronizationContextProxy : ObjectRefProxy<ISynchronizationContext>, ISynchronizationContext, IDispatcher, IObjectRef, IDisposable, IIsDisposed, IAsyncWorkQueue, IThreadAffinitizedObject
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SynchronizationContextProxy(ISynchronizationContext objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IAsync BeginTry(Action callback) => 
            base.innerRefT.BeginTry(callback);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckAccess() => 
            base.innerRefT.CheckAccess();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Post(SendOrPostCallback d, object state)
        {
            base.innerRefT.Post(d, state);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Send(SendOrPostCallback d, object state)
        {
            base.innerRefT.Send(d, state);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void VerifyAccess()
        {
            base.innerRefT.VerifyAccess();
        }
    }
}

