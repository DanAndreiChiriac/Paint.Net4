namespace PaintDotNet.Threading
{
    using System;
    using System.Threading;

    public static class MonitorUtil
    {
        public static void EnsureEntered(object monitor, ref bool lockTaken)
        {
            if (!lockTaken)
            {
                Monitor.Enter(monitor, ref lockTaken);
            }
        }

        public static void EnsureExited(object monitor, ref bool lockTaken)
        {
            if (lockTaken)
            {
                Exit(monitor, ref lockTaken);
            }
        }

        public static void Exit(object monitor, ref bool lockTaken)
        {
            if (!lockTaken)
            {
                throw new ArgumentException("must be true", "lockTaken");
            }
            try
            {
                Monitor.Exit(monitor);
            }
            finally
            {
                lockTaken = false;
            }
        }
    }
}

