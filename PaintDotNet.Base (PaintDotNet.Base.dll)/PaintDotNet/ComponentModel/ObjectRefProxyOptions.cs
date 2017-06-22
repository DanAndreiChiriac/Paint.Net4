namespace PaintDotNet.ComponentModel
{
    using System;

    [Flags]
    public enum ObjectRefProxyOptions
    {
        Default,
        DoNotCreateRef,
        DisposeInnerRef,
        AssumeOwnership,
        ProhibitDispose
    }
}

