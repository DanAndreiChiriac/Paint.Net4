namespace PaintDotNet.Functional
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FuncDelegateAdapter<TArg1, TArg2, TArg3, TArg4, TResult> : IFunc<TArg1, TArg2, TArg3, TArg4, TResult>
    {
        private Func<TArg1, TArg2, TArg3, TArg4, TResult> func;
        public TResult Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) => 
            this.func(arg1, arg2, arg3, arg4);

        public FuncDelegateAdapter(Func<TArg1, TArg2, TArg3, TArg4, TResult> func)
        {
            Validate.IsNotNull<Func<TArg1, TArg2, TArg3, TArg4, TResult>>(func, "func");
            this.func = func;
        }
    }
}

