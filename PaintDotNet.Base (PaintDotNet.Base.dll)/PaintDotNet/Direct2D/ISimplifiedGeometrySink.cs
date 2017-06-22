namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;
    using System.Collections.Generic;

    [CustomImplementationAllowed, NativeInterfaceID("2cd9069e-12e2-11dc-9fed-001143a055f9")]
    public interface ISimplifiedGeometrySink : IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        void AddBeziers(IList<BezierFloat> beziers, int startIndex, int length);
        void AddLines(IList<PointFloat> points, int startIndex, int length);
        void BeginFigure(PointFloat startPoint, FigureBegin figureBegin);
        void Close();
        void EndFigure(FigureEnd figureEnd);
        void SetFillMode(FillMode fillMode);
        void SetSegmentOptions(PathSegmentOptions options);
    }
}

