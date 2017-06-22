namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiResourceProxy : ObjectRefProxy<IDxgiResource>, IDxgiResource, IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiResourceProxy(IDxgiResource objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public IDxgiDevice Device =>
            base.innerRefT.Device;

        public ResourcePriority EvictionPriority
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.EvictionPriority;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.EvictionPriority = value;
            }
        }

        public IDxgiObject Parent =>
            base.innerRefT.Parent;

        public IntPtr SharedHandle =>
            base.innerRefT.SharedHandle;

        public UsageOptions Usage =>
            base.innerRefT.Usage;
    }
}

