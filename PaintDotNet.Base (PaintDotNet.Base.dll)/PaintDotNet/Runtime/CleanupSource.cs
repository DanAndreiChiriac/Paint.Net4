namespace PaintDotNet.Runtime
{
    using System;
    using System.Threading;

    public abstract class CleanupSource
    {
        private int state = 0;

        protected abstract void OnPerformCleanup();
        protected virtual void OnPerformCleanupQueued()
        {
        }

        internal void PerformCleanup()
        {
            this.PerformCleanupImpl();
        }

        private void PerformCleanupImpl()
        {
            SpinWait wait = new SpinWait();
            while (true)
            {
                CleanupSourceState state = this.State;
                CleanupSourceState state2 = (state | CleanupSourceState.Cleaning) & ~CleanupSourceState.CleanupNeeded;
                CleanupSourceState state3 = (CleanupSourceState) Interlocked.CompareExchange(ref this.state, (int) state2, (int) state);
                if (state == state3)
                {
                    break;
                }
                wait.SpinOnce();
            }
            this.OnPerformCleanup();
            wait.Reset();
            while (true)
            {
                CleanupSourceState state4 = this.State;
                CleanupSourceState state5 = state4 & ~CleanupSourceState.Cleaning;
                CleanupSourceState state6 = (CleanupSourceState) Interlocked.CompareExchange(ref this.state, (int) state5, (int) state4);
                if (state4 == state6)
                {
                    break;
                }
                wait.SpinOnce();
            }
        }

        public void RequestCleanup()
        {
            CleanupSourceState state = this.State;
            if ((state & CleanupSourceState.CleanupNeeded) != CleanupSourceState.CleanupNeeded)
            {
                CleanupSourceState state2 = state | CleanupSourceState.CleanupNeeded;
                CleanupSourceState state3 = (CleanupSourceState) Interlocked.CompareExchange(ref this.state, (int) state2, (int) state);
                if ((state == state3) && CleanupThread.EnsureEnqueued(this))
                {
                    this.OnPerformCleanupQueued();
                }
            }
        }

        public CleanupSourceState State =>
            ((CleanupSourceState) Thread.VolatileRead(ref this.state));
    }
}

