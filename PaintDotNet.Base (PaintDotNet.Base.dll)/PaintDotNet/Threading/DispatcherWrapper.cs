namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Concurrency;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Windows.Threading;

    public sealed class DispatcherWrapper : RefTrackedObject, IDispatcher, IObjectRef, IDisposable, IIsDisposed, IAsyncWorkQueue, IThreadAffinitizedObject
    {
        private Dispatcher dispatcher;

        public DispatcherWrapper(Dispatcher dispatcher)
        {
            Validate.IsNotNull<Dispatcher>(dispatcher, "dispatcher");
            this.dispatcher = dispatcher;
        }

        public IAsync BeginTry(Action callback)
        {
            IAsyncSource source = Async.NewSource();
            this.dispatcher.BeginInvoke(delegate {
                try
                {
                    Result @void = Result.Void;
                    callback();
                    source.SetResult(@void);
                }
                catch (Exception exception1)
                {
                    Result result = Result.NewError(exception1);
                    source.SetResult(result);
                }
            }, Array.Empty<object>());
            return source.AsReceiveOnly();
        }

        public bool CheckAccess() => 
            this.dispatcher.CheckAccess();

        public static IDispatcher CreateRef(Dispatcher dispatcher) => 
            new DispatcherWrapper(dispatcher);

        protected override void Dispose(bool disposing)
        {
            this.dispatcher = null;
            base.Dispose(disposing);
        }

        public void VerifyAccess()
        {
            this.dispatcher.VerifyAccess();
        }
    }
}

