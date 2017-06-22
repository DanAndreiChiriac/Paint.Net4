namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class TextLayoutProxy : ObjectRefProxy<ITextLayout>, ITextLayout, ITextFormat, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextLayoutProxy(ITextLayout objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<object> GetDrawingEffect(int currentPosition) => 
            base.innerRefT.GetDrawingEffect(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<IFontCollection> GetFontCollection(int currentPosition) => 
            base.innerRefT.GetFontCollection(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<string> GetFontFamilyName(int currentPosition) => 
            base.innerRefT.GetFontFamilyName(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<float> GetFontSize(int currentPosition) => 
            base.innerRefT.GetFontSize(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<PaintDotNet.DirectWrite.FontStretch> GetFontStretch(int currentPosition) => 
            base.innerRefT.GetFontStretch(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<PaintDotNet.DirectWrite.FontStyle> GetFontStyle(int currentPosition) => 
            base.innerRefT.GetFontStyle(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<PaintDotNet.DirectWrite.FontWeight> GetFontWeight(int currentPosition) => 
            base.innerRefT.GetFontWeight(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<IInlineObject> GetInlineObject(int currentPosition) => 
            base.innerRefT.GetInlineObject(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<CultureInfo> GetLocale(int currentPosition) => 
            base.innerRefT.GetLocale(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<bool> GetStrikethrough(int currentPosition) => 
            base.innerRefT.GetStrikethrough(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<ITypography> GetTypography(int currentPosition) => 
            base.innerRefT.GetTypography(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextRangeProperty<bool> GetUnderline(int currentPosition) => 
            base.innerRefT.GetUnderline(currentPosition);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HitTestPointResult HitTestPoint(float pointX, float pointY) => 
            base.innerRefT.HitTestPoint(pointX, pointY);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HitTestTextPositionResult HitTestTextPosition(int textPosition, bool isTrailingHit) => 
            base.innerRefT.HitTestTextPosition(textPosition, isTrailingHit);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HitTestMetrics[] HitTestTextRange(int textPosition, int textLength, float originX, float originY) => 
            base.innerRefT.HitTestTextRange(textPosition, textLength, originX, originY);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDrawingEffect(TextRange textRange, object drawingEffect)
        {
            base.innerRefT.SetDrawingEffect(textRange, drawingEffect);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontCollection(TextRange textRange, IFontCollection fontCollection)
        {
            base.innerRefT.SetFontCollection(textRange, fontCollection);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontFamilyName(TextRange textRange, string fontFamilyName)
        {
            base.innerRefT.SetFontFamilyName(textRange, fontFamilyName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontSize(TextRange textRange, float fontSize)
        {
            base.innerRefT.SetFontSize(textRange, fontSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontStretch(TextRange textRange, PaintDotNet.DirectWrite.FontStretch fontStretch)
        {
            base.innerRefT.SetFontStretch(textRange, fontStretch);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontStyle(TextRange textRange, PaintDotNet.DirectWrite.FontStyle fontStyle)
        {
            base.innerRefT.SetFontStyle(textRange, fontStyle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontWeight(TextRange textRange, PaintDotNet.DirectWrite.FontWeight fontWeight)
        {
            base.innerRefT.SetFontWeight(textRange, fontWeight);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetInlineObject(TextRange textRange, IInlineObject inlineObject)
        {
            base.innerRefT.SetInlineObject(textRange, inlineObject);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocale(TextRange textRange, CultureInfo locale)
        {
            base.innerRefT.SetLocale(textRange, locale);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetStrikethrough(TextRange textRange, bool hasStrikethrough)
        {
            base.innerRefT.SetStrikethrough(textRange, hasStrikethrough);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetTypography(TextRange textRange, ITypography typography)
        {
            base.innerRefT.SetTypography(textRange, typography);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetUnderline(TextRange textRange, bool hasUnderline)
        {
            base.innerRefT.SetUnderline(textRange, hasUnderline);
        }

        public PaintDotNet.DirectWrite.ClusterMetrics[] ClusterMetrics =>
            base.innerRefT.ClusterMetrics;

        public PaintDotNet.DirectWrite.FlowDirection FlowDirection
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.FlowDirection;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.FlowDirection = value;
            }
        }

        public IFontCollection FontCollection =>
            base.innerRefT.FontCollection;

        public string FontFamilyName =>
            base.innerRefT.FontFamilyName;

        public float FontSize =>
            base.innerRefT.FontSize;

        public PaintDotNet.DirectWrite.FontStretch FontStretch =>
            base.innerRefT.FontStretch;

        public PaintDotNet.DirectWrite.FontStyle FontStyle =>
            base.innerRefT.FontStyle;

        public PaintDotNet.DirectWrite.FontWeight FontWeight =>
            base.innerRefT.FontWeight;

        public float IncrementalTabStop
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.IncrementalTabStop;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.IncrementalTabStop = value;
            }
        }

        public PaintDotNet.DirectWrite.LineMetrics[] LineMetrics =>
            base.innerRefT.LineMetrics;

        public LineSpacingParameters LineSpacing
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.LineSpacing;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.LineSpacing = value;
            }
        }

        public CultureInfo Locale =>
            base.innerRefT.Locale;

        public float MaxHeight
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.MaxHeight;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.MaxHeight = value;
            }
        }

        public float MaxWidth
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.MaxWidth;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.MaxWidth = value;
            }
        }

        public TextMetrics Metrics =>
            base.innerRefT.Metrics;

        public float MinWidth =>
            base.innerRefT.MinWidth;

        public PaintDotNet.DirectWrite.OverhangMetrics OverhangMetrics =>
            base.innerRefT.OverhangMetrics;

        public PaintDotNet.DirectWrite.ParagraphAlignment ParagraphAlignment
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.ParagraphAlignment;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.ParagraphAlignment = value;
            }
        }

        public PaintDotNet.DirectWrite.ReadingDirection ReadingDirection
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.ReadingDirection;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.ReadingDirection = value;
            }
        }

        public PaintDotNet.DirectWrite.TextAlignment TextAlignment
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.TextAlignment;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.TextAlignment = value;
            }
        }

        public TrimmingParameters Trimming
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.Trimming;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.Trimming = value;
            }
        }

        public PaintDotNet.DirectWrite.WordWrapping WordWrapping
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 
                base.innerRefT.WordWrapping;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                base.innerRefT.WordWrapping = value;
            }
        }
    }
}

