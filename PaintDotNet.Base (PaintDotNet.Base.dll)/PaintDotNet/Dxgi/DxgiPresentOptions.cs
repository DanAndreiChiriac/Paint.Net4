namespace PaintDotNet.Dxgi
{
    using System;

    [Flags]
    public enum DxgiPresentOptions
    {
        DoNotSequence = 2,
        Normal = 0,
        Restart = 4,
        Test = 2
    }
}

