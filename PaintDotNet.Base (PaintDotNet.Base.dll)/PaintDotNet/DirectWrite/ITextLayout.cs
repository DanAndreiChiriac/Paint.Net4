namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Globalization;

    [NativeInterfaceID("53737037-6d14-410b-9bfe-0b182bb70961")]
    public interface ITextLayout : ITextFormat, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        TextRangeProperty<object> GetDrawingEffect(int currentPosition);
        TextRangeProperty<IFontCollection> GetFontCollection(int currentPosition);
        TextRangeProperty<string> GetFontFamilyName(int currentPosition);
        TextRangeProperty<float> GetFontSize(int currentPosition);
        TextRangeProperty<FontStretch> GetFontStretch(int currentPosition);
        TextRangeProperty<FontStyle> GetFontStyle(int currentPosition);
        TextRangeProperty<FontWeight> GetFontWeight(int currentPosition);
        TextRangeProperty<IInlineObject> GetInlineObject(int currentPosition);
        TextRangeProperty<CultureInfo> GetLocale(int currentPosition);
        TextRangeProperty<bool> GetStrikethrough(int currentPosition);
        TextRangeProperty<ITypography> GetTypography(int currentPosition);
        TextRangeProperty<bool> GetUnderline(int currentPosition);
        HitTestPointResult HitTestPoint(float pointX, float pointY);
        HitTestTextPositionResult HitTestTextPosition(int textPosition, bool isTrailingHit);
        HitTestMetrics[] HitTestTextRange(int textPosition, int textLength, float originX, float originY);
        void SetDrawingEffect(TextRange textRange, object drawingEffect);
        void SetFontCollection(TextRange textRange, IFontCollection fontCollection);
        void SetFontFamilyName(TextRange textRange, string fontFamilyName);
        void SetFontSize(TextRange textRange, float fontSize);
        void SetFontStretch(TextRange textRange, FontStretch fontStretch);
        void SetFontStyle(TextRange textRange, FontStyle fontStyle);
        void SetFontWeight(TextRange textRange, FontWeight fontWeight);
        void SetInlineObject(TextRange textRange, IInlineObject inlineObject);
        void SetLocale(TextRange textRange, CultureInfo locale);
        void SetStrikethrough(TextRange textRange, bool hasStrikethrough);
        void SetTypography(TextRange textRange, ITypography typography);
        void SetUnderline(TextRange textRange, bool hasUnderline);

        PaintDotNet.DirectWrite.ClusterMetrics[] ClusterMetrics { get; }

        PaintDotNet.DirectWrite.LineMetrics[] LineMetrics { get; }

        float MaxHeight { get; set; }

        float MaxWidth { get; set; }

        TextMetrics Metrics { get; }

        float MinWidth { get; }

        PaintDotNet.DirectWrite.OverhangMetrics OverhangMetrics { get; }
    }
}

