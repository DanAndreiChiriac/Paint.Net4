namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;
    using System.Collections.Generic;

    [CustomImplementationAllowed, NativeInterfaceID("2cd9069f-12e2-11dc-9fed-001143a055f9")]
    public interface IGeometrySink : ISimplifiedGeometrySink, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        void AddArc(ArcFloat arc);
        void AddBezier(BezierFloat bezier);
        void AddLine(PointFloat point);
        void AddQuadraticBezier(QuadraticBezierFloat bezier);
        void AddQuadraticBeziers(IList<QuadraticBezierFloat> beziers, int startIndex, int length);
    }
}

