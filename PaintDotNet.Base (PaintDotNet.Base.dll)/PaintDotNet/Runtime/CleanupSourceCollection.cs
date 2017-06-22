namespace PaintDotNet.Runtime
{
    using PaintDotNet.Collections;
    using System;
    using System.Collections.Generic;

    internal sealed class CleanupSourceCollection : CleanupSource
    {
        private ConcurrentSet<CleanupSource> cleanupSources = new ConcurrentSet<CleanupSource>();

        public void AddCleanupSource(CleanupSource cleanupSource)
        {
            this.cleanupSources.Add(cleanupSource);
        }

        protected override void OnPerformCleanup()
        {
        }

        protected override void OnPerformCleanupQueued()
        {
            using (IEnumerator<CleanupSource> enumerator = this.cleanupSources.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    enumerator.Current.RequestCleanup();
                }
            }
        }

        public void RemoveCleanupSource(CleanupSource cleanupSource)
        {
            this.cleanupSources.Remove(cleanupSource);
        }
    }
}

