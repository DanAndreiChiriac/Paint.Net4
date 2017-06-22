namespace PaintDotNet.Dxgi
{
    using System;

    [Flags]
    public enum UsageOptions
    {
        BackBuffer = 0x40,
        DiscardOnPresent = 0x200,
        ReadOnly = 0x100,
        RenderTargetOutput = 0x20,
        ShaderInput = 0x10,
        Shared = 0x80,
        UnorderedAccess = 0x400
    }
}

