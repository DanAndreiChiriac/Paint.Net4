namespace PaintDotNet.Functional
{
    using System;

    public interface IAction<in TArg1>
    {
        void Invoke(TArg1 arg1);
    }
}

