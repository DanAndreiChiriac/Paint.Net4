namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("acd16696-8c14-4f5d-877e-fe3fc1d32737")]
    public interface IFont : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        bool HasCharacter(uint ucs4Value);
        ILocalizedStrings TryGetInformationalStrings(InformationalStringID informationalStringID);

        ILocalizedStrings FaceNames { get; }

        IFontFamily FontFamily { get; }

        bool IsSymbolFont { get; }

        FontMetrics Metrics { get; }

        FontSimulations Simulations { get; }

        FontStretch Stretch { get; }

        FontStyle Style { get; }

        FontWeight Weight { get; }
    }
}

