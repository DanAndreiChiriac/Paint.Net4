namespace PaintDotNet
{
    public interface IValue<out T>
    {
        T Value { get; }
    }
}

