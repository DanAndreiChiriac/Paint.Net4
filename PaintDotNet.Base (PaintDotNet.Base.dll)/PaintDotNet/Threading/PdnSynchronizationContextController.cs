namespace PaintDotNet.Threading
{
    using System;
    using System.Runtime.CompilerServices;

    public sealed class PdnSynchronizationContextController
    {
        internal PdnSynchronizationContextController(PdnSynchronizationContext instance)
        {
            this.Instance = instance;
        }

        public void Uninstall()
        {
            if (this.Instance != null)
            {
                PdnSynchronizationContext.Uninstall(this.Instance);
                this.Instance = null;
            }
        }

        public PdnSynchronizationContext Instance { get; private set; }
    }
}

