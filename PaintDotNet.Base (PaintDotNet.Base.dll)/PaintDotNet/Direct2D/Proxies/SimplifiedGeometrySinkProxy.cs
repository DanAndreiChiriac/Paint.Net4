namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class SimplifiedGeometrySinkProxy : ObjectRefProxy<ISimplifiedGeometrySink>, ISimplifiedGeometrySink, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SimplifiedGeometrySinkProxy(ISimplifiedGeometrySink objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddBeziers(IList<BezierFloat> beziers, int startIndex, int length)
        {
            base.innerRefT.AddBeziers(beziers, startIndex, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddLines(IList<PointFloat> points, int startIndex, int length)
        {
            base.innerRefT.AddLines(points, startIndex, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void BeginFigure(PointFloat startPoint, FigureBegin figureBegin)
        {
            base.innerRefT.BeginFigure(startPoint, figureBegin);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Close()
        {
            base.innerRefT.Close();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EndFigure(FigureEnd figureEnd)
        {
            base.innerRefT.EndFigure(figureEnd);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFillMode(FillMode fillMode)
        {
            base.innerRefT.SetFillMode(fillMode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetSegmentOptions(PathSegmentOptions options)
        {
            base.innerRefT.SetSegmentOptions(options);
        }
    }
}

