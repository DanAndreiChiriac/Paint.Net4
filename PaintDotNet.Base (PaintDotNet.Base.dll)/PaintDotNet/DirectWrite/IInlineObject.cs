namespace PaintDotNet.DirectWrite
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("8339fde3-106f-47ab-8373-1c6295eb10b3")]
    public interface IInlineObject : IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        BreakCondition BreakConditionAfter { get; }

        BreakCondition BreakConditionBefore { get; }

        InlineObjectMetrics Metrics { get; }

        PaintDotNet.DirectWrite.OverhangMetrics OverhangMetrics { get; }
    }
}

