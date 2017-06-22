namespace PaintDotNet.Threading
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class CriticalSectionExtensions
    {
        public static UseLockScope UseLock(this CriticalSection mutex) => 
            new UseLockScope(mutex);

        [StructLayout(LayoutKind.Sequential)]
        public struct UseLockScope : IDisposable
        {
            private CriticalSection mutex;
            internal UseLockScope(CriticalSection mutex)
            {
                Validate.IsNotNull<CriticalSection>(mutex, "mutex");
                this.mutex = mutex;
                this.mutex.Enter();
            }

            public void Dispose()
            {
                if (this.mutex != null)
                {
                    this.mutex.Exit();
                    this.mutex = null;
                }
            }
        }
    }
}

