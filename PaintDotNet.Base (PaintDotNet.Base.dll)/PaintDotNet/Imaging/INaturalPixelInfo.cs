namespace PaintDotNet.Imaging
{
    using PaintDotNet.Collections;
    using System;

    public interface INaturalPixelInfo : IPixelInfo, IUnsafeElementAccessor
    {
        int BytesPerPixel { get; }
    }
}

