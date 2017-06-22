namespace PaintDotNet
{
    using System;

    public static class ValueEventArgs
    {
        public static ValueEventArgs<T> Get<T>(T value) => 
            ValueEventArgs<T>.Get(value);
    }
}

