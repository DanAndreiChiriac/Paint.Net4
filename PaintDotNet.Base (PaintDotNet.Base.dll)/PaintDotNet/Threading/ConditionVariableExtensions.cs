namespace PaintDotNet.Threading
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ConditionVariableExtensions
    {
        public static UseLockScope UseLock(this ConditionVariable mutex) => 
            new UseLockScope(mutex);

        [StructLayout(LayoutKind.Sequential)]
        public struct UseLockScope : IDisposable
        {
            private ConditionVariable monitor;
            internal UseLockScope(ConditionVariable monitor)
            {
                Validate.IsNotNull<ConditionVariable>(monitor, "monitor");
                this.monitor = monitor;
                this.monitor.Enter();
            }

            public void Dispose()
            {
                if (this.monitor != null)
                {
                    this.monitor.Exit();
                    this.monitor = null;
                }
            }
        }
    }
}

