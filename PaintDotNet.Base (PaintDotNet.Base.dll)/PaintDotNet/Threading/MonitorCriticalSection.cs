namespace PaintDotNet.Threading
{
    using System;
    using System.Threading;

    public sealed class MonitorCriticalSection : CriticalSection
    {
        private object monitor = new object();

        public MonitorCriticalSection()
        {
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            this.monitor = null;
            base.Dispose(disposing);
        }

        public override void Enter()
        {
            Monitor.Enter(this.monitor);
        }

        public override void Exit()
        {
            Monitor.Exit(this.monitor);
        }
    }
}

