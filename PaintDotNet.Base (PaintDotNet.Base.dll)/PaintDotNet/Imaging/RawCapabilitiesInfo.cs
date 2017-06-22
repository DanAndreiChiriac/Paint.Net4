namespace PaintDotNet.Imaging
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RawCapabilitiesInfo
    {
        private uint cbSize;
        private uint codecMajorVersion;
        private uint codecMinorVersion;
        private RawCapabilities exposureCompensationSupport;
        private RawCapabilities contrastSupport;
        private RawCapabilities rgbWhitePointSupport;
        private RawCapabilities namedWhitePointSupport;
        private NamedWhitePoint namedWhitePointSupportMask;
        private RawCapabilities kelvinWhitePointSupport;
        private RawCapabilities gammaSupport;
        private RawCapabilities tintSupport;
        private RawCapabilities saturationSupport;
        private RawCapabilities sharpnessSupport;
        private RawCapabilities noiseReductionSupport;
        private RawCapabilities destinationColorProfileSupport;
        private RawCapabilities toneCurveSupport;
        private RawRotationCapabilities rotationSupport;
        private RawCapabilities renderModeSupport;
        public uint CodecMajorVersion =>
            this.codecMajorVersion;
        public uint CodecMinorVersion =>
            this.codecMinorVersion;
        public RawCapabilities ExposureCompensationSupport =>
            this.exposureCompensationSupport;
        public RawCapabilities ContrastSupport =>
            this.contrastSupport;
        public RawCapabilities RgbWhitePointSupport =>
            this.rgbWhitePointSupport;
        public RawCapabilities NamedWhitePointSupport =>
            this.namedWhitePointSupport;
        public NamedWhitePoint NamedWhitePointSupportMask =>
            this.namedWhitePointSupportMask;
        public RawCapabilities KelvinWhitePointSupport =>
            this.kelvinWhitePointSupport;
        public RawCapabilities GammaSupport =>
            this.gammaSupport;
        public RawCapabilities TintSupport =>
            this.tintSupport;
        public RawCapabilities SaturationSupport =>
            this.saturationSupport;
        public RawCapabilities SharpnessSupport =>
            this.sharpnessSupport;
        public RawCapabilities NoiseReductionSupport =>
            this.noiseReductionSupport;
        public RawCapabilities DestinationColorProfileSupport =>
            this.destinationColorProfileSupport;
        public RawCapabilities ToneCurveSupport =>
            this.toneCurveSupport;
        public RawRotationCapabilities RotationSupport =>
            this.rotationSupport;
        public RawCapabilities RenderModeSupport =>
            this.renderModeSupport;
    }
}

