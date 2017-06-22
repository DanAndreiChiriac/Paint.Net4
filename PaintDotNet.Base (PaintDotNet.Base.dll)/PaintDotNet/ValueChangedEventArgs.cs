namespace PaintDotNet
{
    using System;

    public static class ValueChangedEventArgs
    {
        public static ValueChangedEventArgs<T> Get<T>(T oldValue, T newValue) => 
            ValueChangedEventArgs<T>.Get(oldValue, newValue);
    }
}

