namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Concurrent;
    using System.Threading;

    public sealed class PdnSynchronizationContext : SynchronizationContext
    {
        private readonly ConcurrentSet<Action> collatedCallbacks = new ConcurrentSet<Action>();
        private static PdnSynchronizationContext instance;
        private bool isInstalled;
        private int isProcessQueuePosted;
        private SynchronizationContext prevSyncContext;
        private readonly SendOrPostCallback processCollatedCallbackCallback;
        private readonly SendOrPostCallback processQueueCallback;
        private readonly ConcurrentQueue<TupleStruct<SendOrPostCallback, object>> queue = new ConcurrentQueue<TupleStruct<SendOrPostCallback, object>>();
        private readonly ConcurrentBag<ManualResetEvent> sendEventCache = new ConcurrentBag<ManualResetEvent>();
        private SleepExDelegate sleepExCallback;
        private Thread syncThread;
        private WaitForMultipleObjectsExDelegate waitForMultipleObjectsExCallback;

        private PdnSynchronizationContext(SynchronizationContext prevSyncContext, WaitForMultipleObjectsExDelegate waitForMultipleObjectsExCallback, SleepExDelegate sleepExCallback)
        {
            Validate.Begin().IsNotNull<SynchronizationContext>(prevSyncContext, "prevSyncContext").IsNotNull<WaitForMultipleObjectsExDelegate>(waitForMultipleObjectsExCallback, "waitForMultipleObjectsExCallback").IsNotNull<SleepExDelegate>(sleepExCallback, "sleepExCallback").Check();
            this.syncThread = Thread.CurrentThread;
            this.prevSyncContext = prevSyncContext;
            this.waitForMultipleObjectsExCallback = waitForMultipleObjectsExCallback;
            this.sleepExCallback = sleepExCallback;
            this.processQueueCallback = new SendOrPostCallback(this.ProcessQueueCallback);
            this.processCollatedCallbackCallback = new SendOrPostCallback(this.ProcessCollatedCallback);
            base.SetWaitNotificationRequired();
        }

        public bool CheckAccess() => 
            (this.syncThread == Thread.CurrentThread);

        public override SynchronizationContext CreateCopy() => 
            this;

        public void EnsurePosted(Action collatedCallback)
        {
            Validate.IsNotNull<Action>(collatedCallback, "collatedCallback");
            if (this.collatedCallbacks.Add(collatedCallback))
            {
                this.Post(this.processCollatedCallbackCallback, collatedCallback);
            }
        }

        private void EnsureProcessQueueIsPosted()
        {
            if (Interlocked.Exchange(ref this.isProcessQueuePosted, 1) == 0)
            {
                this.prevSyncContext.Post(this.processQueueCallback, null);
            }
        }

        public static PdnSynchronizationContextController Install(WaitForMultipleObjectsExDelegate waitForMultipleObjectsExCallback, SleepExDelegate sleepExCallback)
        {
            SynchronizationContext current = SynchronizationContext.Current;
            if (current == null)
            {
                ExceptionUtil.ThrowInvalidOperationException("An SynchronizationContext must already be installed before PdnSynchronizationContext may be installed");
            }
            PdnSynchronizationContext context = new PdnSynchronizationContext(current, waitForMultipleObjectsExCallback, sleepExCallback);
            if (Interlocked.CompareExchange<PdnSynchronizationContext>(ref instance, context, null) != null)
            {
                ExceptionUtil.ThrowInvalidOperationException("Install() may only be called once");
            }
            SynchronizationContext.SetSynchronizationContext(context);
            context.isInstalled = true;
            return new PdnSynchronizationContextController(context);
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            this.queue.Enqueue(TupleStruct.Create<SendOrPostCallback, object>(d, state));
            this.EnsureProcessQueueIsPosted();
        }

        private void ProcessCollatedCallback(object context)
        {
            Action item = (Action) context;
            if (!this.collatedCallbacks.TryRemove(item))
            {
                ExceptionUtil.ThrowInternalErrorException();
            }
            item();
        }

        private void ProcessQueue()
        {
            while (this.queue.Any<TupleStruct<SendOrPostCallback, object>>())
            {
                this.sleepExCallback(0, true);
                foreach (TupleStruct<SendOrPostCallback, object> struct2 in this.queue.DequeueAll<TupleStruct<SendOrPostCallback, object>>())
                {
                    struct2.Item1(struct2.Item2);
                }
            }
        }

        private void ProcessQueueCallback(object ignored)
        {
            while (Interlocked.Exchange(ref this.isProcessQueuePosted, 0) == 1)
            {
                this.ProcessQueue();
            }
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            if (this.syncThread == Thread.CurrentThread)
            {
                d(state);
            }
            else
            {
                ManualResetEvent finishedEvent;
                if (!this.sendEventCache.TryTake(out finishedEvent))
                {
                    finishedEvent = new ManualResetEvent(false);
                }
                this.prevSyncContext.Post(delegate {
                    try
                    {
                        d(state);
                    }
                    finally
                    {
                        finishedEvent.Set();
                    }
                });
                finishedEvent.WaitOne();
                finishedEvent.Reset();
                this.sendEventCache.Add(finishedEvent);
            }
        }

        internal static void Uninstall(PdnSynchronizationContext oldInstance)
        {
            if (oldInstance != instance)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
            if (oldInstance.syncThread != Thread.CurrentThread)
            {
                ExceptionUtil.ThrowInvalidOperationException("PdnSynchronizationContext may only be uninstalled on the thread it was installed on");
            }
            oldInstance.ProcessQueue();
            SynchronizationContext.SetSynchronizationContext(oldInstance.prevSyncContext);
            oldInstance.isInstalled = false;
        }

        public void VerifyAccess()
        {
            if (!this.CheckAccess())
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
        }

        public override int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout)
        {
            this.VerifyAccess();
            bool alertable = !ProtectedRegion.IsThreadInNonPumpingRegion;
            return this.waitForMultipleObjectsExCallback(waitHandles, waitAll, millisecondsTimeout, alertable);
        }

        public static PdnSynchronizationContext Instance =>
            instance;

        internal bool IsInstalled =>
            this.isInstalled;

        public bool IsQueueEmpty =>
            (this.queue.Count == 0);

        public SynchronizationContext PreviousSynchronizationContext =>
            this.prevSyncContext;

        public Thread SynchronizationThread =>
            this.syncThread;
    }
}

