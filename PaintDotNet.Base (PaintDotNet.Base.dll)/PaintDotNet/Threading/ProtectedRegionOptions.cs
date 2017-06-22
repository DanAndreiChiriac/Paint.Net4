namespace PaintDotNet.Threading
{
    using System;

    [Flags]
    public enum ProtectedRegionOptions
    {
        DisablePumpingWhenEntered = 1,
        ErrorOnMultithreadedAccess = 4,
        ErrorOnPerThreadReentrancy = 2,
        None = 0
    }
}

