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
    public class TextFormatProxy : ObjectRefProxy<ITextFormat>, ITextFormat, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TextFormatProxy(ITextFormat objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

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

