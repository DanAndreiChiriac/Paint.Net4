namespace PaintDotNet.Runtime
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Collections.Concurrent;
    using System.Threading;

    public static class CleanupManager
    {
        private static readonly CleanupSourceCollection cleanupSourceCollection = new CleanupSourceCollection();
        private static CleanupManagerController controller;
        private static readonly GCCollectCleanupSource gcCollectCleanupSource = new GCCollectCleanupSource();
        private static readonly TrimmableCleanupSource trimmableCleanupSource;

        static CleanupManager()
        {
            cleanupSourceCollection.AddCleanupSource(gcCollectCleanupSource);
            trimmableCleanupSource = new TrimmableCleanupSource();
            cleanupSourceCollection.AddCleanupSource(trimmableCleanupSource);
        }

        internal static void AddCleanupSource(CleanupSource cleanupSource)
        {
            cleanupSourceCollection.AddCleanupSource(cleanupSource);
        }

        public static CleanupManagerController GetController()
        {
            CleanupManagerController controller = new CleanupManagerController();
            if (Interlocked.CompareExchange<CleanupManagerController>(ref CleanupManager.controller, controller, null) != null)
            {
                controller.Dispose();
                throw new InvalidOperationException("The controller has already been retrieved");
            }
            return controller;
        }

        internal static void NotifyControllerDisposed(CleanupManagerController disposedController)
        {
            Interlocked.CompareExchange<CleanupManagerController>(ref controller, null, disposedController);
        }

        internal static void RegisterTrimmableObject(ITrimmable trimmableObject)
        {
            trimmableCleanupSource.RegisterTrimmableObject(trimmableObject);
        }

        internal static void RemoveCleanupSource(CleanupSource cleanupSource)
        {
            cleanupSourceCollection.RemoveCleanupSource(cleanupSource);
        }

        public static void RequestCleanup()
        {
            cleanupSourceCollection.RequestCleanup();
        }

        public static void WaitForPendingCleanup()
        {
            WaitForPendingCleanup(-1);
        }

        public static void WaitForPendingCleanup(int timeoutMs)
        {
            CleanupThread.WaitForPendingCleanup(timeoutMs);
        }

        private sealed class GCCollectCleanupSource : CleanupSource
        {
            private void Cleanup()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            protected override void OnPerformCleanup()
            {
                this.Cleanup();
            }
        }

        private sealed class TrimmableCleanupSource : CleanupSource
        {
            private ConcurrentQueue<WeakReference> registeredObjects = new ConcurrentQueue<WeakReference>();

            private void Cleanup()
            {
                WeakReference reference;
                int count = this.registeredObjects.Count;
                while ((count > 0) && this.registeredObjects.TryDequeue(out reference))
                {
                    count--;
                    ITrimmable target = reference.Target as ITrimmable;
                    if ((target != null) && reference.IsAlive)
                    {
                        IIsDisposed disposed = target as IIsDisposed;
                        if ((disposed == null) || !disposed.IsDisposed)
                        {
                            target.Trim();
                            this.registeredObjects.Enqueue(reference);
                        }
                    }
                }
            }

            protected override void OnPerformCleanup()
            {
                this.Cleanup();
            }

            public void RegisterTrimmableObject(ITrimmable trimmable)
            {
                Validate.IsNotNull<ITrimmable>(trimmable, "trimmable");
                this.registeredObjects.Enqueue(new WeakReference(trimmable));
            }
        }
    }
}

