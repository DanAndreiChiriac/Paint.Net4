namespace PaintDotNet.Interop
{
    using System;
    using System.Collections.Generic;

    public sealed class SafeHandleEqualityComparer<THandle> : IEqualityComparer<THandle> where THandle: SafeHandle
    {
        private static readonly SafeHandleEqualityComparer<THandle> instance;

        static SafeHandleEqualityComparer()
        {
            SafeHandleEqualityComparer<THandle>.instance = new SafeHandleEqualityComparer<THandle>();
        }

        public bool Equals(THandle x, THandle y)
        {
            bool flag3;
            bool success = false;
            x.DangerousAddRef(ref success);
            try
            {
                bool flag2 = false;
                y.DangerousAddRef(ref flag2);
                try
                {
                    flag3 = x.DangerousGetHandle() == y.DangerousGetHandle();
                }
                finally
                {
                    if (flag2)
                    {
                        y.DangerousRelease();
                    }
                }
            }
            finally
            {
                if (success)
                {
                    x.DangerousRelease();
                }
            }
            return flag3;
        }

        public int GetHashCode(THandle obj)
        {
            int hashCode;
            bool success = false;
            obj.DangerousAddRef(ref success);
            try
            {
                hashCode = obj.DangerousGetHandle().GetHashCode();
            }
            finally
            {
                if (success)
                {
                    obj.DangerousRelease();
                }
            }
            return hashCode;
        }

        public static SafeHandleEqualityComparer<THandle> Default =>
            SafeHandleEqualityComparer<THandle>.instance;
    }
}

