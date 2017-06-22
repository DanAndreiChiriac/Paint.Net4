namespace PaintDotNet.Threading
{
    using System;

    public static class CancellableUtil
    {
        public static bool TryCancel<TTarget>(ICancellable target)
        {
            target.Cancel();
            return true;
        }

        public static bool TryCancel(object target)
        {
            ICancellable cancellable = target as ICancellable;
            if (cancellable != null)
            {
                cancellable.Cancel();
                return true;
            }
            return false;
        }
    }
}

