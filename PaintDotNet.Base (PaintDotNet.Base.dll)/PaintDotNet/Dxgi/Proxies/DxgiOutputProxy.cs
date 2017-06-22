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
    public class DxgiOutputProxy : ObjectRefProxy<IDxgiOutput>, IDxgiOutput, IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiOutputProxy(IDxgiOutput objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ModeDescription FindClosestMatchingMode(ModeDescription modeToMatch, object concernedDevice) => 
            base.innerRefT.FindClosestMatchingMode(modeToMatch, concernedDevice);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IList<ModeDescription> GetDisplayModeList(DxgiFormat format, EnumModesOptions flags) => 
            base.innerRefT.GetDisplayModeList(format, flags);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetDisplaySurfaceData(IDxgiSurface destination)
        {
            base.innerRefT.GetDisplaySurfaceData(destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseOwnership()
        {
            base.innerRefT.ReleaseOwnership();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDisplaySurface(IDxgiSurface scanoutSurface)
        {
            base.innerRefT.SetDisplaySurface(scanoutSurface);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TakeOwnership(object device, bool exclusive)
        {
            base.innerRefT.TakeOwnership(device, exclusive);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WaitForVBlank()
        {
            base.innerRefT.WaitForVBlank();
        }

        public OutputDescription Description =>
            base.innerRefT.Description;

        public PaintDotNet.Dxgi.FrameStatistics FrameStatistics =>
            base.innerRefT.FrameStatistics;

        public PaintDotNet.Dxgi.GammaControl GammaControl
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.GammaControl;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.GammaControl = value;
            }
        }

        public PaintDotNet.Dxgi.GammaControlCapabilities GammaControlCapabilities =>
            base.innerRefT.GammaControlCapabilities;

        public IDxgiObject Parent =>
            base.innerRefT.Parent;
    }
}

