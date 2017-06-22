namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public static class LazyExtensions
    {
        public static void Prefetch<T>(this Lazy<T> lazy)
        {
            if (!lazy.IsValueCreated)
            {
                ThreadPool.QueueUserWorkItem(PrefetchHelper<T>.prefetchCallback, lazy);
            }
        }

        public static void Prefetch<T>(this Lazy<T> lazy, Action<T> onCreated)
        {
            if (lazy.IsValueCreated)
            {
                onCreated(lazy.Value);
            }
            else
            {
                Tuple<Lazy<T>, Action<T>> state = new Tuple<Lazy<T>, Action<T>>(lazy, onCreated);
                ThreadPool.QueueUserWorkItem(PrefetchHelper<T>.prefetchWithContinuationCallback, state);
            }
        }

        private static class PrefetchHelper<T>
        {
            public static readonly WaitCallback prefetchCallback;
            public static readonly WaitCallback prefetchWithContinuationCallback;

            static PrefetchHelper()
            {
                LazyExtensions.PrefetchHelper<T>.prefetchCallback = new WaitCallback(LazyExtensions.PrefetchHelper<T>.PrefetchCallback);
                LazyExtensions.PrefetchHelper<T>.prefetchWithContinuationCallback = new WaitCallback(LazyExtensions.PrefetchHelper<T>.PrefetchWithContinuationCallback);
            }

            private static void PrefetchCallback(object lazyObj)
            {
                T local1 = ((Lazy<T>) lazyObj).Value;
            }

            private static void PrefetchWithContinuationCallback(object lazyAndContinuationObj)
            {
                Tuple<Lazy<T>, Action<T>> tuple1 = (Tuple<Lazy<T>, Action<T>>) lazyAndContinuationObj;
                T local = tuple1.Item1.Value;
                tuple1.Item2(local);
            }
        }
    }
}

