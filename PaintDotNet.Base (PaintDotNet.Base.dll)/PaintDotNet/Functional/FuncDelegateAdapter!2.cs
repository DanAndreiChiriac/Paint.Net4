namespace PaintDotNet.Functional
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FuncDelegateAdapter<TArg1, TResult> : IFunc<TArg1, TResult>
    {
        private Func<TArg1, TResult> func;
        public TResult Invoke(TArg1 arg1) => 
            this.func(arg1);

        public FuncDelegateAdapter(Func<TArg1, TResult> func)
        {
            Validate.IsNotNull<Func<TArg1, TResult>>(func, "func");
            this.func = func;
        }
    }
}

