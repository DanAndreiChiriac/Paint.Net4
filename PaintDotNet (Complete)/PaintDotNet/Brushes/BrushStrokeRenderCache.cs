namespace PaintDotNet.Brushes
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Direct2D;
    using PaintDotNet.Functional;
    using PaintDotNet.ObjectModel;
    using PaintDotNet.Rendering;
    using PaintDotNet.Threading;
    using PaintDotNet.Tools;
    using PaintDotNet.UI.Media;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;

    internal sealed class BrushStrokeRenderCache
    {
        private int haveFetchedStamp;
        private LazyResult<DeviceBitmap> lazyStampMaskDevBitmap;
        private BrushStrokeRenderData renderData;
        private BrushStamp stamp;
        private TileMathHelper tileMathHelper;
        private ConcurrentDictionary<PointInt32, TileData> tileOffsetToTileDataMap;
        private static readonly SolidColorBrush whiteBrush = SolidColorBrushCache.Get((ColorRgba128Float) Colors.White);

        public BrushStrokeRenderCache(BrushStrokeRenderData renderData, BrushStamp stamp, int tileEdgeLog2)
        {
            Validate.Begin().IsNotNull<BrushStrokeRenderData>(renderData, "renderData").IsNotNull<BrushStamp>(stamp, "stamp").Check();
            this.renderData = renderData;
            this.stamp = stamp;
            this.lazyStampMaskDevBitmap = LazyResult.New<DeviceBitmap>(() => new DeviceBitmap(this.stamp.MaskBitmap).EnsureFrozen<DeviceBitmap>(), LazyThreadSafetyMode.ExecutionAndPublication, new SingleUseCriticalSection());
            this.tileOffsetToTileDataMap = new ConcurrentDictionary<PointInt32, TileData>();
            this.tileMathHelper = new TileMathHelper(TransactedToolChanges.MaxMaxRenderBounds.Size, tileEdgeLog2);
        }

        public IRenderer<ColorAlpha8> CreateMaskRenderer(SizeInt32 size, ICancellationToken cancelToken) => 
            this.CreateMaskRenderer(size.Width, size.Height, cancelToken);

        public IRenderer<ColorAlpha8> CreateMaskRenderer(int width, int height, ICancellationToken cancelToken) => 
            new MaskRenderer(this, width, height, cancelToken);

        private TileData GetTileData(PointInt32 tileOffset) => 
            this.tileOffsetToTileDataMap.GetOrAdd(tileOffset, to => new TileData(to));

        public void RenderMask(ISurface<ColorAlpha8> dstMask, PointInt32 renderOffset, ICancellationToken cancelToken)
        {
            Validate.Begin().IsNotNull<ISurface<ColorAlpha8>>(dstMask, "dstMask").IsNotNull<ICancellationToken>(cancelToken, "cancelToken").Check();
            cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
            RectInt32 sourceRect = new RectInt32(renderOffset, dstMask.Size<ColorAlpha8>());
            if (Interlocked.Exchange(ref this.haveFetchedStamp, 1) == 0)
            {
                cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                this.lazyStampMaskDevBitmap.EnsureEvaluated();
            }
            foreach (PointInt32 num2 in this.tileMathHelper.EnumerateTileOffsets(sourceRect))
            {
                cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                TileData tileData = this.GetTileData(num2);
                RectInt32 tileSourceRect = this.tileMathHelper.GetTileSourceRect(num2);
                RectInt32 num4 = RectInt32.Intersect(tileSourceRect, sourceRect);
                PointInt32 num5 = new PointInt32(num4.X - tileSourceRect.X, num4.Y - tileSourceRect.Y);
                RectInt32 bounds = new RectInt32(num4.X - sourceRect.X, num4.Y - sourceRect.Y, num4.Width, num4.Height);
                ISurface<ColorAlpha8> surface = dstMask.CreateWindow<ColorAlpha8>(bounds);
                object sync = tileData.Sync;
                lock (sync)
                {
                    cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                    this.UpdateTileWhileLocked(tileData, cancelToken);
                    cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                    if (tileData.Mask == null)
                    {
                        surface.Clear();
                    }
                    else
                    {
                        tileData.Mask.Render(surface, num5);
                    }
                }
                cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
            }
        }

        private void UpdateTileWhileLocked(TileData tileData, ICancellationToken cancelToken)
        {
            RectInt32 tileSourceRect = this.tileMathHelper.GetTileSourceRect(tileData.Offset);
            RectDouble num2 = tileSourceRect;
            cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
            object newCurrencyToken = this.renderData.CreateCurrencyToken();
            cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
            IList<int?> list = this.renderData.GetStrokeSampleIndicesInRect(tileSourceRect, tileData.CurrencyToken, newCurrencyToken);
            int count = list.Count;
            if (count > 0)
            {
                SizeDouble size = this.stamp.Size;
                RectDouble num5 = new RectDouble(PointDouble.Zero, size);
                IDrawingContext dc = null;
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        int? nullable = list[i];
                        if (nullable.HasValue)
                        {
                            if (tileData.Mask == null)
                            {
                                cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                                tileData.Mask = new SurfaceAlpha8(tileSourceRect.Size);
                            }
                            if (tileData.MaskRenderTarget == null)
                            {
                                cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                                tileData.MaskRenderTarget = RenderTarget.FromSurface(tileData.Mask, FactorySource.PerThread);
                            }
                            if (dc == null)
                            {
                                cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                                dc = DrawingContext.FromRenderTarget(tileData.MaskRenderTarget);
                                dc.UseTranslateTransform((float) -tileSourceRect.X, (float) -tileSourceRect.Y, MatrixMultiplyOrder.Prepend);
                                dc.AntialiasMode = AntialiasMode.Aliased;
                            }
                            int valueOrDefault = nullable.GetValueOrDefault();
                            RectDouble bounds = this.renderData.StrokeSamples[valueOrDefault].GetBounds(size);
                            RectDouble num9 = this.stamp.Antialiased ? bounds : RectDouble.Round(bounds, MidpointRounding.AwayFromZero);
                            cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                            RectDouble? srcRect = null;
                            dc.FillOpacityMask(this.lazyStampMaskDevBitmap.CancelableValue<DeviceBitmap>(), whiteBrush, OpacityMaskContent.Graphics, new RectDouble?(num9), srcRect);
                        }
                    }
                }
                finally
                {
                    DisposableUtil.Free<IDrawingContext>(ref dc);
                }
            }
            tileData.CurrencyToken = newCurrencyToken;
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly BrushStrokeRenderCache.<>c <>9 = new BrushStrokeRenderCache.<>c();
            public static Func<PointInt32, BrushStrokeRenderCache.TileData> <>9__12_0;

            internal BrushStrokeRenderCache.TileData <GetTileData>b__12_0(PointInt32 to) => 
                new BrushStrokeRenderCache.TileData(to);
        }

        private sealed class MaskRenderer : IRenderer<ColorAlpha8>
        {
            private ICancellationToken cancelToken;
            private int height;
            private BrushStrokeRenderCache owner;
            private int width;

            public MaskRenderer(BrushStrokeRenderCache owner, int width, int height, ICancellationToken cancelToken)
            {
                Validate.Begin().IsNotNull<BrushStrokeRenderCache>(owner, "owner").IsNotNull<ICancellationToken>(cancelToken, "cancelToken").Check();
                this.owner = owner;
                this.width = width;
                this.height = height;
                this.cancelToken = cancelToken;
            }

            public void Render(ISurface<ColorAlpha8> dst, PointInt32 renderOffset)
            {
                this.owner.RenderMask(dst, renderOffset, this.cancelToken);
            }

            public int Height =>
                this.height;

            public int Width =>
                this.width;
        }

        private sealed class TileData
        {
            public TileData(PointInt32 offset)
            {
                this.Offset = offset;
            }

            public object CurrencyToken { get; set; }

            public ISurfaceRef<ColorAlpha8> Mask { get; set; }

            public IRenderTarget MaskRenderTarget { get; set; }

            public PointInt32 Offset { get; private set; }

            public object Sync =>
                this;
        }
    }
}

