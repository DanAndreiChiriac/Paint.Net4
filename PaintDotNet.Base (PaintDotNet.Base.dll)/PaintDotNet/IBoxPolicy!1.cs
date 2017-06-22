namespace PaintDotNet
{
    using System;

    public interface IBoxPolicy<TValue>
    {
        object BoxValue(TValue value);
    }
}

