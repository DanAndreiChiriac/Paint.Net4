namespace PaintDotNet.Direct2D
{
    using System;

    [Flags]
    public enum RenderTargetUsage
    {
        None,
        ForceBitmapRemoting,
        GdiCompatible
    }
}

