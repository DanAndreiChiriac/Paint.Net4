namespace PaintDotNet.Threading
{
    using System;

    public interface ICancellationToken
    {
        bool IsCancellationRequested { get; }
    }
}

