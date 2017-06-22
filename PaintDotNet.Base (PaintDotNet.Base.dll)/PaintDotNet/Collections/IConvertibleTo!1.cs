namespace PaintDotNet.Collections
{
    public interface IConvertibleTo<TResult>
    {
        TResult Convert();
    }
}

