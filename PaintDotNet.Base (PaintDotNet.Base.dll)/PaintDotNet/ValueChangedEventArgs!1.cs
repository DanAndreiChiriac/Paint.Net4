namespace PaintDotNet
{
    public sealed class ValueChangedEventArgs<T> : PooledEventArgs<ValueChangedEventArgs<T>, T, T>
    {
        internal static ValueChangedEventArgs<T> Get(T oldValue, T newValue) => 
            PooledEventArgs<ValueChangedEventArgs<T>, T, T>.Get(oldValue, newValue);

        public T NewValue =>
            base.Value2;

        public T OldValue =>
            base.Value1;
    }
}

