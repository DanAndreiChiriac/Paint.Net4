namespace PaintDotNet.Animation
{
    using System;

    public enum AnimationStoryboardStatus
    {
        Building,
        Scheduled,
        Cancelled,
        Playing,
        Truncated,
        Finished,
        Ready,
        InsufficientPriority
    }
}

