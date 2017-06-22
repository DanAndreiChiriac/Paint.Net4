namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public abstract class SynchronizedEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator, IIsDisposed
    {
        private object sync;

        protected SynchronizedEnumerator(object sync)
        {
            Validate.IsNotNull<object>(sync, "sync");
            this.sync = sync;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.sync = null;
        }

        public abstract bool MoveNext();
        public abstract void Reset();

        public abstract T Current { get; }

        public bool IsDisposed =>
            (this.sync == null);

        public object Sync =>
            this.sync;

        object IEnumerator.Current =>
            this.Current;
    }
}

