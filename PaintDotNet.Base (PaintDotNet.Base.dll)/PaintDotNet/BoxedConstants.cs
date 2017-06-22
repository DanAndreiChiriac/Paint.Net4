namespace PaintDotNet
{
    using System;

    [Obsolete]
    public sealed class BoxedConstants
    {
        private BoxedConstants()
        {
        }

        [Obsolete("Use BooleanUtil.GetBoxed() instead", true)]
        public static object GetBoolean(bool value) => 
            BooleanUtil.GetBoxed(value);

        [Obsolete("User Int32Util.GetBoxed() instead", true)]
        public static object GetInt32(int value) => 
            Int32Util.GetBoxed(value);
    }
}

