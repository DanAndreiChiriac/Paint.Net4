namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate void ValueChangedEventHandler<T>(object sender, ValueChangedEventArgs<T> e);
}

