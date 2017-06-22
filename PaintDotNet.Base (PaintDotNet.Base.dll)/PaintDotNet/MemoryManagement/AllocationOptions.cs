namespace PaintDotNet.MemoryManagement
{
    using System;

    [Flags]
    public enum AllocationOptions
    {
        Default,
        ZeroFillNotRequired
    }
}

