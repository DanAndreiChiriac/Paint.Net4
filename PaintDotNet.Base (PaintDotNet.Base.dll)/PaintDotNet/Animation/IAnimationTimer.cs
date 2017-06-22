namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;
    using System.Runtime.CompilerServices;

    [NativeInterfaceID("6b0efad1-a053-41d6-9085-33a689144665")]
    public interface IAnimationTimer : IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        event EventHandler PostUpdate;

        event EventHandler PreUpdate;

        event RenderingTooSlowEventHandler RenderingTooSlow;

        bool IsEnabled { get; set; }

        AnimationSeconds Time { get; }
    }
}

