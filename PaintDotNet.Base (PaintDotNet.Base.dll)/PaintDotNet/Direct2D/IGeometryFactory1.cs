namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.Collections.Generic;

    public interface IGeometryFactory1 : IGeometryFactory, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IPathGeometry1 CreatePathGeometry();
        IStrokeStyle1 CreateStrokeStyle(StrokeStyleProperties1 strokeStyleProperties, IList<float> dashes, int startIndex, int length);
    }
}

