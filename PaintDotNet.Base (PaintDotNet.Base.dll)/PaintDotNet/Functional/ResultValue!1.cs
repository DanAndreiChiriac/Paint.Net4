namespace PaintDotNet.Functional
{
    using System;

    [Serializable]
    public abstract class ResultValue<T> : Result<T>
    {
        internal ResultValue()
        {
        }
    }
}

