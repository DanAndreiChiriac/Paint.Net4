namespace PaintDotNet.Threading
{
    using System;
    using System.Threading;

    public sealed class MonitorConditionVariable : ConditionVariable
    {
        private int enterCount;
        private object monitor = new object();

        public MonitorConditionVariable()
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
            this.enterCount++;
        }

        public override void Exit()
        {
            this.enterCount--;
            Monitor.Exit(this.monitor);
        }

        public override void Pulse()
        {
            Monitor.Pulse(this.monitor);
        }

        public override void PulseAll()
        {
            Monitor.PulseAll(this.monitor);
        }

        public override void Wait()
        {
            Monitor.Wait(this.monitor);
        }
    }
}

