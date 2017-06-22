namespace PaintDotNet.Drawing
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public static class GdipBitmapUtil
    {
        public static Bitmap CreateAlias(Bitmap bitmap)
        {
            Bitmap bitmap2;
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(new Point(0, 0), bitmap.Size), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            try
            {
                bitmap2 = new Bitmap(bitmapdata.Width, bitmapdata.Height, bitmapdata.Stride, bitmapdata.PixelFormat, bitmapdata.Scan0);
            }
            finally
            {
                bitmap.UnlockBits(bitmapdata);
            }
            return bitmap2;
        }
    }
}

