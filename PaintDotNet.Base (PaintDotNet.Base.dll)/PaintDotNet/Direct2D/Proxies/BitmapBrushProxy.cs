namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using PaintDotNet.Imaging;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BitmapBrushProxy : ObjectRefProxy<IBitmapBrush>, IBitmapBrush, IBrush, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapBrushProxy(IBitmapBrush objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public IDeviceBitmap Bitmap
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Bitmap;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Bitmap = value;
            }
        }

        public ExtendMode ExtendModeX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.ExtendModeX;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.ExtendModeX = value;
            }
        }

        public ExtendMode ExtendModeY
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.ExtendModeY;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.ExtendModeY = value;
            }
        }

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;

        public BitmapInterpolationMode InterpolationMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.InterpolationMode;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.InterpolationMode = value;
            }
        }

        public float Opacity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Opacity;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Opacity = value;
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

