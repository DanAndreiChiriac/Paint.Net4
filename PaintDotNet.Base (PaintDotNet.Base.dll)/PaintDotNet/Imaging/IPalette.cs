namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;
    using System.Collections.Generic;

    public interface IPalette : IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        IList<ColorBgra32> Colors { get; }

        bool HasAlpha { get; }

        bool IsBlackWhite { get; }

        bool IsGrayscale { get; }

        BitmapPaletteType PaletteType { get; }
    }
}

