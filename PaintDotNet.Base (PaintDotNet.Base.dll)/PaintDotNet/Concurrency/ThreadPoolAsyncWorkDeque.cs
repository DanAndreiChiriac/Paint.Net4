namespace PaintDotNet.Concurrency
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Threading;

    public sealed class ThreadPoolAsyncWorkDeque : Disposable, IAsyncWorkDeque, IAsyncWorkQueue
    {
        private Semaphore callbackSemaphore;
        private Deque<Action> cancelFnQ;
        private DateTime lastTrimTimeUtc;
        private bool pleaseAbort;
        private static readonly TimeSpan preferredTrimInterval = TimeSpan.FromSeconds(1.0);
        private Deque<Action> runFnQ;
        private readonly object sync;
        private WaitCallback threadPoolCallback;

        public ThreadPoolAsyncWorkDeque() : this(0)
        {
        }

        public ThreadPoolAsyncWorkDeque(int maxAtOnce)
        {
            this.sync = new object();
            this.runFnQ = new Deque<Action>();
            this.cancelFnQ = new Deque<Action>();
            this.lastTrimTimeUtc = DateTime.UtcNow;
            this.threadPoolCallback = new WaitCallback(this.ThreadPoolCallback);
            if (maxAtOnce == 0)
            {
                this.callbackSemaphore = null;
            }
            else
            {
                this.callbackSemaphore = new Semaphore(maxAtOnce, maxAtOnce);
            }
        }

        public IAsync BeginTry(Action callback) => 
            this.Enqueue(QueueSide.Back, callback);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.pleaseAbort = true;
                Deque<Action> cancelFnQ = null;
                object sync = this.Sync;
                lock (sync)
                {
                    Deque<Action> runFnQ = this.runFnQ;
                    this.runFnQ = null;
                    cancelFnQ = this.cancelFnQ;
                    this.cancelFnQ = null;
                }
                if (cancelFnQ != null)
                {
                    using (Deque<Action>.Enumerator enumerator = cancelFnQ.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            enumerator.Current();
                        }
                    }
                }
                if (this.callbackSemaphore != null)
                {
                    this.callbackSemaphore.WaitOne();
                    this.callbackSemaphore.Close();
                    this.callbackSemaphore = null;
                }
            }
            base.Dispose(disposing);
        }

        public IAsync Enqueue(QueueSide qSide, Action callback)
        {
            Validate.Begin().IsNotNull<Action>(callback, "callback").IsTrue(((qSide == QueueSide.Front) || (qSide == QueueSide.Back)), "qSide is not a valid member of the QueueSide enumeration").Check();
            IAsyncSource source = Async.NewSource();
            if (this.pleaseAbort)
            {
                source.Throw(new OperationCanceledException("The work queue has shut down."));
            }
            else
            {
                object sync = this.Sync;
                lock (sync)
                {
                    Action item = delegate {
                        callback.Try().Into(source);
                    };
                    Action action2 = delegate {
                        source.Throw(new OperationCanceledException("The dispatcher has shut down."));
                    };
                    if (qSide == QueueSide.Front)
                    {
                        this.runFnQ.EnqueueFront(item);
                        this.cancelFnQ.EnqueueFront(action2);
                    }
                    else
                    {
                        this.runFnQ.Enqueue(item);
                        this.cancelFnQ.Enqueue(action2);
                    }
                    ThreadPool.QueueUserWorkItem(this.threadPoolCallback);
                }
            }
            return source.AsReceiveOnly();
        }

        private void ThreadPoolCallback(object ignored)
        {
            if (this.callbackSemaphore != null)
            {
                this.callbackSemaphore.WaitOne();
            }
            try
            {
                Action action;
                object sync = this.Sync;
                lock (sync)
                {
                    if (this.pleaseAbort)
                    {
                        return;
                    }
                    action = this.runFnQ.Dequeue();
                    this.cancelFnQ.Dequeue();
                    if ((DateTime.UtcNow - this.lastTrimTimeUtc) >= preferredTrimInterval)
                    {
                        this.runFnQ.TrimExcess();
                        this.cancelFnQ.TrimExcess();
                        this.lastTrimTimeUtc = DateTime.UtcNow;
                    }
                }
                action();
            }
            finally
            {
                if (this.callbackSemaphore != null)
                {
                    this.callbackSemaphore.Release();
                }
            }
        }

        private object Sync =>
            this.sync;
    }
}

