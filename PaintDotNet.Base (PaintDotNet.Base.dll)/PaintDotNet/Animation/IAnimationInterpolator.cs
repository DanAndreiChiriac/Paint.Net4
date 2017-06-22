namespace PaintDotNet.Animation
{
    using PaintDotNet;
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Interop;
    using System;

    [CustomImplementationAllowed, NativeInterfaceID("7815cbba-ddf7-478c-a46c-7b6c738b7978")]
    public interface IAnimationInterpolator : IAnimationObject, IObjectRef, IDisposable, IIsDisposed
    {
        double InterpolateValue(AnimationSeconds offset);
        double InterpolateVelocity(AnimationSeconds offset);
        void SetInitialValueAndVelocity(double initialValue, double initialVelocity);

        AnimationSeconds Duration { get; set; }

        AnimationDependencies DurationDependencies { get; }

        double FinalValue { get; }

        AnimationDependencies InitialValueDependencies { get; }

        AnimationDependencies InitialVelocityDependencies { get; }
    }
}

