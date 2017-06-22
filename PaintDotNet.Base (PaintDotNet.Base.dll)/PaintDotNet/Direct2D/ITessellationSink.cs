namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;

    [CustomImplementationAllowed, NativeInterfaceID("2cd906c1-12e2-11dc-9fed-001143a055f9")]
    public interface ITessellationSink : IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        void AddTriangles(IList<TriangleFloat> triangles, int startIndex, int length);
        void Close();
    }
}

