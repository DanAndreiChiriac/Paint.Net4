namespace PaintDotNet.Imaging
{
    public interface IBitmapLockData<TPixel> : IBitmapLockData where TPixel: struct, INaturalPixelInfo
    {
    }
}

