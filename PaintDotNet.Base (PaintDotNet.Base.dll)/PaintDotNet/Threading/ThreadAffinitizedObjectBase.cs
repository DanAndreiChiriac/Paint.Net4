namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using System;
    using System.Threading;

    public class ThreadAffinitizedObjectBase : IThreadAffinitizedObject
    {
        private int managedThreadID = Thread.CurrentThread.ManagedThreadId;
        private SynchronizationContext syncContext = SynchronizationContext.Current;

        protected ThreadAffinitizedObjectBase()
        {
        }

        public bool CheckAccess() => 
            (Thread.CurrentThread.ManagedThreadId == this.managedThreadID);

        public void VerifyAccess()
        {
            if (!this.CheckAccess())
            {
                ExceptionUtil.ThrowInvalidOperationException("The object may not be accessed from this thread");
            }
        }

        public SynchronizationContext SyncContext =>
            this.syncContext;
    }
}

