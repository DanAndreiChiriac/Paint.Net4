namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("10a72a66-e91c-43f4-993f-ddf4b82b0b4a")]
    public interface IStrokeStyle1 : IStrokeStyle, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        StrokeTransformType TransformType { get; }
    }
}

