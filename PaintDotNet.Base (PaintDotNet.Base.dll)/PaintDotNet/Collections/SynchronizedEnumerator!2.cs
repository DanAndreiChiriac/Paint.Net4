namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;

    public sealed class SynchronizedEnumerator<T, TEnumerator> : SynchronizedEnumerator<T> where TEnumerator: IEnumerator<T>
    {
        private TEnumerator enumerator;
        private static readonly bool isEnumeratorStruct;

        static SynchronizedEnumerator()
        {
            SynchronizedEnumerator<T, TEnumerator>.isEnumeratorStruct = typeof(TEnumerator).IsValueType;
        }

        internal SynchronizedEnumerator(object sync, TEnumerator enumerator) : base(sync)
        {
            if (!SynchronizedEnumerator<T, TEnumerator>.isEnumeratorStruct && (enumerator == null))
            {
                ExceptionUtil.ThrowArgumentNullException("enumerator");
            }
            this.enumerator = enumerator;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !base.IsDisposed)
            {
                this.enumerator.Dispose();
                this.enumerator = default(TEnumerator);
            }
            base.Dispose(disposing);
        }

        public override bool MoveNext()
        {
            object sync = base.Sync;
            lock (sync)
            {
                return this.enumerator.MoveNext();
            }
        }

        public override void Reset()
        {
            object sync = base.Sync;
            lock (sync)
            {
                this.enumerator.Reset();
            }
        }

        public override T Current
        {
            get
            {
                object sync = base.Sync;
                lock (sync)
                {
                    return this.enumerator.Current;
                }
            }
        }
    }
}

