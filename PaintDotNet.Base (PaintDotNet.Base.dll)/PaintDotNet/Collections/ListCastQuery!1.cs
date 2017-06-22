namespace PaintDotNet.Collections
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ListCastQuery<T>
    {
        private IList<T> items;
        public IList<TResult> ToSlow<TResult>() => 
            new ReadOnlyListSelector<T, TResult, CastFunc<T, TResult>>(this.items, new CastFunc<T, TResult>());

        public IList<TResult> To<TResult>() where TResult: struct, IConvertibleFrom<T> => 
            new ReadOnlyListSelector<T, TResult, ConvertibleFromFunc<T, TResult>>(this.items, new ConvertibleFromFunc<T, TResult>());

        public IList<TResult> With<TSelector, TResult>(TSelector selector) where TSelector: IFunc<T, TResult> => 
            new ReadOnlyListSelector<T, TResult, TSelector>(this.items, selector);

        public ListCastQuery(IList<T> items)
        {
            Validate.IsNotNull<IList<T>>(items, "items");
            this.items = items;
        }
    }
}

