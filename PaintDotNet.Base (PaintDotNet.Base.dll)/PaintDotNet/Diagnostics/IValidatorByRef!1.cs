namespace PaintDotNet.Diagnostics
{
    using System;

    public interface IValidatorByRef<T>
    {
        bool Check(ref T value);
        Exception CreateException(ref T value, string valueName, Exception innerException);
    }
}

