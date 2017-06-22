namespace PaintDotNet.Threading
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public static class MutexExtensions
    {
        public static UseLockScope UseLock(this Mutex mutex) => 
            new UseLockScope(mutex);

        [StructLayout(LayoutKind.Sequential)]
        public struct UseLockScope : IDisposable
        {
            private Mutex mutex;
            internal UseLockScope(Mutex mutex)
            {
                Validate.IsNotNull<Mutex>(mutex, "mutex");
                this.mutex = mutex;
                this.mutex.WaitOne();
            }

            public void Dispose()
            {
                if (this.mutex != null)
                {
                    this.mutex.ReleaseMutex();
                    this.mutex = null;
                }
            }
        }
    }
}

