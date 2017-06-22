namespace PaintDotNet.Collections
{
    using System;
    using System.Collections.Generic;

    public class ReadOnlyListSelector<TIn, TOut> : ReadOnlyListSelector<TIn, TOut, FuncDelegateAdapter<TIn, TOut>>
    {
        public ReadOnlyListSelector(IList<TIn> source, Func<TIn, TOut> selector) : base(source, new FuncDelegateAdapter<TIn, TOut>(selector))
        {
        }
    }
}

