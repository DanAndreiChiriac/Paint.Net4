namespace PaintDotNet
{
    using System;

    public static class TrimmableUtil
    {
        public static void Free<T>(ref T cleanMe) where T: class, ITrimmable
        {
            if (((T) cleanMe) != null)
            {
                cleanMe.Trim();
                cleanMe = default(T);
            }
        }

        public static void Free<T>(ref T cleanMe, bool callerIsNotFinalizing) where T: class, ITrimmable
        {
            if (((T) cleanMe) != null)
            {
                if (callerIsNotFinalizing)
                {
                    cleanMe.Trim();
                }
                cleanMe = default(T);
            }
        }
    }
}

