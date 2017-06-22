namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using System;
    using System.Collections.Generic;

    internal class AsyncSource : IAsync, IAsyncSource
    {
        private List<Tuple<Action<Result>, IAsyncSource>> handlers;
        private Result result;
        private readonly object sync = new object();

        public IAsync Receive(Action<Result> handler)
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
                        this.handlers = new List<Tuple<Action<Result>, IAsyncSource>>(1);
                    }
                    this.handlers.Add(Tuple.Create<Action<Result>, IAsyncSource>(handler, source));
                }
            }
            if (flag)
            {
                Result result = handler.Try<Result>(this.result);
                source.SetResult(result);
            }
            return source.AsReceiveOnly();
        }

        public bool SetResult(Result result)
        {
            List<Tuple<Action<Result>, IAsyncSource>> handlers;
            Validate.IsNotNull<Result>(result, "result");
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
                    Action<Result> f = handlers[i].Item1;
                    handlers[i].Item2.SetResult(f.Try<Result>(this.result));
                }
            }
            return true;
        }
    }
}

