namespace PaintDotNet.Threading
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Concurrency;
    using System;

    public interface IDispatcher : IObjectRef, IDisposable, IIsDisposed, IAsyncWorkQueue, IThreadAffinitizedObject
    {
    }
}

