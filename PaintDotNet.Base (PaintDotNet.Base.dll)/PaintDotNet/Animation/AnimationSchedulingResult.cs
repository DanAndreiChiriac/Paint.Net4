namespace PaintDotNet.Animation
{
    using System;

    public enum AnimationSchedulingResult
    {
        UnexpectedFailure,
        InsufficientPriority,
        AlreadyScheduled,
        Succeeded,
        Deferred
    }
}

