namespace PaintDotNet.Tools.PaintBucket
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Functional;
    using PaintDotNet.Imaging;
    using PaintDotNet.ObjectModel;
    using PaintDotNet.Rendering;
    using PaintDotNet.Threading;
    using PaintDotNet.Tools.FloodFill;
    using System;
    using System.Threading;

    internal sealed class PaintBucketToolContentRenderer : CancellableMaskedRendererBgraBase
    {
        private PdnBrush brush;
        private IRenderer<ColorBgra> brushRenderer;
        private PaintBucketToolChanges changes;
        private LazyResult<IRenderer<ColorAlpha8>> lazyStencil;
        private IRenderer<ColorBgra> sampleSource;

        public PaintBucketToolContentRenderer(IRenderer<ColorBgra> sampleSource, PaintBucketToolChanges changes) : base(sampleSource.Width, sampleSource.Height, true)
        {
            Validate.IsNotNull<PaintBucketToolChanges>(changes, "changes");
            this.sampleSource = sampleSource;
            this.changes = changes;
            this.brush = new PdnLegacyBrush(this.changes.BrushType, this.changes.HatchStyle, this.changes.ForegroundColor, this.changes.BackgroundColor).EnsureFrozen<PdnLegacyBrush>();
            this.brushRenderer = this.brush.CreateRenderer(base.Width, base.Height);
            this.lazyStencil = LazyResult.New<IRenderer<ColorAlpha8>>(() => this.CreateMaskRenderer(), LazyThreadSafetyMode.ExecutionAndPublication, new SingleUseCriticalSection());
        }

        private IRenderer<ColorAlpha8> CreateMaskRenderer()
        {
            IRenderer<ColorAlpha8> renderer;
            byte x = (byte) Math.Round((double) (this.changes.Tolerance * 255.0), MidpointRounding.AwayFromZero);
            byte tolerance = ByteUtil.FastScale(x, x);
            PointInt32 pt = this.changes.OriginPointInt32;
            if (!this.sampleSource.Bounds<ColorBgra>().Contains(pt))
            {
                return new FillRendererAlpha8(this.sampleSource.Width, this.sampleSource.Height, ColorAlpha8.Transparent);
            }
            ColorBgra pointSlow = this.sampleSource.GetPointSlow(pt);
            base.ThrowIfCancellationRequested();
            if (this.changes.FloodMode == FloodMode.Global)
            {
                renderer = new FillStencilByColorRenderer(this.sampleSource, pointSlow, tolerance, this);
            }
            else
            {
                RectInt32 num5;
                BitVector2D source = new BitVector2D(this.sampleSource.Width, this.sampleSource.Height);
                BitVector2DStruct stencilBuffer = new BitVector2DStruct(source);
                source.Clear(true);
                base.ThrowIfCancellationRequested();
                foreach (RectInt32 num6 in this.changes.ClippingMask.EnumerateInteriorScans())
                {
                    source.Set(num6, false);
                    base.ThrowIfCancellationRequested();
                }
                BitVector2D other = source.Clone();
                base.ThrowIfCancellationRequested();
                FloodFillAlgorithm.FillStencilFromPoint<BitVector2DStruct>(this.sampleSource, stencilBuffer, pt, tolerance, this, out num5);
                base.ThrowIfCancellationRequested();
                source.Xor(other);
                base.ThrowIfCancellationRequested();
                renderer = new BitVector2DToAlpha8Renderer<BitVector2DStruct>(stencilBuffer);
            }
            if (this.changes.Antialiasing)
            {
                return new FeatheredMaskRenderer(this.sampleSource, pointSlow, renderer, tolerance, this);
            }
            return renderer;
        }

        protected override void OnRender(ISurface<ColorBgra> dstContent, ISurface<ColorAlpha8> dstMask, PointInt32 renderOffset)
        {
            base.ThrowIfCancellationRequested();
            IRenderer<ColorAlpha8> renderer = this.lazyStencil.CancelableValue<IRenderer<ColorAlpha8>>();
            base.ThrowIfCancellationRequested();
            if (renderer == null)
            {
                throw new PaintDotNet.InternalErrorException("stencil == null");
            }
            base.ThrowIfCancellationRequested();
            renderer.Render(dstMask, renderOffset);
            base.ThrowIfCancellationRequested();
            this.brushRenderer.Render(dstContent, renderOffset);
        }
    }
}

