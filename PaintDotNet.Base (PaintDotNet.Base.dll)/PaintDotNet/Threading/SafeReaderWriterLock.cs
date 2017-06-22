namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;

    public sealed class SafeReaderWriterLock
    {
        private int id;
        private ThreadLocal<ProtectedRegion> lockHeldRegion;
        private static int nextID;
        private ReaderWriterLockSlim rwLock;

        public SafeReaderWriterLock() : this(null)
        {
        }

        public SafeReaderWriterLock(string lockHeldRegionName)
        {
            this.id = Interlocked.Increment(ref nextID);
            this.rwLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
            this.lockHeldRegion = new ThreadLocal<ProtectedRegion>(() => new ProtectedRegion(lockHeldRegionName ?? "SafeReaderWriterLock", ProtectedRegionOptions.ErrorOnPerThreadReentrancy | ProtectedRegionOptions.DisablePumpingWhenEntered));
        }

        public static void EnterMultipleReadLocks(SafeReaderWriterLock a, SafeReaderWriterLock b)
        {
            Validate.Begin().IsNotNull<SafeReaderWriterLock>(a, "a").IsNotNull<SafeReaderWriterLock>(b, "b").Check();
            Thread.BeginCriticalRegion();
            if (a.id == b.id)
            {
                a.EnterReadLock();
            }
            else if (a.id < b.id)
            {
                a.EnterReadLock();
                b.EnterReadLock();
            }
            else
            {
                b.EnterReadLock();
                a.EnterReadLock();
            }
            Thread.EndCriticalRegion();
        }

        public static void EnterMultipleWriteLocks(SafeReaderWriterLock a, SafeReaderWriterLock b)
        {
            Validate.Begin().IsNotNull<SafeReaderWriterLock>(a, "a").IsNotNull<SafeReaderWriterLock>(b, "b").Check();
            Thread.BeginCriticalRegion();
            if (a.id == b.id)
            {
                a.EnterWriteLock();
            }
            else if (a.id < b.id)
            {
                a.EnterWriteLock();
                b.EnterWriteLock();
            }
            else
            {
                b.EnterWriteLock();
                a.EnterWriteLock();
            }
            Thread.EndCriticalRegion();
        }

        public void EnterReadLock()
        {
            Thread.BeginCriticalRegion();
            this.lockHeldRegion.Value.Enter();
            this.rwLock.EnterReadLock();
        }

        public void EnterWriteLock()
        {
            Thread.BeginCriticalRegion();
            this.lockHeldRegion.Value.Enter();
            this.rwLock.EnterWriteLock();
        }

        public static void ExitMultipleReadLocks(SafeReaderWriterLock a, SafeReaderWriterLock b)
        {
            Validate.Begin().IsNotNull<SafeReaderWriterLock>(a, "a").IsNotNull<SafeReaderWriterLock>(b, "b").Check();
            Thread.BeginCriticalRegion();
            if (a.id == b.id)
            {
                a.ExitReadLock();
            }
            else if (a.id < b.id)
            {
                a.ExitReadLock();
                b.ExitReadLock();
            }
            else
            {
                b.ExitReadLock();
                a.ExitReadLock();
            }
            Thread.EndCriticalRegion();
        }

        public static void ExitMultipleWriteLocks(SafeReaderWriterLock a, SafeReaderWriterLock b)
        {
            Validate.Begin().IsNotNull<SafeReaderWriterLock>(a, "a").IsNotNull<SafeReaderWriterLock>(b, "b").Check();
            Thread.BeginCriticalRegion();
            if (a.id == b.id)
            {
                a.ExitWriteLock();
            }
            else if (a.id < b.id)
            {
                a.ExitWriteLock();
                b.ExitWriteLock();
            }
            else
            {
                b.ExitWriteLock();
                a.ExitWriteLock();
            }
            Thread.EndCriticalRegion();
        }

        public void ExitReadLock()
        {
            this.rwLock.ExitReadLock();
            this.lockHeldRegion.Value.Exit();
            Thread.EndCriticalRegion();
        }

        public void ExitWriteLock()
        {
            this.rwLock.ExitWriteLock();
            this.lockHeldRegion.Value.Exit();
            Thread.EndCriticalRegion();
        }

        public bool TryEnterReadLock() => 
            this.TryEnterReadLock(-1);

        public bool TryEnterReadLock(int millisecondsTimeout)
        {
            Thread.BeginCriticalRegion();
            this.lockHeldRegion.Value.Enter();
            if (!this.rwLock.TryEnterReadLock(millisecondsTimeout))
            {
                this.lockHeldRegion.Value.Exit();
                Thread.EndCriticalRegion();
                return false;
            }
            return true;
        }

        public bool TryEnterReadLock(TimeSpan timeout)
        {
            int? nullable = DoubleUtil.TryConvertToInt32(timeout.TotalMilliseconds);
            if (nullable.HasValue)
            {
                return this.TryEnterReadLock(nullable.Value);
            }
            ExceptionUtil.ThrowArgumentException("cannot convert timeout.TotalMilliseconds to an Int32", "timeout");
            return false;
        }

        public bool TryEnterWriteLock() => 
            this.TryEnterWriteLock(-1);

        public bool TryEnterWriteLock(int millisecondsTimeout)
        {
            Thread.BeginCriticalRegion();
            this.lockHeldRegion.Value.Enter();
            if (!this.rwLock.TryEnterWriteLock(millisecondsTimeout))
            {
                this.lockHeldRegion.Value.Exit();
                Thread.EndCriticalRegion();
                return false;
            }
            return true;
        }

        public bool TryEnterWriteLock(TimeSpan timeout)
        {
            int? nullable = DoubleUtil.TryConvertToInt32(timeout.TotalMilliseconds);
            if (nullable.HasValue)
            {
                return this.TryEnterWriteLock(nullable.Value);
            }
            ExceptionUtil.ThrowArgumentException("cannot convert timeout.TotalMilliseconds to an Int32", "timeout");
            return false;
        }

        public static MultipleReadLocksScope UseMultipleReadLocks(SafeReaderWriterLock a, SafeReaderWriterLock b) => 
            new MultipleReadLocksScope(a, b);

        public static MultipleWriteLocksScope UseMultipleWriteLocks(SafeReaderWriterLock a, SafeReaderWriterLock b) => 
            new MultipleWriteLocksScope(a, b);

        public ReadLockScope UseReadLock() => 
            new ReadLockScope(this);

        public WriteLockScope UseWriteLock() => 
            new WriteLockScope(this);

        [StructLayout(LayoutKind.Sequential)]
        public struct MultipleReadLocksScope : IDisposable
        {
            private SafeReaderWriterLock a;
            private SafeReaderWriterLock b;
            internal MultipleReadLocksScope(SafeReaderWriterLock a, SafeReaderWriterLock b)
            {
                try
                {
                }
                finally
                {
                    SafeReaderWriterLock.EnterMultipleReadLocks(a, b);
                    this.a = a;
                    this.b = b;
                }
            }

            public void Dispose()
            {
                try
                {
                }
                finally
                {
                    if ((this.a != null) && (this.b != null))
                    {
                        SafeReaderWriterLock.ExitMultipleReadLocks(this.a, this.b);
                        this.a = null;
                        this.b = null;
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MultipleWriteLocksScope : IDisposable
        {
            private SafeReaderWriterLock a;
            private SafeReaderWriterLock b;
            internal MultipleWriteLocksScope(SafeReaderWriterLock a, SafeReaderWriterLock b)
            {
                try
                {
                }
                finally
                {
                    SafeReaderWriterLock.EnterMultipleWriteLocks(a, b);
                    this.a = a;
                    this.b = b;
                }
            }

            public void Dispose()
            {
                try
                {
                }
                finally
                {
                    if ((this.a != null) && (this.b != null))
                    {
                        SafeReaderWriterLock.ExitMultipleWriteLocks(this.a, this.b);
                        this.a = null;
                        this.b = null;
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ReadLockScope : IDisposable
        {
            private SafeReaderWriterLock owner;
            internal ReadLockScope(SafeReaderWriterLock owner)
            {
                try
                {
                }
                finally
                {
                    owner.EnterReadLock();
                    this.owner = owner;
                }
            }

            public void Dispose()
            {
                try
                {
                }
                finally
                {
                    if (this.owner != null)
                    {
                        this.owner.ExitReadLock();
                        this.owner = null;
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WriteLockScope : IDisposable
        {
            private SafeReaderWriterLock owner;
            internal WriteLockScope(SafeReaderWriterLock owner)
            {
                try
                {
                }
                finally
                {
                    owner.EnterWriteLock();
                    this.owner = owner;
                }
            }

            public void Dispose()
            {
                try
                {
                }
                finally
                {
                    if (this.owner != null)
                    {
                        this.owner.ExitWriteLock();
                        this.owner = null;
                    }
                }
            }
        }
    }
}

