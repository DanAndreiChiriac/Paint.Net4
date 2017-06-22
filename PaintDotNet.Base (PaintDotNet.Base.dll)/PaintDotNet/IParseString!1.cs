namespace PaintDotNet
{
    using System;

    public interface IParseString<T>
    {
        T Parse(string source, IFormatProvider formatProvider);
    }
}

