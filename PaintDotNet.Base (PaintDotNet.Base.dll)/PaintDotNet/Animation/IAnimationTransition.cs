namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [NativeInterfaceID("dc6ce252-f731-41cf-b610-614b6ca049ad")]
    public interface IAnimationTransition : IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        void SetInitialValue(double value);
        void SetInitialVelocity(double velocity);

        AnimationSeconds Duration { get; }

        bool IsDurationKnown { get; }

        bool IsStoryboardActive { get; }
    }
}

