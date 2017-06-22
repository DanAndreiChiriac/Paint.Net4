namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiDeviceProxy : ObjectRefProxy<IDxgiDevice>, IDxgiDevice, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiDeviceProxy(IDxgiDevice objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDxgiSurface CreateSurface(SurfaceDescription surfaceDescription, int surfacesCount, UsageOptions usage, SharedResource? sharedResource) => 
            base.innerRefT.CreateSurface(surfaceDescription, surfacesCount, usage, sharedResource);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IList<Residency> QueryResourceResidency(IList<IDxgiResource> resources) => 
            base.innerRefT.QueryResourceResidency(resources);

        public IDxgiAdapter Adapter =>
            base.innerRefT.Adapter;

        public int GpuThreadPriority
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.GpuThreadPriority;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.GpuThreadPriority = value;
            }
        }

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

