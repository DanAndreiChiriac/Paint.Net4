namespace PaintDotNet
{
    public sealed class ValueEventArgs<T> : PooledEventArgs<ValueEventArgs<T>, T>
    {
        public static ValueEventArgs<T> Get(T value) => 
            PooledEventArgs<ValueEventArgs<T>, T>.Get(value);

        public T Value =>
            base.Value1;
    }
}

