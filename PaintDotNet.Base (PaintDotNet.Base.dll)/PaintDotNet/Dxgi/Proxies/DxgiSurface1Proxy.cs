namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiSurface1Proxy : ObjectRefProxy<IDxgiSurface1>, IDxgiSurface1, IDxgiSurface, IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSurface1Proxy(IDxgiSurface1 objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IntPtr GetDC(bool discard) => 
            base.innerRefT.GetDC(discard);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MappedRect Map(MapOptions flags) => 
            base.innerRefT.Map(flags);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseDC(RectInt32? dirtyRect)
        {
            base.innerRefT.ReleaseDC(dirtyRect);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Unmap()
        {
            base.innerRefT.Unmap();
        }

        public SurfaceDescription Description =>
            base.innerRefT.Description;

        public IDxgiDevice Device =>
            base.innerRefT.Device;

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

