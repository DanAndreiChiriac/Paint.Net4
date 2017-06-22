namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("fbec5e44-f7be-4b65-b7f8-c0c81fef026d")]
    public interface IDevelopRaw : IBitmapFrameDecode, IBitmapSource, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        double Contrast { get; }
    }
}

