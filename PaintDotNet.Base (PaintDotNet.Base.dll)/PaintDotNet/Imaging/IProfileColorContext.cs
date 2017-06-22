namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IProfileColorContext : IColorContext, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        byte[] GetProfileBytes();
    }
}

