namespace PaintDotNet.Runtime
{
    using PaintDotNet;
    using System;

    public sealed class CleanupManagerController : Disposable
    {
        internal CleanupManagerController()
        {
        }

        public void AddCleanupSource(CleanupSource cleanupSource)
        {
            CleanupManager.AddCleanupSource(cleanupSource);
        }

        protected override void Dispose(bool disposing)
        {
            CleanupManager.NotifyControllerDisposed(this);
            base.Dispose(disposing);
        }

        public void RegisterTrimmableObject(ITrimmable trimmableObject)
        {
            CleanupManager.RegisterTrimmableObject(trimmableObject);
        }

        public void RemoveCleanupSource(CleanupSource cleanupSource)
        {
            CleanupManager.RemoveCleanupSource(cleanupSource);
        }
    }
}

