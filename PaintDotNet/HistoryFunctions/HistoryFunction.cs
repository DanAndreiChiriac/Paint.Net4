namespace PaintDotNet.HistoryFunctions
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.HistoryMementos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;

    internal abstract class HistoryFunction
    {
        private PaintDotNet.ActionFlags actionFlags;
        private int criticalRegionCount;
        private bool executed;

        public HistoryFunction(PaintDotNet.ActionFlags actionFlags)
        {
            this.actionFlags = actionFlags;
        }

        protected void EnterCriticalRegion()
        {
            Interlocked.Increment(ref this.criticalRegionCount);
        }

        public HistoryMemento Execute(IHistoryWorkspace historyWorkspace)
        {
            HistoryMemento memento2;
            try
            {
                if (this.executed)
                {
                    throw new InvalidOperationException("Already executed this HistoryFunction");
                }
                this.executed = true;
                memento2 = this.OnExecute(historyWorkspace);
            }
            catch (Exception exception)
            {
                IEnumerable<Exception> innerExceptions;
                if (this.criticalRegionCount > 0)
                {
                    throw;
                }
                AggregateException exception2 = exception as AggregateException;
                if (exception2 != null)
                {
                    innerExceptions = exception2.Flatten().InnerExceptions;
                }
                else
                {
                    innerExceptions = EnumerableUtil.One<Exception>(exception);
                }
                if (innerExceptions.All<Exception>(innerEx => ((innerEx is ArgumentOutOfRangeException) || (innerEx is OperationCanceledException)) || (innerEx is OutOfMemoryException)))
                {
                    throw new HistoryFunctionNonFatalException(null, exception);
                }
                throw;
            }
            return memento2;
        }

        public abstract HistoryMemento OnExecute(IHistoryWorkspace historyWorkspace);

        public PaintDotNet.ActionFlags ActionFlags =>
            this.actionFlags;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly HistoryFunction.<>c <>9 = new HistoryFunction.<>c();
            public static Func<Exception, bool> <>9__5_0;

            internal bool <Execute>b__5_0(Exception innerEx) => 
                (((innerEx is ArgumentOutOfRangeException) || (innerEx is OperationCanceledException)) || (innerEx is OutOfMemoryException));
        }
    }
}

