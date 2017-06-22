namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Globalization;

    [NativeInterfaceID("08256209-099a-4b34-b86d-c22b110e7771")]
    public interface ILocalizedStrings : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        CultureInfo GetLocale(int index);
        string GetString(int index);
        int IndexOfLocale(CultureInfo locale);

        int Count { get; }
    }
}

