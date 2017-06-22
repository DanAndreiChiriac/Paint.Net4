namespace PaintDotNet.Imaging.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Imaging;
    using PaintDotNet.Rendering;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class BitmapFrameEncodeProxy : ObjectRefProxy<IBitmapFrameEncode>, IBitmapFrameEncode, IImagingObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BitmapFrameEncodeProxy(IBitmapFrameEncode objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Commit()
        {
            base.innerRefT.Commit();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PixelFormat SetPixelFormat(PixelFormat pixelFormat) => 
            base.innerRefT.SetPixelFormat(pixelFormat);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WritePixels(int lineCount, int stride, long bufferSize, IntPtr pixels)
        {
            base.innerRefT.WritePixels(lineCount, stride, bufferSize, pixels);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteSource(IBitmapSource bitmapSource, RectInt32? rect)
        {
            base.innerRefT.WriteSource(bitmapSource, rect);
        }

        public IEnumerable<IColorContext> ColorContexts
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.ColorContexts = value;
            }
        }

        public IMetadataQueryWriter MetadataQueryWriter =>
            base.innerRefT.MetadataQueryWriter;

        public IPalette Palette
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Palette = value;
            }
        }

        public VectorDouble Resolution
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Resolution = value;
            }
        }

        public SizeInt32 Size
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Size = value;
            }
        }

        public IBitmapSource Thumbnail
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Thumbnail = value;
            }
        }
    }
}

