namespace PaintDotNet.Functional
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FuncDelegateAdapter<TResult> : IFunc<TResult>
    {
        private Func<TResult> func;
        public TResult Invoke() => 
            this.func();

        public FuncDelegateAdapter(Func<TResult> func)
        {
            Validate.IsNotNull<Func<TResult>>(func, "func");
            this.func = func;
        }
    }
}

