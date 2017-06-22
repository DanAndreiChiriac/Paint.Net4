namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Concurrency;
    using PaintDotNet.Functional;
    using System;
    using System.Threading;

    public sealed class SynchronizationContextDispatcher : RefTrackedObject, ISynchronizationContext, IDispatcher, IObjectRef, IDisposable, IIsDisposed, IAsyncWorkQueue, IThreadAffinitizedObject
    {
        [ThreadStatic]
        private static SynchronizationContextDispatcher current;
        private SynchronizationContext syncContext = SynchronizationContext.Current;
        private Thread thread = Thread.CurrentThread;

        private SynchronizationContextDispatcher()
        {
        }

        public IAsync BeginTry(Action callback)
        {
            base.VerifyAccess();
            IAsyncSource async = Async.NewSource();
            this.syncContext.Post(delegate (object _) {
                async.SetResult(callback.Try());
            });
            return async;
        }

        public bool CheckAccess() => 
            (base.CheckAccess() && (this.thread == Thread.CurrentThread));

        public static ISynchronizationContext CreateRef()
        {
            SynchronizationContextDispatcher current = SynchronizationContextDispatcher.current;
            if (current == null)
            {
                current = new SynchronizationContextDispatcher();
                SynchronizationContextDispatcher.current = current;
            }
            return current.CreateRef<ISynchronizationContext>();
        }

        protected override void Dispose(bool disposing)
        {
            this.thread = null;
            this.syncContext = null;
            base.Dispose(disposing);
        }

        public void Post(SendOrPostCallback d, object state)
        {
            base.VerifyAccess();
            this.syncContext.Post(d, state);
        }

        public void Send(SendOrPostCallback d, object state)
        {
            base.VerifyAccess();
            this.syncContext.Send(d, state);
        }

        public void VerifyAccess()
        {
            if (!this.CheckAccess())
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
        }
    }
}

