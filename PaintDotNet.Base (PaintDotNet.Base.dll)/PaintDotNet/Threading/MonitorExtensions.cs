namespace PaintDotNet.Threading
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public static class MonitorExtensions
    {
        public static UseLockScope UseLock(this object monitor) => 
            new UseLockScope(monitor);

        [StructLayout(LayoutKind.Sequential)]
        public struct UseLockScope : IDisposable
        {
            private object monitor;
            internal UseLockScope(object monitor)
            {
                Validate.IsNotNull<object>(monitor, "monitor");
                this.monitor = monitor;
                Monitor.Enter(this.monitor);
            }

            public void Dispose()
            {
                if (this.monitor != null)
                {
                    Monitor.Exit(this.monitor);
                    this.monitor = null;
                }
            }
        }
    }
}

