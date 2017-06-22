namespace PaintDotNet.Functional
{
    using PaintDotNet.Threading;
    using System;
    using System.Threading;

    public static class LazyResult
    {
        public static LazyResult<T> New<T>(Func<T> valueFactory, LazyThreadSafetyMode lazyThreadSafetyMode) => 
            new LazyResult<T, int>(x => valueFactory(), 0, lazyThreadSafetyMode);

        public static LazyResult<T> New<T>(Func<T> valueFactory, LazyThreadSafetyMode lazyThreadSafetyMode, CriticalSection sync) => 
            new LazyResult<T, int>(x => valueFactory(), 0, lazyThreadSafetyMode, sync);
    }
}

