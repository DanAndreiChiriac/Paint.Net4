namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;

    [NativeInterfaceID("2cd906a6-12e2-11dc-9fed-001143a055f9")]
    public interface IGeometryGroup : IGeometry, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        PaintDotNet.Direct2D.FillMode FillMode { get; }

        IList<IGeometry> SourceGeometries { get; }
    }
}

