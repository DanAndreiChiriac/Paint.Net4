namespace PaintDotNet.Functional
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;

    public sealed class LazyWeakResult<T, TArg> : LazyWeakResult<T> where T: class
    {
        private TArg arg;
        private ResultErrorData errorData;
        private LazyThreadSafetyMode lazyThreadSafetyMode;
        private Func<TArg, T> valueFactory;
        private bool valueFactoryReturnedNull;

        public LazyWeakResult(Func<TArg, T> valueFactory, TArg arg) : this(valueFactory, arg, LazyThreadSafetyMode.ExecutionAndPublication)
        {
        }

        public LazyWeakResult(Func<TArg, T> valueFactory, TArg arg, LazyThreadSafetyMode lazyThreadSafetyMode)
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
            this.valueFactory = valueFactory;
            this.arg = arg;
            this.lazyThreadSafetyMode = lazyThreadSafetyMode;
            base.weakValue = null;
            this.errorData = null;
        }

        public override ResultError<TRet> CastError<TRet>()
        {
            T local;
            this.EnsureEvaluated(false, out local);
            if (this.IsError)
            {
                return new ResultError<TRet>(this.errorData);
            }
            return base.CastError<TRet>();
        }

        public override bool EnsureEvaluated(out T value) => 
            this.EnsureEvaluated(true, out value);

        private bool EnsureEvaluated(bool throwOnError, out T value)
        {
            LazyThreadSafetyMode lazyThreadSafetyMode = this.lazyThreadSafetyMode;
            if ((lazyThreadSafetyMode != LazyThreadSafetyMode.None) && (lazyThreadSafetyMode == LazyThreadSafetyMode.ExecutionAndPublication))
            {
                return this.ThreadSafeEvaluate(throwOnError, out value);
            }
            return this.UnsafeEvaluate(throwOnError, out value);
        }

        public override void Observe()
        {
            T local;
            this.EnsureEvaluated(false, out local);
            if (this.errorData != null)
            {
                this.errorData.Observe();
            }
        }

        public override Exception PeekError()
        {
            T local;
            this.EnsureEvaluated(false, out local);
            if (this.errorData != null)
            {
                return this.errorData.Error;
            }
            return base.PeekError();
        }

        private bool ThreadSafeEvaluate(bool throwOnError, out T value)
        {
            if (this.valueFactory != null)
            {
                lock (result)
                {
                    if (this.valueFactory != null)
                    {
                        try
                        {
                            value = this.valueFactory(this.arg);
                            this.valueFactoryReturnedNull = ((T) value) == null;
                            base.weakValue = new WeakReferenceT<T>(value);
                        }
                        catch (Exception exception)
                        {
                            value = default(T);
                            base.weakValue = null;
                            this.errorData = new ResultErrorData(exception, !throwOnError);
                        }
                        finally
                        {
                            this.arg = default(TArg);
                            this.valueFactory = null;
                        }
                        return true;
                    }
                }
            }
            value = default(T);
            return false;
        }

        private bool UnsafeEvaluate(bool throwOnError, out T value)
        {
            if (this.valueFactory != null)
            {
                try
                {
                    value = this.valueFactory(this.arg);
                    this.valueFactoryReturnedNull = value.IsNullReference<T>();
                    base.weakValue = new WeakReferenceT<T>(value);
                }
                catch (Exception exception)
                {
                    value = default(T);
                    base.weakValue = null;
                    this.errorData = new ResultErrorData(exception, !throwOnError);
                    if (throwOnError)
                    {
                        throw;
                    }
                }
                finally
                {
                    this.arg = default(TArg);
                    this.valueFactory = null;
                }
                return true;
            }
            value = default(T);
            return false;
        }

        public override Exception Error
        {
            get
            {
                T local;
                this.EnsureEvaluated(false, out local);
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
                T local;
                this.EnsureEvaluated(false, out local);
                return (this.errorData > null);
            }
        }

        public override bool IsEvaluated
        {
            get
            {
                LazyThreadSafetyMode lazyThreadSafetyMode = this.lazyThreadSafetyMode;
                if ((lazyThreadSafetyMode != LazyThreadSafetyMode.None) && (lazyThreadSafetyMode == LazyThreadSafetyMode.ExecutionAndPublication))
                {
                    lock (result)
                    {
                        return this.valueFactory.IsNullReference<Func<TArg, T>>();
                    }
                }
                return this.valueFactory.IsNullReference<Func<TArg, T>>();
            }
        }

        public override bool NeedsObservation
        {
            get
            {
                T local;
                this.EnsureEvaluated(false, out local);
                return ((this.errorData != null) && this.errorData.NeedsObservation);
            }
        }

        public override WeakReferenceT<T> Value
        {
            get
            {
                T local;
                this.EnsureEvaluated(false, out local);
                if (this.errorData == null)
                {
                    return base.weakValue;
                }
                this.Observe();
                ExceptionUtil.ThrowInvalidOperationException("This result is an error, not a value", this.errorData.Error);
                return null;
            }
        }

        internal override bool ValueFactoryReturnedNull
        {
            get
            {
                T local;
                this.EnsureEvaluated(false, out local);
                return this.valueFactoryReturnedNull;
            }
        }
    }
}

