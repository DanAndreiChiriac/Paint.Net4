namespace PaintDotNet.Threading
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public static class ReaderWriterLockExtensions
    {
        public static ReaderLockScope UseReadLock(this ReaderWriterLock rwLock) => 
            new ReaderLockScope(rwLock);

        public static WriterLockScope UseWriteLock(this ReaderWriterLock rwLock) => 
            new WriterLockScope(rwLock);

        [StructLayout(LayoutKind.Sequential)]
        public struct ReaderLockScope : IDisposable
        {
            private ReaderWriterLock rwLock;
            internal ReaderLockScope(ReaderWriterLock rwLock)
            {
                Validate.IsNotNull<ReaderWriterLock>(rwLock, "rwLock");
                rwLock.AcquireReaderLock(-1);
                this.rwLock = rwLock;
            }

            public void Dispose()
            {
                ReaderWriterLock rwLock = this.rwLock;
                if (rwLock != null)
                {
                    this.rwLock = null;
                    rwLock.ReleaseReaderLock();
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WriterLockScope : IDisposable
        {
            private ReaderWriterLock rwLock;
            internal WriterLockScope(ReaderWriterLock rwLock)
            {
                Validate.IsNotNull<ReaderWriterLock>(rwLock, "rwLock");
                rwLock.AcquireWriterLock(-1);
                this.rwLock = rwLock;
            }

            public void Dispose()
            {
                ReaderWriterLock rwLock = this.rwLock;
                if (rwLock != null)
                {
                    this.rwLock = null;
                    rwLock.ReleaseWriterLock();
                }
            }
        }
    }
}

