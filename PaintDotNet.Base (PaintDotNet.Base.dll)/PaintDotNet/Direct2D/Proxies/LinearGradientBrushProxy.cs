namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class LinearGradientBrushProxy : ObjectRefProxy<ILinearGradientBrush>, ILinearGradientBrush, IGradientBrush, IBrush, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LinearGradientBrushProxy(ILinearGradientBrush objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public PointFloat EndPoint
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.EndPoint;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.EndPoint = value;
            }
        }

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;

        public IGradientStopCollection GradientStopCollection =>
            base.innerRefT.GradientStopCollection;

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

        public PointFloat StartPoint
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.StartPoint;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.StartPoint = value;
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

