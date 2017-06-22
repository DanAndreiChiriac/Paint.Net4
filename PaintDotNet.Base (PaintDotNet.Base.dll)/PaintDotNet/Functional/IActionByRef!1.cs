namespace PaintDotNet.Functional
{
    using System;

    public interface IActionByRef<TArg1>
    {
        void Invoke(ref TArg1 arg1);
    }
}

