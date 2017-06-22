namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FontMetrics : IEquatable<FontMetrics>
    {
        private ushort designUnitsPerEm;
        private ushort ascent;
        private ushort descent;
        private short lineGap;
        private ushort capHeight;
        private ushort xHeight;
        private short underlinePosition;
        private ushort underlineThickness;
        private short strikethroughPosition;
        private ushort strikethroughThickness;
        public ushort DesignUnitsPerEm =>
            this.designUnitsPerEm;
        public ushort Ascent =>
            this.ascent;
        public ushort Descent =>
            this.descent;
        public short LineGap =>
            this.lineGap;
        public ushort CapHeight =>
            this.capHeight;
        public ushort XHeight =>
            this.xHeight;
        public short UnderlinePosition =>
            this.underlinePosition;
        public ushort UnderlineThickness =>
            this.underlineThickness;
        public short StrikethroughPosition =>
            this.strikethroughPosition;
        public ushort StrikethroughThickness =>
            this.strikethroughThickness;
        public FontMetrics(ushort designUnitsPerEm, ushort ascent, ushort descent, short lineGap, ushort capHeight, ushort xHeight, short underlinePosition, ushort underlineThickness, short strikethroughPosition, ushort strikethroughThickness)
        {
            this.designUnitsPerEm = designUnitsPerEm;
            this.ascent = ascent;
            this.descent = descent;
            this.lineGap = lineGap;
            this.capHeight = capHeight;
            this.xHeight = xHeight;
            this.underlinePosition = underlinePosition;
            this.underlineThickness = underlineThickness;
            this.strikethroughPosition = strikethroughPosition;
            this.strikethroughThickness = strikethroughThickness;
        }

        public bool Equals(FontMetrics other) => 
            ((((((this.designUnitsPerEm == other.designUnitsPerEm) && (this.ascent == other.ascent)) && ((this.descent == other.descent) && (this.lineGap == other.lineGap))) && (((this.capHeight == other.capHeight) && (this.xHeight == other.xHeight)) && ((this.underlinePosition == other.underlinePosition) && (this.underlineThickness == other.underlineThickness)))) && (this.strikethroughPosition == other.strikethroughPosition)) && (this.strikethroughThickness == other.strikethroughThickness));

        public override bool Equals(object obj) => 
            EquatableUtil.Equals<FontMetrics, object>(this, obj);

        public static bool operator ==(FontMetrics a, FontMetrics b) => 
            a.Equals(b);

        public static bool operator !=(FontMetrics a, FontMetrics b) => 
            !(a == b);

        public override int GetHashCode() => 
            HashCodeUtil.CombineHashCodes(this.designUnitsPerEm.GetHashCode(), this.ascent.GetHashCode(), this.descent.GetHashCode(), this.lineGap.GetHashCode(), this.capHeight.GetHashCode(), this.xHeight.GetHashCode(), this.underlinePosition.GetHashCode(), this.underlineThickness.GetHashCode(), this.strikethroughPosition.GetHashCode(), this.strikethroughThickness.GetHashCode());
    }
}

