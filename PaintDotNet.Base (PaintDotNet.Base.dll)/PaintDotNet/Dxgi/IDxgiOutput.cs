namespace PaintDotNet.Dxgi
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [NativeInterfaceID("ae02eedb-c735-4690-8d52-5a8dc20213aa")]
    public interface IDxgiOutput : IDxgiObject, IObjectRef, IDisposable, IIsDisposed
    {
        ModeDescription FindClosestMatchingMode(ModeDescription modeToMatch, object concernedDevice = null);
        IList<ModeDescription> GetDisplayModeList(DxgiFormat format, EnumModesOptions flags);
        void GetDisplaySurfaceData(IDxgiSurface destination);
        void ReleaseOwnership();
        void SetDisplaySurface(IDxgiSurface scanoutSurface);
        void TakeOwnership(object device, bool exclusive);
        void WaitForVBlank();

        OutputDescription Description { get; }

        PaintDotNet.Dxgi.FrameStatistics FrameStatistics { get; }

        PaintDotNet.Dxgi.GammaControl GammaControl { get; set; }

        PaintDotNet.Dxgi.GammaControlCapabilities GammaControlCapabilities { get; }
    }
}

