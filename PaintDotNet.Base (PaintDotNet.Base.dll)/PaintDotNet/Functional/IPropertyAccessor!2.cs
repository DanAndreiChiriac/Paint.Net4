namespace PaintDotNet.Functional
{
    using System;

    internal interface IPropertyAccessor<TTarget, TValue>
    {
        TValue Get(TTarget target);
        void Set(TTarget target, TValue newValue);
    }
}

