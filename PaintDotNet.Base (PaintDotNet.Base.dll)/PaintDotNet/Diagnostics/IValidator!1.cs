namespace PaintDotNet.Diagnostics
{
    using System;

    public interface IValidator<T>
    {
        bool Check(T value);
        Exception CreateException(T value, string valueName, Exception innerException);
    }
}

