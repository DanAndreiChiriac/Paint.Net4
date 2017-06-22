namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("55f1112b-1dc2-4b3c-9541-f46894ed85b6")]
    public interface ITypography : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        void AddFontFeature(FontFeature fontFeature);
        FontFeature GetFontFeature(int fontFeatureIndex);

        int FontFeatureCount { get; }
    }
}

