namespace PaintDotNet.Markup
{
    internal class StringBasedValueSerializer<T> : StringBasedValueSerializer<T, T> where T: IFormattable, IParseString<T>, new()
    {
    }
}

