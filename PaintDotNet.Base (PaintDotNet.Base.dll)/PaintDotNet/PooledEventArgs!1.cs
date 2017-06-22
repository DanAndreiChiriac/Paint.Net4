namespace PaintDotNet
{
    using System;
    using System.Collections.Concurrent;

    public abstract class PooledEventArgs<TDerivedArgs> : EventArgs, ICloneable where TDerivedArgs: PooledEventArgs<TDerivedArgs>, new()
    {
        private bool isValid;
        private static readonly ConcurrentBag<TDerivedArgs> pool;

        static PooledEventArgs()
        {
            PooledEventArgs<TDerivedArgs>.pool = new ConcurrentBag<TDerivedArgs>();
        }

        protected PooledEventArgs()
        {
        }

        protected abstract void ClearValues();
        public abstract TDerivedArgs Clone();
        internal static TDerivedArgs Get()
        {
            TDerivedArgs local;
            if (!PooledEventArgs<TDerivedArgs>.pool.TryTake(out local))
            {
                local = Activator.CreateInstance<TDerivedArgs>();
            }
            return local;
        }

        public void Return()
        {
            this.VerifyIsValid();
            this.isValid = false;
            this.ClearValues();
            PooledEventArgs<TDerivedArgs>.pool.Add((TDerivedArgs) this);
        }

        object ICloneable.Clone() => 
            this.Clone();

        protected void Validate()
        {
            this.VerifyIsNotValid();
            this.isValid = true;
        }

        protected void VerifyIsNotValid()
        {
            if (this.IsValid)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
        }

        protected void VerifyIsValid()
        {
            if (!this.isValid)
            {
                ExceptionUtil.ThrowInvalidOperationException("This instance has been invalidated. If you are handling the event asynchronously, or storing the EventArgs for use outside the event handler method, you should first call Clone() to get a copy of this instance.");
            }
        }

        public bool IsValid =>
            this.isValid;
    }
}

