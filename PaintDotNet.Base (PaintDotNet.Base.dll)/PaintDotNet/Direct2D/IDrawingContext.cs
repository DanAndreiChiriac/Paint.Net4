namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using PaintDotNet.Imaging;
    using PaintDotNet.ObjectModel;
    using PaintDotNet.Rendering;
    using System;
    using System.Runtime.InteropServices;

    public interface IDrawingContext : IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache
    {
        void Clear(ColorRgba128Float? clearColor = new ColorRgba128Float?());
        void DrawBitmap(IDeviceBitmap bitmap, RectFloat? dstRect = new RectFloat?(), float opacity = 1f, BitmapInterpolationMode interpolationMode = 1, RectFloat? srcRect = new RectFloat?());
        void DrawEllipse(EllipseFloat ellipse, IBrush brush, float strokeWidth = 1f, IStrokeStyle strokeStyle = null);
        void DrawGeometry(IGeometry geometry, IBrush brush, float strokeWidth = 1f, IStrokeStyle strokeStyle = null);
        void DrawLine(PointFloat point0, PointFloat point1, IBrush brush, float strokeWidth = 1f, IStrokeStyle strokeStyle = null);
        void DrawRectangle(RectFloat rect, IBrush brush, float strokeWidth = 1f, IStrokeStyle strokeStyle = null);
        void DrawRoundedRectangle(RoundedRectFloat roundedRect, IBrush brush, float strokeWidth = 1f, IStrokeStyle strokeStyle = null);
        void DrawText(string text, ITextFormat textFormat, RectFloat layoutRect, IBrush defaultForegroundBrush, DrawTextOptions options, TextMeasuringMode measuringMode);
        void DrawTextLayout(PointFloat origin, ITextLayout textLayout, IBrush defaultForegroundBrush, DrawTextOptions options = 0);
        void FillEllipse(EllipseFloat ellipse, IBrush brush);
        void FillGeometry(IGeometry geometry, IBrush brush, IBrush opacityBrush = null);
        void FillMesh(IMesh mesh, IBrush brush);
        void FillOpacityMask(IDeviceBitmap opacityMask, IBrush brush, OpacityMaskContent content, RectFloat? dstRect = new RectFloat?(), RectFloat? srcRect = new RectFloat?());
        void FillRectangle(RectFloat rect, IBrush brush);
        void FillRoundedRectangle(RoundedRectFloat roundedRect, IBrush brush);
        void Flush(out Tag tag1, out Tag tag2);
        bool IsInterpolationModeSupported(BitmapInterpolationMode mode);
        void PopAxisAlignedClip();
        void PopLayer();
        void PushAxisAlignedClip(RectFloat clipRect, PaintDotNet.Direct2D.AntialiasMode antialiasMode);
        void PushLayer(ILayer layer, LayerParameters layerParameters);
        void RestoreDrawingState(IDrawingStateBlock drawingStateBlock);
        void SaveDrawingState(IDrawingStateBlock drawingStateBlock);

        PaintDotNet.Direct2D.AntialiasMode AntialiasMode { get; set; }

        VectorFloat Dpi { get; }

        SizeInt32 PixelSize { get; }

        SizeFloat Size { get; }

        TupleStruct<Tag, Tag> Tags { get; set; }

        PaintDotNet.Direct2D.TextAntialiasMode TextAntialiasMode { get; set; }

        ITextRenderingParams TextRenderingParams { get; set; }

        Matrix3x2Float Transform { get; set; }
    }
}

