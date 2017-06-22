namespace PaintDotNet.Functional
{
    using PaintDotNet.Threading;
    using System;
    using System.Threading;

    public abstract class LazyResult<T> : Result<T>
    {
        protected LazyThreadSafetyMode lazyThreadSafetyMode;
        private CriticalSection sync;
        protected object valueFactory;

        internal LazyResult() : this(new MonitorCriticalSection())
        {
        }

        internal LazyResult(CriticalSection sync)
        {
            this.sync = sync;
        }

        public sealed override bool IsEvaluated
        {
            get
            {
                LazyThreadSafetyMode lazyThreadSafetyMode = this.lazyThreadSafetyMode;
                if ((lazyThreadSafetyMode == LazyThreadSafetyMode.None) || (lazyThreadSafetyMode != LazyThreadSafetyMode.ExecutionAndPublication))
                {
                    return (this.valueFactory == null);
                }
                using (this.Sync.UseLock())
                {
                    return (this.valueFactory == null);
                }
            }
        }

        protected CriticalSection Sync =>
            this.sync;
    }
}

