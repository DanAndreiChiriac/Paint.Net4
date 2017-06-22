namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;

    public static class CancellationTokenExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfCancellationRequested<TToken>(this TToken token) where TToken: ICancellationToken
        {
            if (token.IsCancellationRequested)
            {
                ExceptionUtil.ThrowOperationCanceledException();
            }
        }
    }
}

