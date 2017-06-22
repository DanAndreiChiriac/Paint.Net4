namespace PaintDotNet.MemoryManagement
{
    using System;

    [Flags]
    public enum BufferAccess
    {
        None,
        Read,
        Write,
        ReadWrite
    }
}

