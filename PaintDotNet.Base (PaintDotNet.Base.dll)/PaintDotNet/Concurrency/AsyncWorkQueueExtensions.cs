namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Functional;
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public static class AsyncWorkQueueExtensions
    {
        public static IAsync<T> BeginEval<T>(this IAsyncWorkQueue queue, Func<T> f)
        {
            IAsyncSource<T> source = Async.NewSource<T>();
            queue.BeginTry(delegate {
                try
                {
                    Result<T> result = f.Eval<T>();
                    source.SetResult(result);
                }
                catch (Exception exception)
                {
                    source.Throw<T>(new TargetInvocationException(exception));
                }
            });
            return source.AsReceiveOnly<T>();
        }

        public static IAsync<TRet> BeginEval<T1, TRet>(this IAsyncWorkQueue queue, Func<T1, TRet> f, T1 arg1) => 
            queue.BeginEval<TRet>(() => f(arg1));

        public static IAsync BeginTry<T1>(this IAsyncWorkQueue queue, Action<T1> f, T1 arg1) => 
            queue.BeginTry(delegate {
                f(arg1);
            });
    }
}

