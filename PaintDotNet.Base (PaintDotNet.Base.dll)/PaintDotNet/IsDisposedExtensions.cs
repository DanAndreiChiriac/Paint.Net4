namespace PaintDotNet
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class IsDisposedExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining), Conditional("DEBUG")]
        public static void AssertNotDisposed<T>(this T theObject) where T: IIsDisposed
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining), Conditional("DEBUG")]
        public static void VerifyNotDisposed<T>(this T theObject) where T: IIsDisposed
        {
        }
    }
}

