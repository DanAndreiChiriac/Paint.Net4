namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Rendering;
    using PaintDotNet.Threading;
    using System;

    internal sealed class CancellableBitmapSource<TPixel> : RefTrackedObject, IBitmapSource<TPixel>, IBitmapSource, IImagingObject, IObjectRef, IDisposable, IIsDisposed where TPixel: struct, INaturalPixelInfo
    {
        private readonly int bytesPerPixel;
        private ICancellationToken cancelToken;
        private Action<RectInt32> rectCompletedCallback;
        private IBitmapSource<TPixel> source;
        private Func<RectInt32, IEnumerable<RectInt32>> sourceRectSplitter;
        private SizeInt32 sourceSize;

        public CancellableBitmapSource(IBitmapSource<TPixel> source, Func<RectInt32, IEnumerable<RectInt32>> sourceRectSplitter, Action<RectInt32> rectCompletedCallback, ICancellationToken cancelToken)
        {
            Validate.Begin().IsNotNull<IBitmapSource<TPixel>>(source, "source").IsNotNull<Func<RectInt32, IEnumerable<RectInt32>>>(sourceRectSplitter, "sourceRectSplitter").IsNotNull<ICancellationToken>(cancelToken, "cancelToken").Check();
            this.source = source.CreateRef<TPixel>();
            this.sourceSize = this.source.Size;
            this.sourceRectSplitter = sourceRectSplitter;
            this.rectCompletedCallback = rectCompletedCallback;
            this.cancelToken = cancelToken;
            TPixel local = default(TPixel);
            this.bytesPerPixel = local.BytesPerPixel;
        }

        public unsafe void CopyPixels(RectInt32? srcRect, int bufferStride, int bufferSize, IntPtr buffer)
        {
            RectInt32? nullable = srcRect;
            RectInt32 arg = nullable.HasValue ? nullable.GetValueOrDefault() : new RectInt32(PointInt32.Zero, this.sourceSize);
            byte* numPtr = (byte*) buffer;
            if (this.cancelToken != null)
            {
                this.cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
            }
            foreach (RectInt32 num2 in this.sourceRectSplitter(arg))
            {
                int num3 = num2.X - arg.X;
                int num4 = num2.Y - arg.Y;
                byte* numPtr2 = (numPtr + (num4 * bufferStride)) + (num3 * this.bytesPerPixel);
                int num5 = bufferSize - ((int) ((long) ((numPtr2 - numPtr) / 1)));
                if (this.cancelToken != null)
                {
                    this.cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                }
                this.source.CopyPixels(new RectInt32?(num2), bufferStride, num5, (IntPtr) numPtr2);
                if (this.rectCompletedCallback != null)
                {
                    this.rectCompletedCallback(num2);
                }
                if (this.cancelToken != null)
                {
                    this.cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                }
            }
            if (this.cancelToken != null)
            {
                this.cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
            }
        }

        protected override void Dispose(bool disposing)
        {
            DisposableUtil.Free<IBitmapSource<TPixel>>(ref this.source, disposing);
            base.Dispose(disposing);
        }

        public IPalette Palette =>
            this.source.Palette;

        public PaintDotNet.Imaging.PixelFormat PixelFormat
        {
            get
            {
                TPixel local = default(TPixel);
                return local.PixelFormat;
            }
        }

        public VectorDouble Resolution =>
            this.source.Resolution;

        public SizeInt32 Size =>
            this.sourceSize;
    }
}

