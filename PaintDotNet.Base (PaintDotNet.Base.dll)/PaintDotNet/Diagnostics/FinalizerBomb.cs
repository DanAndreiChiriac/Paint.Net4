namespace PaintDotNet.Diagnostics
{
    using System;

    public sealed class FinalizerBomb : IDisposable
    {
        public void Detonate()
        {
            throw new InvalidOperationException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~FinalizerBomb()
        {
            this.Detonate();
        }
    }
}

