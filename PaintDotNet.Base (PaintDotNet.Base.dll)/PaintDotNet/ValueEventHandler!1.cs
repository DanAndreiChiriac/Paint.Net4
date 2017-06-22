namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate void ValueEventHandler<T>(object sender, ValueEventArgs<T> e);
}

