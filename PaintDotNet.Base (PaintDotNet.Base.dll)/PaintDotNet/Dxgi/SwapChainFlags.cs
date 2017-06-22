namespace PaintDotNet.Dxgi
{
    using System;

    [Flags]
    public enum SwapChainFlags
    {
        AllowModeSwitch = 2,
        GdiCompatible = 4,
        NonPreRotated = 1
    }
}

