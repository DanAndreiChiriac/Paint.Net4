namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Globalization;

    public struct Underline : IEquatable<Underline>
    {
        private PaintDotNet.DirectWrite.FlowDirection flowDirection;
        private CultureInfo locale;
        private TextMeasuringMode measuringMode;
        private float offset;
        private PaintDotNet.DirectWrite.ReadingDirection readingDirection;
        private float runHeight;
        private float thickness;
        private float width;

        public Underline(float width, float thickness, float offset, float runHeight, PaintDotNet.DirectWrite.ReadingDirection readingDirection, PaintDotNet.DirectWrite.FlowDirection flowDirection, CultureInfo locale, TextMeasuringMode measuringMode)
        {
            this.width = width;
            this.thickness = thickness;
            this.offset = offset;
            this.runHeight = runHeight;
            this.readingDirection = readingDirection;
            this.flowDirection = flowDirection;
            this.locale = locale;
            this.measuringMode = measuringMode;
        }

        public bool Equals(Underline other) => 
            (((((this.width == other.width) && (this.thickness == other.thickness)) && ((this.offset == other.offset) && (this.runHeight == other.runHeight))) && (((this.readingDirection == other.readingDirection) && (this.flowDirection == other.flowDirection)) && (this.locale == other.locale))) && (this.measuringMode == other.measuringMode));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<Underline, object>(this, obj);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.width.GetHashCode(), this.thickness.GetHashCode(), this.offset.GetHashCode(), this.runHeight.GetHashCode(), (int) this.readingDirection, (int) this.flowDirection, this.locale.GetHashCode(), (int) this.measuringMode);

        public static bool operator ==(Underline a, Underline b) => 
            a.Equals(b);

        public static bool operator !=(Underline a, Underline b) => 
            !(a == b);

        public PaintDotNet.DirectWrite.FlowDirection FlowDirection =>
            this.flowDirection;

        public CultureInfo Locale =>
            this.locale;

        public TextMeasuringMode MeasuringMode =>
            this.measuringMode;

        public float Offset =>
            this.offset;

        public PaintDotNet.DirectWrite.ReadingDirection ReadingDirection =>
            this.readingDirection;

        public float RunHeight =>
            this.runHeight;

        public float Thickness =>
            this.thickness;

        public float Width =>
            this.width;
    }
}

