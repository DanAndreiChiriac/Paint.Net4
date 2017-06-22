namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public sealed class ProtectedRegion
    {
        private static readonly ProtectedRegionOptions allOptionsMask = (ProtectedRegionOptions.ErrorOnMultithreadedAccess | ProtectedRegionOptions.ErrorOnPerThreadReentrancy | ProtectedRegionOptions.DisablePumpingWhenEntered);
        private object enterSync;
        private bool everEntered;
        private static readonly Func<int> int32DefaultValueFactory = new Func<int>(<>c.<>9.<.cctor>b__30_0);
        private readonly string name;
        private readonly ProtectedRegionOptions options;
        private ThreadLocal<int> threadEnteredCount;
        private static readonly ThreadLocal<int> threadInNonPumpingRegionCount = new ThreadLocal<int>(int32DefaultValueFactory);

        public ProtectedRegion(string name, ProtectedRegionOptions options)
        {
            Validate.IsNotNull<string>(name, "name");
            if (options != (options & allOptionsMask))
            {
                ExceptionUtil.ThrowArgumentException("options");
            }
            this.name = name;
            this.options = options;
            this.threadEnteredCount = new ThreadLocal<int>(int32DefaultValueFactory);
            if (this.ErrorOnMultithreadedAccess)
            {
                this.enterSync = new object();
            }
        }

        public void Dispose()
        {
            if (this.everEntered)
            {
                ExceptionUtil.ThrowInvalidOperationException("Dispose() may only be called if Enter() has never been called");
            }
            DisposableUtil.Free<ThreadLocal<int>>(ref this.threadEnteredCount);
            this.enterSync = null;
        }

        public void Enter()
        {
            try
            {
            }
            finally
            {
                int num;
                this.everEntered = true;
                bool flag = false;
                bool flag2 = false;
                if (this.DisablePumpingWhenEntered)
                {
                    num = threadInNonPumpingRegionCount.Value + 1;
                    threadInNonPumpingRegionCount.Value = num;
                }
                if (this.ErrorOnMultithreadedAccess)
                {
                    flag = Monitor.TryEnter(this.enterSync);
                    if (!flag)
                    {
                        ExceptionUtil.ThrowInvalidOperationException($"ProtectedRegion '{this.name}' was marked as thread exclusive, but was entered from multiple threads");
                    }
                }
                try
                {
                    int num2 = this.threadEnteredCount.Value + 1;
                    if ((num2 > 1) && this.ErrorOnPerThreadReentrancy)
                    {
                        ExceptionUtil.ThrowInvalidOperationException($"ProtectedRegion '{this.name}' was marked as per-thread non-reentrant, but was re-entered on this thread");
                    }
                    this.threadEnteredCount.Value = num2;
                }
                catch (Exception)
                {
                    flag2 = true;
                    throw;
                }
                finally
                {
                    if (flag2)
                    {
                        if (flag)
                        {
                            Monitor.Exit(this.enterSync);
                        }
                        num = threadInNonPumpingRegionCount.Value - 1;
                        threadInNonPumpingRegionCount.Value = num;
                    }
                }
            }
        }

        public void Exit()
        {
            try
            {
            }
            finally
            {
                int num = this.threadEnteredCount.Value - 1;
                if (num < 0)
                {
                    ExceptionUtil.ThrowInvalidOperationException("Exit() was called more times than Enter() on this thread");
                }
                if (this.ErrorOnMultithreadedAccess)
                {
                    Monitor.Exit(this.enterSync);
                }
                this.threadEnteredCount.Value = num;
                if (this.DisablePumpingWhenEntered)
                {
                    int num2 = threadInNonPumpingRegionCount.Value - 1;
                    threadInNonPumpingRegionCount.Value = num2;
                }
            }
        }

        public EnterScope UseEnterScope() => 
            new EnterScope(this);

        private bool DisablePumpingWhenEntered =>
            ((this.options & ProtectedRegionOptions.DisablePumpingWhenEntered) == ProtectedRegionOptions.DisablePumpingWhenEntered);

        private bool ErrorOnMultithreadedAccess =>
            ((this.options & ProtectedRegionOptions.ErrorOnMultithreadedAccess) == ProtectedRegionOptions.ErrorOnMultithreadedAccess);

        private bool ErrorOnPerThreadReentrancy =>
            ((this.options & ProtectedRegionOptions.ErrorOnPerThreadReentrancy) == ProtectedRegionOptions.ErrorOnPerThreadReentrancy);

        public bool IsThreadEntered =>
            (this.ThreadEnteredCount > 0);

        internal static bool IsThreadInNonPumpingRegion =>
            (threadInNonPumpingRegionCount.Value > 0);

        public string Name =>
            this.name;

        public ProtectedRegionOptions Options =>
            this.options;

        public int ThreadEnteredCount =>
            this.threadEnteredCount.Value;

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ProtectedRegion.<>c <>9 = new ProtectedRegion.<>c();

            internal int <.cctor>b__30_0() => 
                0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EnterScope : IDisposable
        {
            private ProtectedRegion owner;
            internal EnterScope(ProtectedRegion owner)
            {
                this.owner = owner;
                this.owner.Enter();
            }

            public void Dispose()
            {
                if (this.owner != null)
                {
                    this.owner.Exit();
                    this.owner = null;
                }
            }
        }
    }
}

