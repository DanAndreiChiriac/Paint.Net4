namespace PaintDotNet.Animation
{
    using System;

    [Flags]
    public enum AnimationDependencies
    {
        Duration = 8,
        FinalValues = 2,
        FinalVelocity = 4,
        IntermediateValues = 1,
        None = 0
    }
}

