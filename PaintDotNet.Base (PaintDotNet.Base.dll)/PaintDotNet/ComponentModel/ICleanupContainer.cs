namespace PaintDotNet.ComponentModel
{
    using PaintDotNet;
    using System;

    public interface ICleanupContainer : IDisposable, IIsDisposed
    {
        void AddCleanupObject(IDisposable cleanupObject);
    }
}

