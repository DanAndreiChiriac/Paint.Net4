namespace PaintDotNet.Functional
{
    using System;
    using System.Threading;

    public static class LazyWeakResult
    {
        public static LazyWeakResult<T> Create<T, TArg>(Func<TArg, T> valueFactory, TArg arg) where T: class => 
            new LazyWeakResult<T, TArg>(valueFactory, arg);

        public static LazyWeakResult<T> Create<T, TArg>(Func<TArg, T> valueFactory, TArg arg, LazyThreadSafetyMode lazyThreadSafetyMode) where T: class => 
            new LazyWeakResult<T, TArg>(valueFactory, arg, lazyThreadSafetyMode);

        public static LazyWeakResult<T> CreateFromValue<T>(T value) where T: class => 
            LazyWeakResult<T>.Create(value);
    }
}

