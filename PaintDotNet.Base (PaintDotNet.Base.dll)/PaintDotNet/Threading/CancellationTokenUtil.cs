namespace PaintDotNet.Threading
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Threading;

    public static class CancellationTokenUtil
    {
        public static ICancellationToken Create(Func<bool> pollIsCancellationRequestedFn) => 
            new DelegateCancellationToken(pollIsCancellationRequestedFn);

        public static ICancellationToken Create(CancellationToken cancelToken) => 
            new FrameworkCancellationTokenWrapper(cancelToken);

        private sealed class DelegateCancellationToken : ICancellationToken
        {
            private readonly Func<bool> pollIsCancellationRequestedFn;

            public DelegateCancellationToken(Func<bool> pollIsCancellationRequestedFn)
            {
                this.pollIsCancellationRequestedFn = Validate.IsNotNull<Func<bool>>(pollIsCancellationRequestedFn, "pollIsCancellationRequestedFn");
            }

            public bool IsCancellationRequested =>
                this.pollIsCancellationRequestedFn();
        }

        private sealed class FrameworkCancellationTokenWrapper : ICancellationToken
        {
            private CancellationToken cancelToken;

            public FrameworkCancellationTokenWrapper(CancellationToken cancelToken)
            {
                this.cancelToken = cancelToken;
            }

            public bool IsCancellationRequested =>
                this.cancelToken.IsCancellationRequested;
        }
    }
}

