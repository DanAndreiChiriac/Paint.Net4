namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiSurfaceProxy : ObjectRefProxy<IDxgiSurface>, IDxgiSurface, IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSurfaceProxy(IDxgiSurface objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MappedRect Map(MapOptions flags) => 
            base.innerRefT.Map(flags);

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

