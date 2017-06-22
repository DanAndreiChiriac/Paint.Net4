namespace PaintDotNet.Functional
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Threading;
    using System;
    using System.Threading;

    public class LazyResult<T, TArg> : LazyResult<T>
    {
        private TArg arg;
        private ResultErrorData errorData;
        private T value;

        public LazyResult(Func<TArg, T> valueFactory, TArg arg) : this(valueFactory, arg, LazyThreadSafetyMode.ExecutionAndPublication)
        {
        }

        public LazyResult(Func<TArg, T> valueFactory, TArg arg, CriticalSection sync) : this(valueFactory, arg, LazyThreadSafetyMode.ExecutionAndPublication, sync)
        {
        }

        public LazyResult(Func<TArg, T> valueFactory, TArg arg, LazyThreadSafetyMode lazyThreadSafetyMode) : this(valueFactory, arg, lazyThreadSafetyMode, new MonitorCriticalSection())
        {
        }

        public LazyResult(Func<TArg, T> valueFactory, TArg arg, LazyThreadSafetyMode lazyThreadSafetyMode, CriticalSection sync) : base(sync)
        {
            Validate.IsNotNull<Func<TArg, T>>(valueFactory, "valueFactory");
            if (lazyThreadSafetyMode == LazyThreadSafetyMode.PublicationOnly)
            {
                throw new ArgumentException("LazyThreadSafetyMode.PublicationOnly is not supported", "lazyThreadSafetyMode");
            }
            if ((lazyThreadSafetyMode != LazyThreadSafetyMode.None) && (lazyThreadSafetyMode != LazyThreadSafetyMode.ExecutionAndPublication))
            {
                ExceptionUtil.ThrowInvalidEnumArgumentException<LazyThreadSafetyMode>(lazyThreadSafetyMode, "lazyThreadSafetyMode");
            }
            base.valueFactory = valueFactory;
            this.arg = arg;
            base.lazyThreadSafetyMode = lazyThreadSafetyMode;
            this.value = default(T);
            this.errorData = null;
        }

        public override ResultError<TRet> CastError<TRet>()
        {
            this.EnsureEvaluated();
            if (this.IsError)
            {
                return new ResultError<TRet>(this.errorData);
            }
            return base.CastError<TRet>();
        }

        public override bool EnsureEvaluated()
        {
            LazyThreadSafetyMode lazyThreadSafetyMode = base.lazyThreadSafetyMode;
            if ((lazyThreadSafetyMode != LazyThreadSafetyMode.None) && (lazyThreadSafetyMode == LazyThreadSafetyMode.ExecutionAndPublication))
            {
                return this.ThreadSafeEvaluate();
            }
            return this.UnsafeEvaluate();
        }

        public override void Observe()
        {
            this.EnsureEvaluated();
            if (this.errorData != null)
            {
                this.errorData.Observe();
            }
        }

        public override Exception PeekError()
        {
            this.EnsureEvaluated();
            if (this.errorData != null)
            {
                return this.errorData.Error;
            }
            return base.PeekError();
        }

        private bool ThreadSafeEvaluate()
        {
            if (base.valueFactory != null)
            {
                using (base.Sync.UseLock())
                {
                    if (base.valueFactory != null)
                    {
                        try
                        {
                            this.value = ((Func<TArg, T>) base.valueFactory)(this.arg);
                        }
                        catch (Exception exception)
                        {
                            this.value = default(T);
                            this.errorData = new ResultErrorData(exception, true);
                        }
                        this.arg = default(TArg);
                        base.valueFactory = null;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool UnsafeEvaluate()
        {
            if (base.valueFactory == null)
            {
                return false;
            }
            try
            {
                this.value = ((Func<TArg, T>) base.valueFactory)(this.arg);
            }
            catch (Exception exception)
            {
                this.value = default(T);
                this.errorData = new ResultErrorData(exception, true);
            }
            this.arg = default(TArg);
            base.valueFactory = null;
            return true;
        }

        public override Exception Error
        {
            get
            {
                this.EnsureEvaluated();
                if (this.errorData != null)
                {
                    this.errorData.Observe();
                    return this.errorData.Error;
                }
                return base.Error;
            }
        }

        public override bool IsError
        {
            get
            {
                this.EnsureEvaluated();
                return (this.errorData > null);
            }
        }

        public override bool NeedsObservation
        {
            get
            {
                this.EnsureEvaluated();
                return ((this.errorData != null) && this.errorData.NeedsObservation);
            }
        }

        public override T Value
        {
            get
            {
                this.EnsureEvaluated();
                if (this.errorData == null)
                {
                    return this.value;
                }
                this.Observe();
                ExceptionUtil.ThrowInvalidOperationException("This result is an error, not a value", this.errorData.Error);
                return default(T);
            }
        }
    }
}

