namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("da20d8ef-812a-4c43-9802-62ec4abd7add")]
    public interface IFontFamily : IFontList, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        IFont GetFirstMatchingFont(FontWeight weight, FontStretch stretch, FontStyle style);
        IFontList GetMatchingFonts(FontWeight weight, FontStretch stretch, FontStyle style);

        ILocalizedStrings FamilyNames { get; }
    }
}

