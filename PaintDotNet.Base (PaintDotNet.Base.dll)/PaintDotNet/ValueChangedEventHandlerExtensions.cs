namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public static class ValueChangedEventHandlerExtensions
    {
        public static void Raise<T>(this ValueChangedEventHandler<T> handler, object sender, ValueChangedEventArgs<T> e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void Raise<T>(this ValueChangedEventHandler<T> handler, object sender, DependencyPropertyChangedEventArgs e)
        {
            handler.Raise<T>(sender, (T) e.OldValue, (T) e.NewValue);
        }

        public static void Raise<T>(this ValueChangedEventHandler<T> handler, object sender, T oldValue, T newValue)
        {
            if (handler != null)
            {
                ValueChangedEventArgs<T> e = ValueChangedEventArgs.Get<T>(oldValue, newValue);
                handler(sender, e);
                e.Return();
            }
        }
    }
}

