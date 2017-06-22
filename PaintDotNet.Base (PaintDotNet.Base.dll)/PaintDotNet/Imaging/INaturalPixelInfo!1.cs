namespace PaintDotNet.Imaging
{
    using PaintDotNet.Collections;

    public interface INaturalPixelInfo<TPixel> : INaturalPixelInfo, IPixelInfo, IUnsafeElementAccessor, IUnsafeElementAccessor<TPixel> where TPixel: struct, INaturalPixelInfo<TPixel>
    {
    }
}

