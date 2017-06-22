namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("1edd9491-9853-4299-898f-6432983b6f3a")]
    public interface IDirectWriteGdiInterop : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        IFont CreateFontFromGdiFontFaceName(string gdiFontFaceName);
    }
}

