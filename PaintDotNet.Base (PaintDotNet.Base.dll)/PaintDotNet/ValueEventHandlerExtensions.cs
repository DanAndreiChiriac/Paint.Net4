namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ValueEventHandlerExtensions
    {
        public static void Raise<T>(this ValueEventHandler<T> handler, object sender, ValueEventArgs<T> e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void Raise<T>(this ValueEventHandler<T> handler, object sender, T value)
        {
            if (handler != null)
            {
                ValueEventArgs<T> e = ValueEventArgs<T>.Get(value);
                handler(sender, e);
                e.Return();
            }
        }
    }
}

