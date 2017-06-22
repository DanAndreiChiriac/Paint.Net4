namespace PaintDotNet.Collections
{
    using PaintDotNet.Functional;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct CastFunc<TIn, TOut> : IFunc<TIn, TOut>
    {
        public TOut Invoke(TIn arg1) => 
            ((TOut) arg1);
    }
}

