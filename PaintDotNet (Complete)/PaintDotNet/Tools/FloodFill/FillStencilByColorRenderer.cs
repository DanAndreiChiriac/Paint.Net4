﻿namespace PaintDotNet.Tools.FloodFill
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using PaintDotNet.Rendering;
    using PaintDotNet.Threading;
    using System;

    internal sealed class FillStencilByColorRenderer : IRenderer<ColorAlpha8>
    {
        private ColorBgra basis;
        private ICancellationToken cancelToken;
        private IRenderer<ColorBgra> sampleSource;
        private int tolerance;

        public FillStencilByColorRenderer(IRenderer<ColorBgra> sampleSource, ColorBgra basis, int tolerance, ICancellationToken cancelToken)
        {
            Validate.Begin().IsNotNull<IRenderer<ColorBgra>>(sampleSource, "sampleSource").IsNotNull<ICancellationToken>(cancelToken, "cancelToken").Check();
            this.sampleSource = sampleSource;
            this.basis = basis;
            this.tolerance = tolerance;
            this.cancelToken = cancelToken;
        }

        public unsafe void Render(ISurface<ColorAlpha8> dst, PointInt32 renderOffset)
        {
            int width = dst.Width;
            int height = dst.Height;
            RectInt32 bounds = new RectInt32(renderOffset, new SizeInt32(width, height));
            this.cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
            using (ISurface<ColorBgra> surface = this.sampleSource.UseTileOrToSurface(bounds))
            {
                for (int i = 0; i < height; i++)
                {
                    this.cancelToken.ThrowIfCancellationRequested<ICancellationToken>();
                    ColorBgra* rowPointer = (ColorBgra*) surface.GetRowPointer<ColorBgra>(i);
                    byte* numPtr = (byte*) dst.GetPointPointer<ColorAlpha8>(0, i);
                    for (int j = 0; j < width; j++)
                    {
                        byte num6;
                        ColorBgra b = rowPointer[0];
                        if (b == this.basis)
                        {
                            num6 = 0xff;
                        }
                        else if (FloodFillAlgorithm.GetDistance(this.basis, b) <= this.tolerance)
                        {
                            num6 = 0xff;
                        }
                        else
                        {
                            num6 = 0;
                        }
                        numPtr[0] = num6;
                        numPtr++;
                        rowPointer++;
                    }
                }
            }
        }

        public int Height =>
            this.sampleSource.Height;

        public int Width =>
            this.sampleSource.Width;
    }
}

