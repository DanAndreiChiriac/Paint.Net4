namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;

    [NativeInterfaceID("2cd9069d-12e2-11dc-9fed-001143a055f9")]
    public interface IStrokeStyle : IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        CapStyle DashCap { get; }

        IList<float> Dashes { get; }

        float DashOffset { get; }

        PaintDotNet.Direct2D.DashStyle DashStyle { get; }

        CapStyle EndCap { get; }

        PaintDotNet.Direct2D.LineJoin LineJoin { get; }

        float MiterLimit { get; }

        CapStyle StartCap { get; }
    }
}

