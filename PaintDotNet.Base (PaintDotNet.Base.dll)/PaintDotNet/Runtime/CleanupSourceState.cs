namespace PaintDotNet.Runtime
{
    using System;

    [Flags]
    public enum CleanupSourceState
    {
        Idle,
        CleanupNeeded,
        Cleaning
    }
}

