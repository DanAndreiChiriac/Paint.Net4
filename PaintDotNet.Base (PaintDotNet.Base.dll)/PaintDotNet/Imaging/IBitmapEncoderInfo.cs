namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("94c9b4ee-a09f-4f92-8a1e-4a9bce7e76fb")]
    public interface IBitmapEncoderInfo : IBitmapCodecInfo, IImagingComponentInfo, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        IBitmapEncoder CreateInstance(Stream stream, BitmapEncoderCacheOption cacheOption = 2);
    }
}

