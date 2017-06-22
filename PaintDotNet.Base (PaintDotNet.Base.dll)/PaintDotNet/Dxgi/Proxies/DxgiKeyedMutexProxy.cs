namespace PaintDotNet.Dxgi.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Dxgi;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class DxgiKeyedMutexProxy : ObjectRefProxy<IDxgiKeyedMutex>, IDxgiKeyedMutex, IDxgiDeviceSubObject, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiKeyedMutexProxy(IDxgiKeyedMutex objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool AcquireSync(long key, int milliseconds) => 
            base.innerRefT.AcquireSync(key, milliseconds);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseSync(long key)
        {
            base.innerRefT.ReleaseSync(key);
        }

        public IDxgiDevice Device =>
            base.innerRefT.Device;

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

