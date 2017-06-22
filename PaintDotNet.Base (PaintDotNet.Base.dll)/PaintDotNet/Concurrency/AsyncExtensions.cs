namespace PaintDotNet.Concurrency
{
    using PaintDotNet.Functional;
    using System;
    using System.Runtime.CompilerServices;

    public static class AsyncExtensions
    {
        public static void Observe(this IAsync async)
        {
            async.Receive(delegate (Result result) {
                if (result.IsError)
                {
                    result.Observe();
                }
            });
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly AsyncExtensions.<>c <>9 = new AsyncExtensions.<>c();
            public static Action<Result> <>9__0_0;

            internal void <Observe>b__0_0(Result result)
            {
                if (result.IsError)
                {
                    result.Observe();
                }
            }
        }
    }
}

