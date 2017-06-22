namespace PaintDotNet.Diagnostics
{
    using System;

    public interface IValidator<T, TCriteria>
    {
        bool Check(TCriteria criteria, T value);
        Exception CreateException(TCriteria criteria, T value, string valueName, Exception innerException);
    }
}

