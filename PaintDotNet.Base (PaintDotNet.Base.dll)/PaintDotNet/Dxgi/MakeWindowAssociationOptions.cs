namespace PaintDotNet.Dxgi
{
    using System;

    [Flags]
    public enum MakeWindowAssociationOptions
    {
        NoAltEnter = 2,
        NoPrintScreen = 4,
        NoWindowChanges = 1
    }
}

