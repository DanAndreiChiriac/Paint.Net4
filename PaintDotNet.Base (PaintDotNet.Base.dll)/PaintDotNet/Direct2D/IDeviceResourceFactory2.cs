namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.Runtime.InteropServices;

    public interface IDeviceResourceFactory2 : IDeviceResourceFactory1, IDeviceResourceFactory, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IGeometryRealization CreateFilledGeometryRealization(IGeometry geometry, float? flatteningTolerance = new float?());
        IGeometryRealization CreateStrokedGeometryRealization(IGeometry geometry, float strokeWidth = 1f, IStrokeStyle strokeStyle = null, float? flatteningTolerance = new float?());
    }
}

