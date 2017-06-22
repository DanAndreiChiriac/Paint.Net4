namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using PaintDotNet.DirectWrite;
    using PaintDotNet.Imaging;
    using PaintDotNet.ObjectModel;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DeviceBitmapRenderTargetProxy : ObjectRefProxy<IDeviceBitmapRenderTarget>, IDeviceBitmapRenderTarget, IRenderTarget, IDrawingContext, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed, IDeviceResourceFactory, IResourceCache, IDeviceResource
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DeviceBitmapRenderTargetProxy(IDeviceBitmapRenderTarget objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void BeginDraw()
        {
            base.innerRefT.BeginDraw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear(ColorRgba128Float? clearColor)
        {
            base.innerRefT.Clear(clearColor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBitmapBrush CreateBitmapBrush(IDeviceBitmap bitmap, BitmapBrushProperties? bitmapBrushProperties, BrushProperties? brushProperties) => 
            base.innerRefT.CreateBitmapBrush(bitmap, bitmapBrushProperties, brushProperties);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDeviceBitmapRenderTarget CreateCompatibleRenderTarget(SizeFloat? desiredSize, SizeInt32? desiredPixelSize, Direct2DPixelFormat? desiredPixelFormat, CompatibleRenderTargetOptions options) => 
            base.innerRefT.CreateCompatibleRenderTarget(desiredSize, desiredPixelSize, desiredPixelFormat, options);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDeviceBitmap CreateDeviceBitmap(SizeInt32 size, IntPtr srcData, int stride, BitmapProperties bitmapProperties) => 
            base.innerRefT.CreateDeviceBitmap(size, srcData, stride, bitmapProperties);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDeviceBitmap CreateDeviceBitmapFromBitmap(IBitmapSource bitmapSource, BitmapProperties? bitmapProperties) => 
            base.innerRefT.CreateDeviceBitmapFromBitmap(bitmapSource, bitmapProperties);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IGradientStopCollection CreateGradientStopCollection(IList<GradientStopFloat> gradientStops, int startIndex, int length, Gamma? colorInterpolationGamma, ExtendMode? extendMode) => 
            base.innerRefT.CreateGradientStopCollection(gradientStops, startIndex, length, colorInterpolationGamma, extendMode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ILayer CreateLayer(SizeFloat? size) => 
            base.innerRefT.CreateLayer(size);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ILinearGradientBrush CreateLinearGradientBrush(LinearGradientBrushProperties linearGradientBrushProperties, BrushProperties? brushProperties, IGradientStopCollection gradientStopCollection) => 
            base.innerRefT.CreateLinearGradientBrush(linearGradientBrushProperties, brushProperties, gradientStopCollection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IMesh CreateMesh() => 
            base.innerRefT.CreateMesh();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IRadialGradientBrush CreateRadialGradientBrush(RadialGradientBrushProperties radialGradientBrushProperties, BrushProperties? brushProperties, IGradientStopCollection gradientStopCollection) => 
            base.innerRefT.CreateRadialGradientBrush(radialGradientBrushProperties, brushProperties, gradientStopCollection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDeviceBitmap CreateSharedBitmap(IDeviceBitmap bitmap, BitmapProperties? bitmapProperties) => 
            base.innerRefT.CreateSharedBitmap(bitmap, bitmapProperties);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDeviceBitmap CreateSharedBitmap(IBitmapLock bitmapLock, BitmapProperties? bitmapProperties) => 
            base.innerRefT.CreateSharedBitmap(bitmapLock, bitmapProperties);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ISolidColorBrush CreateSolidColorBrush(ColorRgba128Float color, BrushProperties? brushProperties) => 
            base.innerRefT.CreateSolidColorBrush(color, brushProperties);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawBitmap(IDeviceBitmap bitmap, RectFloat? dstRect, float opacity, BitmapInterpolationMode interpolationMode, RectFloat? srcRect)
        {
            base.innerRefT.DrawBitmap(bitmap, dstRect, opacity, interpolationMode, srcRect);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawEllipse(EllipseFloat ellipse, IBrush brush, float strokeWidth, IStrokeStyle strokeStyle)
        {
            base.innerRefT.DrawEllipse(ellipse, brush, strokeWidth, strokeStyle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawGeometry(IGeometry geometry, IBrush brush, float strokeWidth, IStrokeStyle strokeStyle)
        {
            base.innerRefT.DrawGeometry(geometry, brush, strokeWidth, strokeStyle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(PointFloat point0, PointFloat point1, IBrush brush, float strokeWidth, IStrokeStyle strokeStyle)
        {
            base.innerRefT.DrawLine(point0, point1, brush, strokeWidth, strokeStyle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRectangle(RectFloat rect, IBrush brush, float strokeWidth, IStrokeStyle strokeStyle)
        {
            base.innerRefT.DrawRectangle(rect, brush, strokeWidth, strokeStyle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRoundedRectangle(RoundedRectFloat roundedRect, IBrush brush, float strokeWidth, IStrokeStyle strokeStyle)
        {
            base.innerRefT.DrawRoundedRectangle(roundedRect, brush, strokeWidth, strokeStyle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawText(string text, ITextFormat textFormat, RectFloat layoutRect, IBrush defaultForegroundBrush, DrawTextOptions options, TextMeasuringMode measuringMode)
        {
            base.innerRefT.DrawText(text, textFormat, layoutRect, defaultForegroundBrush, options, measuringMode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawTextLayout(PointFloat origin, ITextLayout textLayout, IBrush defaultForegroundBrush, DrawTextOptions options)
        {
            base.innerRefT.DrawTextLayout(origin, textLayout, defaultForegroundBrush, options);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EndDraw(out Tag tag1, out Tag tag2)
        {
            base.innerRefT.EndDraw(out tag1, out tag2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillEllipse(EllipseFloat ellipse, IBrush brush)
        {
            base.innerRefT.FillEllipse(ellipse, brush);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillGeometry(IGeometry geometry, IBrush brush, IBrush opacityBrush)
        {
            base.innerRefT.FillGeometry(geometry, brush, opacityBrush);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillMesh(IMesh mesh, IBrush brush)
        {
            base.innerRefT.FillMesh(mesh, brush);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillOpacityMask(IDeviceBitmap opacityMask, IBrush brush, OpacityMaskContent content, RectFloat? dstRect, RectFloat? srcRect)
        {
            base.innerRefT.FillOpacityMask(opacityMask, brush, content, dstRect, srcRect);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillRectangle(RectFloat rect, IBrush brush)
        {
            base.innerRefT.FillRectangle(rect, brush);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillRoundedRectangle(RoundedRectFloat roundedRect, IBrush brush)
        {
            base.innerRefT.FillRoundedRectangle(roundedRect, brush);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Flush(out Tag tag1, out Tag tag2)
        {
            base.innerRefT.Flush(out tag1, out tag2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IObjectRef GetCachedOrCreateResource(IResourceSource resourceSource, Type interfaceType) => 
            base.innerRefT.GetCachedOrCreateResource(resourceSource, interfaceType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsInterpolationModeSupported(BitmapInterpolationMode mode) => 
            base.innerRefT.IsInterpolationModeSupported(mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSupported(RenderTargetProperties renderTargetProperties) => 
            base.innerRefT.IsSupported(renderTargetProperties);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PopAxisAlignedClip()
        {
            base.innerRefT.PopAxisAlignedClip();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PopLayer()
        {
            base.innerRefT.PopLayer();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PushAxisAlignedClip(RectFloat clipRect, PaintDotNet.Direct2D.AntialiasMode antialiasMode)
        {
            base.innerRefT.PushAxisAlignedClip(clipRect, antialiasMode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PushLayer(ILayer layer, LayerParameters layerParameters)
        {
            base.innerRefT.PushLayer(layer, layerParameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RestoreDrawingState(IDrawingStateBlock drawingStateBlock)
        {
            base.innerRefT.RestoreDrawingState(drawingStateBlock);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SaveDrawingState(IDrawingStateBlock drawingStateBlock)
        {
            base.innerRefT.SaveDrawingState(drawingStateBlock);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IObjectRef TryGetCachedResource(IResourceSource resourceSource, Type interfaceType) => 
            base.innerRefT.TryGetCachedResource(resourceSource, interfaceType);

        public PaintDotNet.Direct2D.AntialiasMode AntialiasMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.AntialiasMode;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.AntialiasMode = value;
            }
        }

        public IDeviceBitmap Bitmap =>
            base.innerRefT.Bitmap;

        public VectorFloat Dpi
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Dpi;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Dpi = value;
            }
        }

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;

        public int MaximumBitmapSize =>
            base.innerRefT.MaximumBitmapSize;

        VectorFloat IDrawingContext.Dpi =>
            base.innerRefT.Dpi;

        public Direct2DPixelFormat PixelFormat =>
            base.innerRefT.PixelFormat;

        public SizeInt32 PixelSize =>
            base.innerRefT.PixelSize;

        public SizeFloat Size =>
            base.innerRefT.Size;

        public bool SupportsResourceCaching =>
            base.innerRefT.SupportsResourceCaching;

        public TupleStruct<Tag, Tag> Tags
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Tags;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Tags = value;
            }
        }

        public PaintDotNet.Direct2D.TextAntialiasMode TextAntialiasMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.TextAntialiasMode;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.TextAntialiasMode = value;
            }
        }

        public ITextRenderingParams TextRenderingParams
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.TextRenderingParams;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.TextRenderingParams = value;
            }
        }

        public Matrix3x2Float Transform
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Transform;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Transform = value;
            }
        }
    }
}

