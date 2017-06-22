namespace PaintDotNet.Runtime
{
    using PaintDotNet;
    using PaintDotNet.Collections;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Concurrent;
    using System.Threading;

    internal static class CleanupThread
    {
        private const int minCleanupIntervalMs = 500;
        private static readonly ManualResetEvent notCleaningEvent = new ManualResetEvent(true);
        private static readonly ManualResetEvent workAvailableEvent = new ManualResetEvent(false);
        private static readonly ConcurrentQueue<CleanupSource> workItemQueue = new ConcurrentQueue<CleanupSource>();
        private static readonly ConcurrentSet<CleanupSource> workItemSet = new ConcurrentSet<CleanupSource>();
        private static readonly Thread workThread = new Thread(new ThreadStart(CleanupThread.WorkThreadProc));

        static CleanupThread()
        {
            workThread.Name = "CleanupThread";
            workThread.IsBackground = true;
            workThread.Start();
        }

        internal static bool EnsureEnqueued(CleanupSource cleanupSource)
        {
            Validate.IsNotNull<CleanupSource>(cleanupSource, "cleanupSource");
            if (!workItemSet.Add(cleanupSource))
            {
                return false;
            }
            workItemQueue.Enqueue(cleanupSource);
            ManualResetEvent workAvailableEvent = CleanupThread.workAvailableEvent;
            lock (workAvailableEvent)
            {
                if (workItemQueue.Any<CleanupSource>())
                {
                    CleanupThread.workAvailableEvent.Set();
                }
            }
            return true;
        }

        internal static bool IsQueued(CleanupSource cleanupSource) => 
            workItemSet.Contains(cleanupSource);

        internal static void WaitForPendingCleanup(int timeoutMs)
        {
            if (IsCleanupThread)
            {
                throw new InvalidOperationException("Cannot call WaitForPendingCleanup() from the cleanup thread");
            }
            notCleaningEvent.WaitOne(timeoutMs);
        }

        private static void WorkThreadProc()
        {
        Label_0000:
            CleanupThread.workAvailableEvent.WaitOne();
            notCleaningEvent.Reset();
            try
            {
                Thread.Sleep(500);
                int count = workItemQueue.Count;
                int num2 = 0;
                try
                {
                    CleanupSource source;
                    long workingSet = Environment.WorkingSet;
                    while ((num2 < count) && workItemQueue.TryDequeue(out source))
                    {
                        if (!workItemSet.TryRemove(source))
                        {
                            throw new InternalErrorException("workItemSet.TryRemove(cleanupSource) returned false");
                        }
                        source.PerformCleanup();
                        num2++;
                    }
                    long num1 = Environment.WorkingSet;
                }
                finally
                {
                }
            }
            finally
            {
                notCleaningEvent.Set();
            }
            ManualResetEvent workAvailableEvent = CleanupThread.workAvailableEvent;
            lock (workAvailableEvent)
            {
                if (!workItemQueue.Any<CleanupSource>())
                {
                    CleanupThread.workAvailableEvent.Reset();
                }
                goto Label_0000;
            }
        }

        internal static bool IsCleanupThread =>
            (Thread.CurrentThread == workThread);
    }
}

