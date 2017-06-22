namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("62baa2d2-ab54-41b7-b872-787e0106a421")]
    public interface IPathGeometry1 : IPathGeometry, IGeometry, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        PointDescriptionFloat ComputePointAndSegmentAtLength(float length, int startSegment, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
    }
}

