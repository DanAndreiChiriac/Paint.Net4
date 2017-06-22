namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("2cd906a5-12e2-11dc-9fed-001143a055f9")]
    public interface IPathGeometry : IGeometry, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IGeometrySink Open();
        void Stream(IGeometrySink geometrySink);

        int FigureCount { get; }

        int SegmentCount { get; }
    }
}

