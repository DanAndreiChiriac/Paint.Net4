namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class CloneableExtensions
    {
        public static T CloneT<T>(this T cloneable) where T: ICloneable => 
            ((T) cloneable.Clone());
    }
}

