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
    public class GeometryFactory1Proxy : ObjectRefProxy<IGeometryFactory1>, IGeometryFactory1, IGeometryFactory, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GeometryFactory1Proxy(IGeometryFactory1 objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEllipseGeometry CreateEllipseGeometry(EllipseFloat ellipse) => 
            base.innerRefT.CreateEllipseGeometry(ellipse);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IGeometryGroup CreateGeometryGroup(FillMode fillMode, IList<IGeometry> geometries, int startIndex, int length) => 
            base.innerRefT.CreateGeometryGroup(fillMode, geometries, startIndex, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IPathGeometry1 CreatePathGeometry() => 
            base.innerRefT.CreatePathGeometry();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IRectangleGeometry CreateRectangleGeometry(RectFloat rectangle) => 
            base.innerRefT.CreateRectangleGeometry(rectangle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IRoundedRectangleGeometry CreateRoundedRectangleGeometry(RoundedRectFloat roundedRectangle) => 
            base.innerRefT.CreateRoundedRectangleGeometry(roundedRectangle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IStrokeStyle CreateStrokeStyle(StrokeStyleProperties strokeStyleProperties, IList<float> dashes, int startIndex, int length) => 
            base.innerRefT.CreateStrokeStyle(strokeStyleProperties, dashes, startIndex, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IStrokeStyle1 CreateStrokeStyle(StrokeStyleProperties1 strokeStyleProperties, IList<float> dashes, int startIndex, int length) => 
            base.innerRefT.CreateStrokeStyle(strokeStyleProperties, dashes, startIndex, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ITransformedGeometry CreateTransformedGeometry(IGeometry source, Matrix3x2Float transform) => 
            base.innerRefT.CreateTransformedGeometry(source, transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual IPathGeometry OnExplicitIGeometryFactoryCreatePathGeometry() => 
            base.innerRefT.CreatePathGeometry();

        IPathGeometry IGeometryFactory.CreatePathGeometry() => 
            this.OnExplicitIGeometryFactoryCreatePathGeometry();
    }
}

