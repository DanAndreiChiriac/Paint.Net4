namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using PaintDotNet.Imaging;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DeviceResourceFactory2Proxy : ObjectRefProxy<IDeviceResourceFactory2>, IDeviceResourceFactory2, IDeviceResourceFactory1, IDeviceResourceFactory, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DeviceResourceFactory2Proxy(IDeviceResourceFactory2 objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
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
        public IGeometryRealization CreateFilledGeometryRealization(IGeometry geometry, float? flatteningTolerance) => 
            base.innerRefT.CreateFilledGeometryRealization(geometry, flatteningTolerance);

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
        public IGeometryRealization CreateStrokedGeometryRealization(IGeometry geometry, float strokeWidth, IStrokeStyle strokeStyle, float? flatteningTolerance) => 
            base.innerRefT.CreateStrokedGeometryRealization(geometry, strokeWidth, strokeStyle, flatteningTolerance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSupported(RenderTargetProperties renderTargetProperties) => 
            base.innerRefT.IsSupported(renderTargetProperties);

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;

        public int MaximumBitmapSize =>
            base.innerRefT.MaximumBitmapSize;

        public Direct2DPixelFormat PixelFormat =>
            base.innerRefT.PixelFormat;
    }
}

