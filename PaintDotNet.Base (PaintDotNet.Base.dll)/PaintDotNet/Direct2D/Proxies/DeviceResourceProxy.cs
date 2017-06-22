namespace PaintDotNet.Direct2D.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Direct2D;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DeviceResourceProxy : ObjectRefProxy<IDeviceResource>, IDeviceResource, IDirect2DResource, IDirect2DObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DeviceResourceProxy(IDeviceResource objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public IDirect2DFactory Factory =>
            base.innerRefT.Factory;
    }
}

