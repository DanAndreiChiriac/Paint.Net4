namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ObjectUtil
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeOf<T>() => 
            SizeOfHelper<T>.SizeOf;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap<T>(ref T a, ref T b)
        {
            T local = a;
            a = b;
            b = local;
        }

        private static class SizeOfHelper<T>
        {
            public static readonly int SizeOf;

            static SizeOfHelper()
            {
                ObjectUtil.SizeOfHelper<T>.SizeOf = Marshal.SizeOf(typeof(T));
            }
        }
    }
}

