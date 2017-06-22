namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("2cd906a1-12e2-11dc-9fed-001143a055f9")]
    public interface IGeometry : IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        void CombineWithGeometry(ISimplifiedGeometrySink geometrySink, IGeometry inputGeometry, GeometryCombineMode combineMode, Matrix3x2Float? inputGeometryTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        GeometryRelation CompareWithGeometry(IGeometry inputGeometry, Matrix3x2Float? inputGeometryTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        float ComputeArea(Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        float ComputeLength(Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        PointAndTangentFloat ComputePointAtLength(float length, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        bool FillContainsPoint(PointFloat point, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        RectFloat GetBounds(Matrix3x2Float? worldTransform = new Matrix3x2Float?());
        RectFloat GetWidenedBounds(float strokeWidth, IStrokeStyle strokeStyle = null, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        void Outline(ISimplifiedGeometrySink geometrySink, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        void Simplify(ISimplifiedGeometrySink geometrySink, GeometrySimplificationOption simplificationOption = 1, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        bool StrokeContainsPoint(PointFloat point, float strokeWidth, IStrokeStyle strokeStyle = null, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        void Tessellate(ITessellationSink tessellationSink, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
        void Widen(ISimplifiedGeometrySink geometrySink, float strokeWidth, IStrokeStyle strokeStyle = null, Matrix3x2Float? worldTransform = new Matrix3x2Float?(), float? flatteningTolerance = new float?());
    }
}

