namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("1a0d8438-1d97-4ec1-aef9-a2fb86ed6acb")]
    public interface IFontList : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        IFont GetFont(int index);

        IFontCollection FontCollection { get; }

        int FontCount { get; }
    }
}

