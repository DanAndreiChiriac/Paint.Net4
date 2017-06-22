namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class GeometryProxy : ObjectRefProxy<IGeometry>, IGeometry, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GeometryProxy(IGeometry objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CombineWithGeometry(ISimplifiedGeometrySink geometrySink, IGeometry inputGeometry, GeometryCombineMode combineMode, Matrix3x2Float? inputGeometryTransform, float? flatteningTolerance)
        {
            base.innerRefT.CombineWithGeometry(geometrySink, inputGeometry, combineMode, inputGeometryTransform, flatteningTolerance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GeometryRelation CompareWithGeometry(IGeometry inputGeometry, Matrix3x2Float? inputGeometryTransform, float? flatteningTolerance) => 
            base.innerRefT.CompareWithGeometry(inputGeometry, inputGeometryTransform, flatteningTolerance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeArea(Matrix3x2Float? worldTransform, float? flatteningTolerance) => 
            base.innerRefT.ComputeArea(worldTransform, flatteningTolerance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeLength(Matrix3x2Float? worldTransform, float? flatteningTolerance) => 
            base.innerRefT.ComputeLength(worldTransform, flatteningTolerance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PointAndTangentFloat ComputePointAtLength(float length, Matrix3x2Float? worldTransform, float? flatteningTolerance) => 
            base.innerRefT.ComputePointAtLength(length, worldTransform, flatteningTolerance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool FillContainsPoint(PointFloat point, Matrix3x2Float? worldTransform, float? flatteningTolerance) => 
            base.innerRefT.FillContainsPoint(point, worldTransform, flatteningTolerance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RectFloat GetBounds(Matrix3x2Float? worldTransform) => 
            base.innerRefT.GetBounds(worldTransform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RectFloat GetWidenedBounds(float strokeWidth, IStrokeStyle strokeStyle, Matrix3x2Float? worldTransform, float? flatteningTolerance) => 
            base.innerRefT.GetWidenedBounds(strokeWidth, strokeStyle, worldTransform, flatteningTolerance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Outline(ISimplifiedGeometrySink geometrySink, Matrix3x2Float? worldTransform, float? flatteningTolerance)
        {
            base.innerRefT.Outline(geometrySink, worldTransform, flatteningTolerance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Simplify(ISimplifiedGeometrySink geometrySink, GeometrySimplificationOption simplificationOption, Matrix3x2Float? worldTransform, float? flatteningTolerance)
        {
            base.innerRefT.Simplify(geometrySink, simplificationOption, worldTransform, flatteningTolerance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool StrokeContainsPoint(PointFloat point, float strokeWidth, IStrokeStyle strokeStyle, Matrix3x2Float? worldTransform, float? flatteningTolerance) => 
            base.innerRefT.StrokeContainsPoint(point, strokeWidth, strokeStyle, worldTransform, flatteningTolerance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Tessellate(ITessellationSink tessellationSink, Matrix3x2Float? worldTransform, float? flatteningTolerance)
        {
            base.innerRefT.Tessellate(tessellationSink, worldTransform, flatteningTolerance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Widen(ISimplifiedGeometrySink geometrySink, float strokeWidth, IStrokeStyle strokeStyle, Matrix3x2Float? worldTransform, float? flatteningTolerance)
        {
            base.innerRefT.Widen(geometrySink, strokeWidth, strokeStyle, worldTransform, flatteningTolerance);
        }

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;
    }
}

