namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Rendering;
    using System;
    using System.Collections.Generic;

    public interface IGeometryFactory : IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IEllipseGeometry CreateEllipseGeometry(EllipseFloat ellipse);
        IGeometryGroup CreateGeometryGroup(FillMode fillMode, IList<IGeometry> geometries, int startIndex, int length);
        IPathGeometry CreatePathGeometry();
        IRectangleGeometry CreateRectangleGeometry(RectFloat rectangle);
        IRoundedRectangleGeometry CreateRoundedRectangleGeometry(RoundedRectFloat roundedRectangle);
        IStrokeStyle CreateStrokeStyle(StrokeStyleProperties strokeStyleProperties, IList<float> dashes, int startIndex, int length);
        ITransformedGeometry CreateTransformedGeometry(IGeometry source, Matrix3x2Float transform);
    }
}

