namespace PaintDotNet.Direct2D
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Direct2DFactoryOptions : IEquatable<Direct2DFactoryOptions>
    {
        private PaintDotNet.Direct2D.DebugLevel debugLevel;
        public PaintDotNet.Direct2D.DebugLevel DebugLevel
        {
            get => 
                this.debugLevel;
            set
            {
                this.debugLevel = value;
            }
        }
        public Direct2DFactoryOptions(PaintDotNet.Direct2D.DebugLevel debugLevel)
        {
            this.debugLevel = debugLevel;
        }

        public bool Equals(Direct2DFactoryOptions other) => 
            (this.debugLevel == other.debugLevel);

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<Direct2DFactoryOptions, object>(this, obj);

        public override int GetHashCode() => 
            ((int) this.debugLevel);
    }
}

