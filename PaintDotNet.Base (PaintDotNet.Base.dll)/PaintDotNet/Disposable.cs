namespace PaintDotNet
{
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;

    [Serializable]
    public abstract class Disposable : IDisposable, IIsDisposed
    {
        private int isDisposed;
        private static readonly NoOpDisposable noOp = new NoOpDisposable();

        protected Disposable()
        {
        }

        public static IDisposable Combine(IEnumerable<IDisposable> list, bool errorOnFinalize = false)
        {
            Validate.IsNotNull<IEnumerable<IDisposable>>(list, "list");
            IDisposable[] listArray = list.ToArrayEx<IDisposable>();
            return FromAction(delegate {
                foreach (IDisposable disposable in listArray)
                {
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                listArray = null;
            }, errorOnFinalize);
        }

        public static IDisposable Combine(IDisposable first, IDisposable second, bool errorOnFinalize = false)
        {
            if ((first == null) && (second == null))
            {
                ExceptionUtil.ThrowArgumentNullException((first == null) ? "first" : "second", "either first or second may be null, but not both");
            }
            if ((first != null) && (second != null))
            {
                return FromAction(delegate {
                    DisposableUtil.Free<IDisposable>(ref first);
                    DisposableUtil.Free<IDisposable>(ref second);
                }, errorOnFinalize);
            }
            IDisposable disposable = first ?? second;
            return FromAction(delegate {
                DisposableUtil.Free<IDisposable>(ref disposable);
            }, errorOnFinalize);
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref this.isDisposed, 1) == 0)
            {
                try
                {
                    this.Dispose(true);
                }
                finally
                {
                    GC.SuppressFinalize(this);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        ~Disposable()
        {
            this.Dispose(false);
        }

        public static IDisposable FromAction(Action action, bool errorOnFinalize = false)
        {
            Validate.IsNotNull<Action>(action, "action");
            if (!errorOnFinalize)
            {
                return new ActionDisposable(action);
            }
            return new ActionDisposableErrorOnFinalize(action);
        }

        public static IDisposable FromCallback(DisposeCallback callback)
        {
            Validate.IsNotNull<DisposeCallback>(callback, "callback");
            return new CallbackDisposable(callback);
        }

        public static void StructuredUsing<T>(T autoObject, Action<T> action) where T: IDisposable
        {
            Exception exception = null;
            try
            {
                action(autoObject);
            }
            catch (Exception exception1)
            {
                exception = exception1;
                throw;
            }
            finally
            {
                try
                {
                    autoObject.Dispose();
                }
                catch (Exception exception2)
                {
                    if (exception == null)
                    {
                        throw;
                    }
                    Exception[] innerExceptions = new Exception[] { exception, exception2 };
                    throw new AggregateException("The body of the using() block threw an exception, and so did the call to Dispose() on the auto-object", innerExceptions);
                }
            }
        }

        public static TResult StructuredUsing<T, TResult>(T autoObject, Func<T, TResult> action) where T: IDisposable
        {
            Exception exception = null;
            TResult local;
            try
            {
                local = action(autoObject);
            }
            catch (Exception exception1)
            {
                exception = exception1;
                throw;
            }
            finally
            {
                try
                {
                    autoObject.Dispose();
                }
                catch (Exception exception2)
                {
                    if (exception == null)
                    {
                        throw;
                    }
                    Exception[] innerExceptions = new Exception[] { exception, exception2 };
                    throw new AggregateException("The body of the using() block threw an exception, and so did the call to Dispose() on the auto-object", innerExceptions);
                }
            }
            return local;
        }

        public bool IsDisposed =>
            (Thread.VolatileRead(ref this.isDisposed) == 1);

        public static IDisposable NoOp =>
            noOp;

        private class ActionDisposable : Disposable
        {
            private Action action;

            public ActionDisposable(Action action)
            {
                this.action = action;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    Interlocked.Exchange<Action>(ref this.action, null)();
                }
                base.Dispose(disposing);
            }
        }

        private sealed class ActionDisposableErrorOnFinalize : Disposable.ActionDisposable
        {
            public ActionDisposableErrorOnFinalize(Action action) : base(action)
            {
            }

            ~ActionDisposableErrorOnFinalize()
            {
                throw new InvalidOperationException("An Action wrapped in an IDisposable was finalized");
            }
        }

        private sealed class CallbackDisposable : Disposable
        {
            private DisposeCallback callback;
            private GCHandle callbackHandle;

            public CallbackDisposable(DisposeCallback callback)
            {
                Validate.IsNotNull<DisposeCallback>(callback, "callback");
                this.callbackHandle = GCHandle.Alloc(callback, GCHandleType.Normal);
                this.callback = callback;
            }

            protected override void Dispose(bool disposing)
            {
                try
                {
                    this.callback(disposing);
                }
                finally
                {
                    this.callbackHandle.Free();
                    this.callback = null;
                }
                base.Dispose(disposing);
            }
        }

        private sealed class NoOpDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}

