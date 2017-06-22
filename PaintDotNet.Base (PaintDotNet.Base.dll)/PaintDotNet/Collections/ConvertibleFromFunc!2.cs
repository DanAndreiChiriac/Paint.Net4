namespace PaintDotNet.Collections
{
    using PaintDotNet.Functional;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct ConvertibleFromFunc<T, TResult> : IFunc<T, TResult> where TResult: struct, IConvertibleFrom<T>
    {
        public TResult Invoke(T arg1)
        {
            TResult local = default(TResult);
            local.ConvertFrom(arg1);
            return local;
        }
    }
}

