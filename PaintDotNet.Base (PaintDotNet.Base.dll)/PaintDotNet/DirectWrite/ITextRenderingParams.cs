namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("2f0da53a-2add-47cd-82ee-d9ec34688e75")]
    public interface ITextRenderingParams : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        float ClearTypeLevel { get; }

        float EnhancedContrast { get; }

        float Gamma { get; }

        PaintDotNet.DirectWrite.PixelGeometry PixelGeometry { get; }

        TextRenderingMode RenderingMode { get; }
    }
}

