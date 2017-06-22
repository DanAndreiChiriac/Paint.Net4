namespace PaintDotNet
{
    using System;

    public static class BooleanUtil
    {
        private static readonly object boxedFalse = false;
        private static readonly object boxedTrue = true;

        public static object GetBoxed(bool value)
        {
            if (!value)
            {
                return boxedFalse;
            }
            return boxedTrue;
        }
    }
}

