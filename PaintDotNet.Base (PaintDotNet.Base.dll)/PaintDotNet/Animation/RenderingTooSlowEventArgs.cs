namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using System;

    public sealed class RenderingTooSlowEventArgs : PooledEventArgs<RenderingTooSlowEventArgs, int>
    {
        public int FramesPerSecond =>
            base.Value1;
    }
}

