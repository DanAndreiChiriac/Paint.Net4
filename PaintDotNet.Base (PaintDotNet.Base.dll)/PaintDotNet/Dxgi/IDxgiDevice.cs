namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("54ec77fa-1377-44e6-8c32-88fd5f44c84c")]
    public interface IDxgiDevice : IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        IDxgiSurface CreateSurface(SurfaceDescription surfaceDescription, int surfacesCount, UsageOptions usage, SharedResource? sharedResource = new SharedResource?());
        IList<Residency> QueryResourceResidency(IList<IDxgiResource> resources);

        IDxgiAdapter Adapter { get; }

        int GpuThreadPriority { get; set; }
    }
}

