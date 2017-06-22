namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using System;
    using System.Threading;

    public sealed class MutexCriticalSection : CriticalSection
    {
        private Mutex mutex = new Mutex(false);

        public MutexCriticalSection()
        {
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            DisposableUtil.Free<Mutex>(ref this.mutex, disposing);
            base.Dispose(disposing);
        }

        public override void Enter()
        {
            this.mutex.WaitOne();
        }

        public override void Exit()
        {
            this.mutex.ReleaseMutex();
        }
    }
}

