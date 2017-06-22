namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("a84cee02-3eea-4eee-a827-87c1a02a0fcc")]
    public interface IFontCollection : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        IFontFamily GetFontFamily(int index);
        int IndexOfFamilyName(string familyName);

        int FontFamilyCount { get; }
    }
}

