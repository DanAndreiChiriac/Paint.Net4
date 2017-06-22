namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Concurrency;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Threading;

    public sealed class ThreadDispatcher : RefTrackedComponent, IDispatcher, IObjectRef, IDisposable, IIsDisposed, IAsyncWorkQueue, IThreadAffinitizedObject, IAsyncWorkDeque
    {
        private Deque<Action> cancelFnQ;
        private Thread execThread;
        private DateTime lastTrimTimeUtc;
        private bool pleaseAbort;
        private static readonly TimeSpan preferredTrimInterval = TimeSpan.FromSeconds(1.0);
        private Deque<Action> runFnQ;

        public ThreadDispatcher() : this(ApartmentState.MTA)
        {
        }

        public ThreadDispatcher(ApartmentState apartmentState)
        {
            this.runFnQ = new Deque<Action>();
            this.cancelFnQ = new Deque<Action>();
            this.lastTrimTimeUtc = DateTime.UtcNow;
            this.execThread = new Thread(new ThreadStart(this.ExecThread));
            this.execThread.SetApartmentState(apartmentState);
            this.execThread.Name = "ThreadDispatcher";
            this.execThread.IsBackground = true;
            this.execThread.Start();
        }

        public IAsync BeginTry(Action callback) => 
            this.Enqueue(QueueSide.Back, callback);

        public bool CheckAccess() => 
            (Thread.CurrentThread == this.execThread);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.pleaseAbort = true;
                object sync = base.Sync;
                lock (sync)
                {
                    Monitor.Pulse(base.Sync);
                }
                if (!base.CheckAccess())
                {
                    this.execThread.Join();
                }
                this.execThread = null;
                using (Deque<Action>.Enumerator enumerator = this.cancelFnQ.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current();
                    }
                }
                this.runFnQ = null;
                this.cancelFnQ = null;
            }
            base.Dispose(disposing);
        }

        public IAsync Enqueue(QueueSide qSide, Action callback)
        {
            base.VerifyAccess();
            Validate.Begin().IsNotNull<Action>(callback, "callback").IsTrue(((qSide == QueueSide.Front) || (qSide == QueueSide.Back)), "qSide is not a valid member of the QueueSide enumeration").Check();
            IAsyncSource source = Async.NewSource();
            if (this.pleaseAbort)
            {
                source.Throw(new OperationCanceledException("The dispatcher has shut down."));
            }
            else
            {
                object sync = base.Sync;
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
                    Monitor.Pulse(base.Sync);
                }
            }
            return source.AsReceiveOnly();
        }

        private void ExecThread()
        {
            while (this.ExecThreadLoop())
            {
            }
        }

        private bool ExecThreadLoop()
        {
            Action action;
            object sync = base.Sync;
            lock (sync)
            {
                if (!this.pleaseAbort)
                {
                    goto Label_002C;
                }
                return false;
            Label_0020:
                Monitor.Wait(base.Sync);
            Label_002C:
                if ((this.runFnQ.Count == 0) && !this.pleaseAbort)
                {
                    goto Label_0020;
                }
                if (this.pleaseAbort)
                {
                    return false;
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
            return true;
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

