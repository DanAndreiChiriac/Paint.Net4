namespace PaintDotNet.DirectWrite.Proxies
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.DirectWrite;
    using System;
    using System.CodeDom.Compiler;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ObjectRefCodeGen", "4.16.0.0")]
    public class InlineObjectProxy : ObjectRefProxy<IInlineObject>, IInlineObject, IDirectWriteObject, IObjectRef, IDisposable, IIsDisposed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InlineObjectProxy(IInlineObject objectRef, ObjectRefProxyOptions proxyOptions) : base(objectRef, proxyOptions)
        {
        }

        public BreakCondition BreakConditionAfter =>
            base.innerRefT.BreakConditionAfter;

        public BreakCondition BreakConditionBefore =>
            base.innerRefT.BreakConditionBefore;

        public InlineObjectMetrics Metrics =>
            base.innerRefT.Metrics;

        public PaintDotNet.DirectWrite.OverhangMetrics OverhangMetrics =>
            base.innerRefT.OverhangMetrics;
    }
}

