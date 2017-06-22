namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Collections.Generic;

    internal class AsyncSource<T> : IAsync<T>, IAsync, IAsyncSource<T>
    {
        private List<Tuple<Action<Result<T>>, IAsyncSource>> handlers;
        private Result<T> result;
        private readonly object sync;

        public AsyncSource()
        {
            this.sync = new object();
        }

        public IAsync Receive(Action<Result> handler)
        {
            Action<Result<T>> action = delegate (Result<T> result) {
                handler(result);
            };
            return this.Receive(action);
        }

        public IAsync Receive(Action<Result<T>> handler)
        {
            IAsyncSource source = Async.NewSource();
            bool flag = false;
            object sync = this.sync;
            lock (sync)
            {
                if (this.result != null)
                {
                    flag = true;
                }
                else
                {
                    if (this.handlers == null)
                    {
                        this.handlers = new List<Tuple<Action<Result<T>>, IAsyncSource>>(1);
                    }
                    this.handlers.Add(Tuple.Create<Action<Result<T>>, IAsyncSource>(handler, source));
                }
            }
            if (flag)
            {
                Result result = handler.Try<Result<T>>(this.result);
                source.SetResult(result);
            }
            return source.AsReceiveOnly();
        }

        public bool SetResult(Result<T> result)
        {
            List<Tuple<Action<Result<T>>, IAsyncSource>> handlers;
            Validate.IsNotNull<Result<T>>(result, "result");
            if (this.result != null)
            {
                return false;
            }
            object sync = this.sync;
            lock (sync)
            {
                if (this.result != null)
                {
                    return false;
                }
                this.result = result;
                handlers = this.handlers;
                this.handlers = null;
            }
            if (handlers != null)
            {
                for (int i = 0; i < handlers.Count; i++)
                {
                    Action<Result<T>> f = handlers[i].Item1;
                    handlers[i].Item2.SetResult(f.Try<Result<T>>(this.result));
                }
            }
            return true;
        }
    }
}

