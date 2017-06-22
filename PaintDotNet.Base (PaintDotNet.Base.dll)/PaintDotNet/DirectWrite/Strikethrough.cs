namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Strikethrough : IEquatable<Strikethrough>
    {
        private float width;
        private float thickness;
        private float offset;
        private PaintDotNet.DirectWrite.ReadingDirection readingDirection;
        private PaintDotNet.DirectWrite.FlowDirection flowDirection;
        private CultureInfo locale;
        private TextMeasuringMode measuringMode;
        public float Width =>
            this.width;
        public float Thickness =>
            this.thickness;
        public float Offset =>
            this.offset;
        public PaintDotNet.DirectWrite.ReadingDirection ReadingDirection =>
            this.readingDirection;
        public PaintDotNet.DirectWrite.FlowDirection FlowDirection =>
            this.flowDirection;
        public CultureInfo Locale =>
            this.locale;
        public TextMeasuringMode MeasuringMode =>
            this.measuringMode;
        public Strikethrough(float width, float thickness, float offset, PaintDotNet.DirectWrite.ReadingDirection readingDirection, PaintDotNet.DirectWrite.FlowDirection flowDirection, CultureInfo locale, TextMeasuringMode measuringMode)
        {
            this.width = width;
            this.thickness = thickness;
            this.offset = offset;
            this.readingDirection = readingDirection;
            this.flowDirection = flowDirection;
            this.locale = locale;
            this.measuringMode = measuringMode;
        }

        public bool Equals(Strikethrough other) => 
            (((((this.width == other.width) && (this.thickness == other.thickness)) && ((this.offset == other.offset) && (this.readingDirection == other.readingDirection))) && ((this.flowDirection == other.flowDirection) && (this.locale == other.locale))) && (this.measuringMode == other.measuringMode));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<Strikethrough, object>(this, obj);

        public static bool operator ==(Strikethrough a, Strikethrough b) => 
            a.Equals(b);

        public static bool operator !=(Strikethrough a, Strikethrough b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.width.GetHashCode(), this.thickness.GetHashCode(), this.offset.GetHashCode(), (int) this.readingDirection, (int) this.flowDirection, this.locale.GetHashCode(), (int) this.measuringMode);
    }
}

