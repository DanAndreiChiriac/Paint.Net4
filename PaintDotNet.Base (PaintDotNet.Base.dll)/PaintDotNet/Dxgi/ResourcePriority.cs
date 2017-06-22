namespace PaintDotNet.Dxgi
{
    using System;

    public enum ResourcePriority : uint
    {
        High = 0xa0000000,
        Low = 0x50000000,
        Maximum = 0xc8000000,
        Minimum = 0x28000000,
        Normal = 0x78000000
    }
}

