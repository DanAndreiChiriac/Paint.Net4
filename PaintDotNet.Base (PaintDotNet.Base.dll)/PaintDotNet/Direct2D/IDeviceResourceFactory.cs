namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using PaintDotNet.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public interface IDeviceResourceFactory : IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        IBitmapBrush CreateBitmapBrush(IDeviceBitmap bitmap, BitmapBrushProperties? bitmapBrushProperties = new BitmapBrushProperties?(), BrushProperties? brushProperties = new BrushProperties?());
        IDeviceBitmapRenderTarget CreateCompatibleRenderTarget(SizeFloat? desiredSize = new SizeFloat?(), SizeInt32? desiredPixelSize = new SizeInt32?(), Direct2DPixelFormat? desiredPixelFormat = new Direct2DPixelFormat?(), CompatibleRenderTargetOptions options = 0);
        IDeviceBitmap CreateDeviceBitmap(SizeInt32 size, [Optional] IntPtr srcData, int stride, BitmapProperties bitmapProperties);
        IDeviceBitmap CreateDeviceBitmapFromBitmap(IBitmapSource bitmapSource, BitmapProperties? bitmapProperties = new BitmapProperties?());
        IGradientStopCollection CreateGradientStopCollection(IList<GradientStopFloat> gradientStops, int startIndex, int length, Gamma? colorInterpolationGamma = new Gamma?(), ExtendMode? extendMode = new ExtendMode?());
        ILayer CreateLayer(SizeFloat? size = new SizeFloat?());
        ILinearGradientBrush CreateLinearGradientBrush(LinearGradientBrushProperties linearGradientBrushProperties, [Optional] BrushProperties? brushProperties, IGradientStopCollection gradientStopCollection);
        IMesh CreateMesh();
        IRadialGradientBrush CreateRadialGradientBrush(RadialGradientBrushProperties radialGradientBrushProperties, [Optional] BrushProperties? brushProperties, IGradientStopCollection gradientStopCollection);
        IDeviceBitmap CreateSharedBitmap(IDeviceBitmap bitmap, BitmapProperties? bitmapProperties = new BitmapProperties?());
        IDeviceBitmap CreateSharedBitmap(IBitmapLock bitmapLock, BitmapProperties? bitmapProperties = new BitmapProperties?());
        ISolidColorBrush CreateSolidColorBrush(ColorRgba128Float color, BrushProperties? brushProperties = new BrushProperties?());
        bool IsSupported(RenderTargetProperties renderTargetProperties);

        int MaximumBitmapSize { get; }

        Direct2DPixelFormat PixelFormat { get; }
    }
}

