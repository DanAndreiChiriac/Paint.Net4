namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Globalization;

    [NativeInterfaceID("9c906818-31d7-4fd3-a151-7c5e225db55a")]
    public interface ITextFormat : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        PaintDotNet.DirectWrite.FlowDirection FlowDirection { get; set; }

        IFontCollection FontCollection { get; }

        string FontFamilyName { get; }

        float FontSize { get; }

        PaintDotNet.DirectWrite.FontStretch FontStretch { get; }

        PaintDotNet.DirectWrite.FontStyle FontStyle { get; }

        PaintDotNet.DirectWrite.FontWeight FontWeight { get; }

        float IncrementalTabStop { get; set; }

        LineSpacingParameters LineSpacing { get; set; }

        CultureInfo Locale { get; }

        PaintDotNet.DirectWrite.ParagraphAlignment ParagraphAlignment { get; set; }

        PaintDotNet.DirectWrite.ReadingDirection ReadingDirection { get; set; }

        PaintDotNet.DirectWrite.TextAlignment TextAlignment { get; set; }

        TrimmingParameters Trimming { get; set; }

        PaintDotNet.DirectWrite.WordWrapping WordWrapping { get; set; }
    }
}

