namespace PaintDotNet.Collections
{
    using System;

    public interface IConvertibleFrom<T>
    {
        void ConvertFrom(T value);
    }
}

