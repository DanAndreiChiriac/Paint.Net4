namespace PaintDotNet.Imaging
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using System;

    public interface IProgressiveLevelControl : IObjectRef, IDisposable, IIsDisposed
    {
        int CurrentLevel { get; set; }

        int LevelCount { get; }
    }
}

