namespace PaintDotNet.Markup
{
    internal class StringBasedTypeConverter<T> : StringBasedTypeConverter<T, T> where T: IFormattable, IParseString<T>, new()
    {
    }
}

