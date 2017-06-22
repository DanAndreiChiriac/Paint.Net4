namespace PaintDotNet.Diagnostics
{
    using System;

    public interface IValidatorByRef<T, TCriteria>
    {
        bool Check(ref TCriteria criteria, ref T value);
        Exception CreateException(ref TCriteria criteria, ref T value, string valueName, Exception innerException);
    }
}

