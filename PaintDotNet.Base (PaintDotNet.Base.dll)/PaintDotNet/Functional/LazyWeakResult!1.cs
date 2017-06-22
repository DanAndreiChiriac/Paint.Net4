namespace PaintDotNet.Functional
{
    using PaintDotNet;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public class LazyWeakResult<T> : Result<WeakReferenceT<T>> where T: class
    {
        protected WeakReferenceT<T> weakValue;

        internal LazyWeakResult()
        {
        }

        private LazyWeakResult(T value)
        {
            this.weakValue = new WeakReferenceT<T>(value);
        }

        internal static LazyWeakResult<T> Create(T value) => 
            new LazyWeakResult<T>(value);

        public virtual bool EnsureEvaluated(out T value)
        {
            value = this.weakValue.Target;
            return false;
        }

        public override void Observe()
        {
        }

        [Conditional("DEBUG")]
        private void VerifyIsNotDerivedClass()
        {
            if (base.GetType() != typeof(LazyWeakResult<T>))
            {
                ExceptionUtil.ThrowInternalErrorException();
            }
        }

        public override bool IsEvaluated =>
            true;

        public override WeakReferenceT<T> Value =>
            this.weakValue;

        internal virtual bool ValueFactoryReturnedNull =>
            false;
    }
}

