namespace PaintDotNet.Animation
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate void AnimationVariableValueChangedEventHandler<T>(object sender, AnimationVariableValueChangedEventArgs<T> e);
}

