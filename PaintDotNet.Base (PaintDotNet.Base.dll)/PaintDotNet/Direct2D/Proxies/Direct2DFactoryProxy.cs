namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using PaintDotNet.DirectWrite;
    using PaintDotNet.Imaging;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class Direct2DFactoryProxy : ObjectRefProxy<IDirect2DFactory>, IDirect2DFactory, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IGeometryFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Direct2DFactoryProxy(IDirect2DFactory objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IRenderTarget CreateBitmapRenderTarget(IBitmap target, RenderTargetProperties renderTargetProps) => 
            base.innerRefT.CreateBitmapRenderTarget(target, renderTargetProps);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDCRenderTarget CreateDCRenderTarget(RenderTargetProperties renderTargetProps) => 
            base.innerRefT.CreateDCRenderTarget(renderTargetProps);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDrawingStateBlock CreateDrawingStateBlock(DrawingStateDescription? drawingStateDescription, ITextRenderingParams textRenderingParams) => 
            base.innerRefT.CreateDrawingStateBlock(drawingStateDescription, textRenderingParams);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEllipseGeometry CreateEllipseGeometry(EllipseFloat ellipse) => 
            base.innerRefT.CreateEllipseGeometry(ellipse);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IGeometryGroup CreateGeometryGroup(FillMode fillMode, IList<IGeometry> geometries, int startIndex, int length) => 
            base.innerRefT.CreateGeometryGroup(fillMode, geometries, startIndex, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IHwndRenderTarget CreateHwndRenderTarget(RenderTargetProperties renderTargetProperties, HwndRenderTargetProperties hwndRenderTargetProperties) => 
            base.innerRefT.CreateHwndRenderTarget(renderTargetProperties, hwndRenderTargetProperties);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IPathGeometry CreatePathGeometry() => 
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
        public ITransformedGeometry CreateTransformedGeometry(IGeometry source, Matrix3x2Float transform) => 
            base.innerRefT.CreateTransformedGeometry(source, transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReloadSystemMetrics()
        {
            base.innerRefT.ReloadSystemMetrics();
        }

        public VectorFloat DesktopDpi =>
            base.innerRefT.DesktopDpi;
    }
}

